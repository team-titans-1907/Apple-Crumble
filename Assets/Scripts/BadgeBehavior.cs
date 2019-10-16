using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadgeBehavior : MonoBehaviour
{
    public GameObject panel;
	private Scene activeScene;

    void Start()
	{
		activeScene = SceneManager.GetActiveScene();
		if (activeScene.name != "QuestComplete")
		{
            GameObject badge = GameObject.Find("Badge");
            if (badge)
            {
                badge.SetActive(false);
            }
		}
	}

    public void OpenPanel()
    {
        if(panel != null)
            {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }
}
