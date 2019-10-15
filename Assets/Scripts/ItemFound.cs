using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ItemFound: MonoBehaviour, ITrackableEventHandler
{
    public Animator animator;
    public DialogueTrigger trigger;

    private TrackableBehaviour mTrackableBehaviour;
    private bool hasFound;
    private GameObject npcItem;
    private UnityEngine.UI.Image npcImage;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        hasFound = false;
    }

    void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName +
                  " " + mTrackableBehaviour.CurrentStatus +
                  " -- " + mTrackableBehaviour.CurrentStatusInfo);

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    void OnTrackingFound()
    {
        if (mTrackableBehaviour.TrackableName == "spades")
        {
            npcItem = GameObject.Find("Item1");
        }
        if (mTrackableBehaviour.TrackableName == "chipotle")
        {
            npcItem = GameObject.Find("Item2");
        }

        if (mTrackableBehaviour.TrackableName == "joker")
        {
            npcItem = GameObject.Find("Item3");
        }
        if (mTrackableBehaviour && !animator.GetBool("IsOpen"))
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Enable rendering:
            foreach (var component in rendererComponents)
                component.enabled = true;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;

            if (!hasFound)
            {
                npcImage = npcItem.GetComponent<UnityEngine.UI.Image>();
                npcImage.color = Color.white;

                npcItem.BroadcastMessage("TogglePanel");

                hasFound = true;

                trigger.TriggerDialogue();
                FindObjectOfType<QuestManager>().UpdateStatus();
            }

        }
    }

    void OnTrackingLost()
    {
        if (mTrackableBehaviour)
        {
            var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
            var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
            var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

            // Disable rendering:
            foreach (var component in rendererComponents)
                component.enabled = false;

            // Disable colliders:
            foreach (var component in colliderComponents)
                component.enabled = false;

            // Disable canvas':
            foreach (var component in canvasComponents)
                component.enabled = false;
        }
    }
}
