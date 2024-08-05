using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskIcon : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField]private TMP_Text text;
    [SerializeField] private ItemIcons itemIcons;
    public ItemType itemType;
    public int currentScore;
    [SerializeField] private AnimationCurve curve;
    public void Setup(ItemType item,int number) 
    {
        itemType = item;
        currentScore = number;
        image.sprite=itemIcons.GetSprite(item);
        text.text=currentScore.ToString();
    }
    public void AddOne()
    {
        currentScore--;
        if(currentScore < 0)
        {
            currentScore = 0;
        }
        text.text = currentScore.ToString();
        StartCoroutine(addAnimation());
    }
    private IEnumerator addAnimation()
    {
        for(float t = 0; t < 1f; t += Time.deltaTime)
        {
            float scale=curve.Evaluate(t);
            transform.localScale=Vector3.one*scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}
