using UnityEngine;
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
        Debug.Log("totalSceneCount --> " + totalSceneCount);
    }


    void Update()
    {
        counter++;
        Debug.Log("THE CURRENT SCENE IS AT INDEX: " + currentSceneIndex);

        /*finger swiping*/

        if (Input.touchCount == 1 || Input.touchCount == 2)
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
                        Debug.Log("SCENE CHANGE RIGHT");
                        updateCurrentSceneIndex(true);
                    }
                    else
                    {
                        Debug.Log("SCENE CHANGE LEFT");
                        updateCurrentSceneIndex(false);
                    }
                    SceneManager.LoadScene(currentSceneIndex);
                }

            }
        }


        /*mouse drag*/

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


    //calculating distance between two coordinates
    private float calculateSwipeDistance()
    {
        return Mathf.Sqrt(Mathf.Pow(Mathf.Abs(lastTouch.x - firstTouch.x), 2) + Mathf.Pow(Mathf.Abs(lastTouch.y - firstTouch.y), 2));
    }

    private bool isSwipeRight()
    {
        return firstTouch.x < lastTouch.x;
    }


    //incrementing or decrementing scene index 
    private void updateCurrentSceneIndex(bool nextScreen)
    {
        //add the animator dialogue boolean in the if statement
        if (nextScreen && (currentSceneIndex < totalSceneCount - 1))
        {
            Debug.Log("current scene Index in if: " + currentSceneIndex);
            currentSceneIndex++;

        }
        //add the animator dialogue boolean in this else if statement 
        else if (currentSceneIndex > 0)
        {
            Debug.Log("current scene index in else: " + currentSceneIndex);
            currentSceneIndex--;
        }
    }
}