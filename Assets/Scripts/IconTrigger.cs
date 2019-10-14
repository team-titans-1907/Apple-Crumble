using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconTrigger : MonoBehaviour
{
    public Animator animator;
    private GameObject[] itemIcons;
    private bool talkedTo;
    private Scene activeScene;

    void Start()
    {
        itemIcons = GameObject.FindGameObjectsWithTag("Item");
        activeScene = SceneManager.GetActiveScene();

        if(activeScene.name == "QuestAccepted")
        {
            foreach (GameObject item in itemIcons)
            {
                item.SetActive(false);
            }
        }
        else
        { 
            foreach (GameObject item in itemIcons)
            {
                item.SetActive(true);
            }
        }

        talkedTo = false;
    }

    void Update()
    {
        if(!talkedTo && !animator.GetBool("IsOpen") && activeScene.name != "QuestPending")
        {
            talkedTo = true;
            ToggleIcons();
        }
    }

    public void ToggleIcons()
    {
        foreach (GameObject item in itemIcons)
        {
            item.SetActive(!item.activeSelf);
        }
    }
}
