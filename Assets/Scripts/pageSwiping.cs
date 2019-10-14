﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class pageSwiping : MonoBehaviour
{
    public Vector3 firstTouch;
    public Vector3 lastTouch;
    public Vector3 userSwipe;
    private int currentSceneIndex = 0;
    private int totalSceneCount = 0;
    //public Animation animation;
    private static int counter = 0;

    //minimum length of swipe for the swipe to register
    private static float lengthOfSwipe = Screen.height * ((float)15.0 / 100);

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        totalSceneCount = SceneManager.sceneCountInBuildSettings;
    }


    void Update()
    {
        counter++;

        /*for swiping*/

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {

                lastTouch = touch.position;


                if (calculateSwipeDistance() >= lengthOfSwipe)
                {
                    if (isSwipeRight())
                    {
                        //updateCurrentSceneIndex(true);
                        SceneManager.LoadScene(currentSceneIndex + 1);
                    }
                    else
                    {
                        //updateCurrentSceneIndex(false);
                        SceneManager.LoadScene(currentSceneIndex - 1);
                    }
                    //SceneManager.LoadScene(currentSceneIndex);
                }

            }
        }


        /*for mouse drag*/

        //if (Input.GetMouseButtonDown(0)) //for first mouse click
        //{
        //    firstTouch = Input.mousePosition;
        //}

        //else if (Input.GetMouseButtonUp(0)) 
        //{
        //    lastTouch = Input.mousePosition;


        //    if (calculateSwipeDistance() >= lengthOfSwipe)
        //    {
        //        if (isSwipeRight())
        //        {
        //            Debug.Log("SCENE CHANGE RIGHT!");
        //            updateCurrentSceneIndex(true);       
        //        }
        //        else
        //        {
        //            Debug.Log("SCENE CHANGE LEFT!");
        //            updateCurrentSceneIndex(false);

        //        }
        //        SceneManager.LoadScene(currentSceneIndex);
        //    }
        //}

    }


    //calculating distance between first touch and second touch
    private float calculateSwipeDistance()
    {
        return Mathf.Sqrt(Mathf.Pow(Mathf.Abs(lastTouch.x - firstTouch.x), 2)
            + Mathf.Pow(Mathf.Abs(lastTouch.y - firstTouch.y), 2));
    }



    private bool isSwipeRight()
    {
        return firstTouch.x > lastTouch.x;
    }



    private void updateCurrentSceneIndex(bool nextScreen)
    {
        if (nextScreen && (currentSceneIndex < totalSceneCount - 1))
        {
            currentSceneIndex++;

        }
        else if (currentSceneIndex > 0)
        {
            currentSceneIndex--;
        }
    }
}