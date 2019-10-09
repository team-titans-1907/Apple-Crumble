using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text name;
    public Text dialogue;

    public Image npc;

    public Animator animator;

    private Queue<string> lines;

    void Start()
    {
        lines = new Queue<string>();
    }

    public void StartSpeak (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        name.text = dialogue.name;
        npc.sprite = dialogue.talksprite;
        Debug.Log(npc.sprite);

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
        foreach (char letter in line.ToCharArray())
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
