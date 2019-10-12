using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logout : MonoBehaviour
{
  public void hasQuit()
    {
        Debug.Log("you have quit the game!");
        Application.Quit();
        SceneManager.LoadScene(0);
    }
}
