using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogManager : MonoBehaviour
{
    public Text availableName;
    public Text availableDesc;

    public Text activeName;
    public Text activeDesc;

    private Scene activeScene;

    void Start()
    {
        activeScene = SceneManager.GetActiveScene();

        if (activeScene.name == "FirstNPC" || activeScene.name == "QuestRejected")
        {
            availableName.text = "LUKE'S TUTORIAL";
            availableDesc.text = "LUKE KEEPS FALLING ASLEEP AT THE QUEEN'S SIDE. YOU SHOULD GO TALK TO THE POOR GUY.";

            activeName.text = "";
            activeDesc.text = "";
        }
        else if (activeScene.name == "QuestAccepted")
        {
            availableName.text = "";
            availableDesc.text = "";

            activeName.text = "LUKE'S TUTORIAL";
            activeDesc.text = "LUKE ASKED FOR HIS TOY, A SALAD, AND FOR YOU TO DROP IN ON HIS PET TIGER AT HOME. YOU THINK YOU HEARD HE LIVES NEAR COLUMBIA UNIVERSITY?";
        }
        else if (activeScene.name == "QuestPending")
        {
            availableName.text = "";
            availableDesc.text = "";

            activeName.text = "LUKE'S TUTORIAL";
            activeDesc.text = "YOU GOT LUKE'S TOY AMBULANCE, HIS CHIPOTLE SALAD, AND SAID HI TO MR. STRIPEY FOR HIM. YOU'RE SURE HE'LL BE THRILLED ONCE HE SEES YOU.";
        }
        else if (activeScene.name == "QuestComplete")
        {
            availableName.text = "DRAKE'S DILEMMA";
            availableDesc.text = "DRAKE THE DRAGON SEEMS SAD RECENTLY. HE SHOULD REALLY STOP DRINKING SO MANY VENTI PSL'S.";

            activeName.text = "";
            activeDesc.text = "";
        }
    }
}
