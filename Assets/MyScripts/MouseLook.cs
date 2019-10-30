﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MouseLook : MonoBehaviour{
   public AndroidLook _androidLook;

    
    
    bool ButtonClick = false;
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 1.0f;
    public float sensitivityVert = 1.0f;

    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;
    private float _rotationX = 0.0f;
	void Start () {
       
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null) {body.freezeRotation = true;}
	}
	
	
	void Update () {
        if (axes == RotationAxes.MouseX)
        {
           // transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            transform.Rotate(0, _androidLook.Horizontal() * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= _androidLook.Vertical() * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= _androidLook.Vertical() * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = _androidLook.Horizontal() * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

    }
  
    


    }
