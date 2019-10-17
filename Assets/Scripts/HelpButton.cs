using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    public Animator animator;
    public GameObject panel;
    private GameObject[] itemHints;

    void Update()
    {
        if(animator.GetBool("IsOpen"))
        {
            panel.SetActive(false);
        }
    }

    public void ToggleHelp()
    {
        itemHints = GameObject.FindGameObjectsWithTag("Hint");
        foreach (GameObject hint in itemHints)
        {
            hint.SetActive(false);
        }

        if(!animator.GetBool("IsOpen"))
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
