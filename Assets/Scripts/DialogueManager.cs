using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text name;
    public Text dialogue;

    public Image npc;

    public Animator animator;

    private Queue<string> lines;

    private Scene activeScene;

    public Dialogue startDialogue;
    private bool talkedTo;

    private GameObject acceptButton;
    private GameObject rejectButton;

    void Start()
    {
        lines = new Queue<string>();
        activeScene = SceneManager.GetActiveScene();

        if(activeScene.name == "FirstNPC" || activeScene.name == "QuestRejected")
        {
            acceptButton = GameObject.Find("AcceptButton");
            rejectButton = GameObject.Find("RejectButton");

            acceptButton.SetActive(false);
            rejectButton.SetActive(false);
        }

        if (activeScene.name != "FirstNPC")
        {
            talkedTo = false;
            StartSpeak(startDialogue);
        }
    }

    public void StartSpeak (Dialogue dialogue)
    {
        if(!animator.GetBool("IsOpen"))
        {
            animator.SetBool("IsOpen", true);
        }

        name.text = dialogue.name;
        npc.sprite = dialogue.talksprite;

        lines.Clear();

        foreach (string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if(lines.Count == 0)
        {
            if (activeScene.name == "FirstNPC")
            {
                acceptButton.SetActive(true);
                rejectButton.SetActive(true);
                return;
            }
            if(activeScene.name != "FirstNPC")
            {
                if(!talkedTo)
                {
                    talkedTo = true;
                    EndSpeak();
                    return;
                }
                if(talkedTo && activeScene.name == "QuestRejected")
                {
                    acceptButton.SetActive(true);
                    rejectButton.SetActive(true);
                    return;
                }
            }

            EndSpeak();
            return;
        }

        string line = lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine (string line)
    {
        dialogue.text = "";
        foreach (char letter in line)
        {
            dialogue.text += letter;
            yield return null;
        }
    }

    void EndSpeak()
    {
        animator.SetBool("IsOpen", false);
    }
}
