using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public Animator animator;
    private GameObject[] questItems;
    private bool questCompleted;

    void Start()
    {
        questCompleted = false;
    }

    void LateUpdate()
    {
        if(CheckStatus() && !animator.GetBool("IsOpen"))
        {
            PendingCompleteQuest();
        }
    }

    public void UpdateStatus()
    {
        questItems = GameObject.FindGameObjectsWithTag("Item");
        int score = 0;
        if (!questCompleted)
        {
            foreach (GameObject item in questItems)
            {
                Image itemImg = item.GetComponent<Image>();
                if (itemImg.color == Color.white)
                {
                    score++;
                }
            }
            if (score == 3)
            {
                questCompleted = true;
            }
        }
        return;
    }

    private bool CheckStatus()
    {
        return questCompleted;
    }

    public void PendingCompleteQuest()
    {
        SceneManager.LoadScene("QuestPending");
    }

    public void CompleteQuest()
    {
        SceneManager.LoadScene("QuestComplete");
    }
}
