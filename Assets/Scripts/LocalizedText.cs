using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    [SerializeField]private string textEN;
    [SerializeField] private string textRU;
    
    void Start()
    {
        if (LanguageManager.Instance.currentLanguage == "ru")
        {
            GetComponent<TMP_Text>().text = textRU;
        }
        else
        {
            GetComponent<TMP_Text>().text = textEN;
        }
    }

    
}
