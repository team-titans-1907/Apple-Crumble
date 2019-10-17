using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconHints : MonoBehaviour
{
    public GameObject panel;
    public GameObject otherPanel;
    public GameObject anotherPanel;
    public Animator animator;

    private void Update()
    {
        if(animator.GetBool("IsOpen"))
        {
            panel.SetActive(false);
        }
    }

    public void TogglePanel()
    {
        otherPanel.SetActive(false);
        anotherPanel.SetActive(false);
        GameObject help = GameObject.Find("HelpPanel");
        if(help)
        {
            help.SetActive(false);
        }

        Image icon = GetComponent<Image>();
        if(icon.color != Color.white && !animator.GetBool("IsOpen"))
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }
    
}
