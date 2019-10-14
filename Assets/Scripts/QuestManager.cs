using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    private GameObject[] questItems;
    private bool questCompleted;

    void Start()
    {
        questCompleted = false;
        questItems = GameObject.FindGameObjectsWithTag("Item");
    }

    public void CheckStatus()
    {
        int score = 0;
        if(!questCompleted)
        {
            foreach(GameObject item in questItems)
            {
                Image itemImg = item.GetComponent<Image>();
                if(itemImg.color == Color.white)
                {
                    score++;
                }
            }
            if(score == 3)
            {
                Debug.Log("Got all 3");
                questCompleted = true;
                PendingCompleteQuest();
            }
        }
    }

    public void PendingCompleteQuest()
    {
        SceneManager.LoadScene("QuestPending");
    }
}
