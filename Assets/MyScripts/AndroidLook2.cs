using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidLook2 : MonoBehaviour {

    //Vector2 startPos;
    Vector2 direction;
    //Vector2 destination;
    private Touch initTouch;
    public Camera cam;
    float directionX;
    float directionY;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        foreach(Touch touch in Input.touches)
        {

            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }else if(touch.phase == TouchPhase.Moved)
            {
                directionX = initTouch.position.x - touch.position.x;
                directionY = initTouch.position.y - touch.position.y;
                direction = new Vector2(directionX, directionY);
                direction = (direction.magnitude > 1.0f) ? direction.normalized : direction;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
                direction = new Vector2();
            }

        }





        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
            
        //    switch (touch.phase)
        //    {
              
        //        case TouchPhase.Began:
                   
        //           startPos = touch.position;
                    


        //            break;

               
        //        case TouchPhase.Moved:
                  
        //           direction = touch.position - startPos;
        //           direction = (direction.magnitude > 1.0f) ? direction.normalized : direction;



        //            break;
   
        //    }

        //}
	}

    public float Horizontal()
    {
        if (direction.x!= 0)
            return direction.x;
        else
            return 0;


    }
    public float Vertical()
    {
        if (direction.y != 0)
            return direction.y;
        else
            return 0;


    }
}
