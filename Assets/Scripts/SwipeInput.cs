using UnityEngine;
using System.Collections;

public class SwipeInput : MonoBehaviour {
private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;
	
	private bool tap, doubleTap, swipeLeft, swipeRight, swipeUp, swipeDown;

	public bool Tap{get{return tap;}}
    public bool DubleTap{get{return doubleTap;}}
    public bool SwipeLeft {get{return swipeLeft;}}
    public bool SwipeRight {get{return swipeRight;}}
    public bool SwipeUp {get{return swipeUp;}}
    public bool SwipeDown {get{return swipeDown;}}

    // Update is called once per frame
    void Update()
    {
		tap = doubleTap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }
            /*
            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }
            */
            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
				swipeUp = true;
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
				swipeDown = true;
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
				swipeRight = true;
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
				swipeLeft = true;
            }
            fingerUp = fingerDown;
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }


}
