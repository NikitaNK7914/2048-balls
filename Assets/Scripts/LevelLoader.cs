using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]private TMP_Text coinsText;
    [SerializeField] private TMP_Text levelText;
    private string levelLoc;
    private string CoinLoc;
    public static LevelLoader Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (LanguageManager.Instance.currentLanguage == "ru")
        {
            levelLoc = "Уровень:";
            CoinLoc = "Монет:";
        }
        else
        {
            levelLoc = "Level:";
            CoinLoc = "Coins:";

        }
        levelText.text=levelLoc+(Progress.Instance.level).ToString();
        coinsText.text=CoinLoc+Progress.Instance.coins.ToString();
    }
    public void StartLevel()
    {
        Progress.Instance.Load();
        SceneManager.LoadScene(Progress.Instance.level);
    }
   
}
