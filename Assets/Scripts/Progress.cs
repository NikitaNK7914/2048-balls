using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class ProgressData
{
    public int level;
    public int coins;
}
public class Progress : MonoBehaviour
{
    public int level;
    public int coins;
    public static Progress Instance;
    private void Awake()
    {
       if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetLevel(int level)
    {
        
        this.level = level;
        Save();
    }
    public void AddCoins(int coins)
    {
        this.coins += coins;
        Save();
    }
    private void Save()
    {
        ProgressData progressData = new ProgressData();
        progressData.level = level;
        progressData.coins = coins;
        string json=JsonUtility.ToJson(progressData);
        PlayerPrefs.SetString("Progress", json);
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("Progress"))
        {
            string json = PlayerPrefs.GetString("Progress");
            ProgressData progressData = JsonUtility.FromJson<ProgressData>(json);
            level = progressData.level;
            coins = progressData.coins;
        }
    }
}
