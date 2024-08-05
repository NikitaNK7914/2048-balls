using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(Load), 2f);
    }

    void Load()
    {
        SceneManager.LoadScene(1);
    }
}
