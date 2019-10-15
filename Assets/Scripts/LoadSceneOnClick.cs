using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour
{
    //public Text playerDisplay;
    //private void Start()
    //{
    //    if (DBManager.LoggedIn)
    //    {
    //        playerDisplay.text = "Player:" + DBManager.username;
    //    }
    //}

    public void LoadByIndex(int sceneIndex)
    {
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
