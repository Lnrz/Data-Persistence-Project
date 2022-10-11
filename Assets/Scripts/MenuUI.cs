using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField input;

    public void StartGame()
    {
        string username;

        username = input.text;
        if (username != "") 
        {
            DataPersistence.instance.username = username;
            SceneManager.LoadScene(1);
        }
    }
}
