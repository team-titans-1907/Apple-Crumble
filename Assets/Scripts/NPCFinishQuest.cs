using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCFinishQuest : MonoBehaviour
{
    public DialogueTrigger trigger;
    public Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("IsOpen"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _))
            {
                SceneManager.LoadScene("QuestComplete");
            }
        }

    }
}
