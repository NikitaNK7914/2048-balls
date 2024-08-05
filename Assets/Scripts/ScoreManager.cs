using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TaskIcon taskIconPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private FlyingIcon flyingIconPrefab;
    [SerializeField] private Camera _camera;
    private TaskIcon[] TaskIcons;
    [SerializeField] private ItemIcons itemIcons;
    public static ScoreManager instance;
    [SerializeField]private GameManager gameManager;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Level level = FindObjectOfType<Level>();
        TaskIcons=new TaskIcon[level.tasks.Length];
        for (int i = 0; i<level.tasks.Length; i++)
        {
            TaskIcon newTaskIcon=Instantiate(taskIconPrefab,parent);
            newTaskIcon.Setup(level.tasks[i].type, level.tasks[i].number);
            TaskIcons[i]=newTaskIcon;
        }
    }
    public void AddScore(ItemType itemType,Vector3 pos)
    {
       for (int i = 0; i < TaskIcons.Length; i++)
        {
            if (TaskIcons[i].itemType==itemType)
            {
                if (TaskIcons[i].currentScore != 0)
                {
                    StartCoroutine(FlyAnimation(TaskIcons[i],pos));
                }
            }
        }
    }
    private IEnumerator FlyAnimation(TaskIcon taskIcon, Vector3 start)
    {
        Sprite sprite = itemIcons.GetSprite(taskIcon.itemType);
        FlyingIcon newflyingIcon= Instantiate(flyingIconPrefab,parent);
        newflyingIcon.Setup(sprite);
        Vector3 a = _camera.WorldToScreenPoint(start);
        Vector3 b = taskIcon.transform.position;

        for(float t=0;t<1f;t+=Time.deltaTime) {
            newflyingIcon.transform.position=Vector3.Lerp(a,b,t);
            yield return null;
        }
        Destroy(newflyingIcon.gameObject);
        taskIcon.AddOne();
        CheckWin();
    }
    private void CheckWin()
    {
        foreach (TaskIcon taskIcon in TaskIcons)
        {
            if(taskIcon.currentScore != 0)
            {
                return;
            }
        }
        gameManager.Win();
    }
}
