using UnityEngine;
using System.Collections;

public class SwipeInput : MonoBehaviour {

    #region Instance
    private static SwipeInput instance;
    public static SwipeInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeInput>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SwipeInput", typeof(SwipeInput)).GetComponent<SwipeInput>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion
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

    void Update()
    {
        tap = doubleTap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        UpdateMobile();
    }

    private void UpdateMobile()
    {


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;

            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            if (fingerDown.y - fingerUp.y > 0)
            {
				swipeUp = true;
            }
            else if (fingerDown.y - fingerUp.y < 0)
            {
				swipeDown = true;
            }
            fingerUp = fingerDown;
        }

        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0)
            {
				swipeRight = true;
            }
            else if (fingerDown.x - fingerUp.x < 0)
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
