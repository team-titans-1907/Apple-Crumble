using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public DialogueTrigger trigger;
    public Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("IsOpen"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //raycast takes in a ray and a direction
            if (Physics.Raycast(ray, out _))
            {
                trigger.TriggerDialogue();
            }
        }

    }
}
