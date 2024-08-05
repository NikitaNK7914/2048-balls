using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowFullscreenAdv();
    [SerializeField]private GameObject winWindow;
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private GameObject nextButton;

    private void Start()
    {
#if !UNITY_EDITOR
        ShowFullscreenAdv();
#endif
        Debug.Log("show screen");
    }
    public void Win()
    {
        winWindow.SetActive(true);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Progress.Instance.level = currentSceneIndex;
        if (currentSceneIndex == SceneManager.sceneCount)
        {
            nextButton.SetActive(false);
        }
    }
    public void Lose()
    {
        loseWindow.SetActive(true);
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(Progress.Instance.level + 1);
        Progress.Instance.SetLevel(Progress.Instance.level+1);
    }
    
}
