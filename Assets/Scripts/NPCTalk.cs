using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public DialogueTrigger trigger;
    public Animator animator;

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary && !animator.GetBool("IsOpen"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out _))
                {
                    trigger.TriggerDialogue();
                }
            }
        }
    }
}
