using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]


public class FPSMove : MonoBehaviour {
    //Control



    [SerializeField] private float speedPlayer =10f;
    [SerializeField] private float jumpGravity= 100f;
    [SerializeField]private float gravityPlayer = -10f;
    float deltaX = 0.0f;
    float deltaZ = 0.0f;
    private CharacterController _charController;
    public VirtualJoyStick _JoyStick;

	void Start () {
        _charController = GetComponent<CharacterController>();
       

    }
	

	void Update () {


        //float deltaX = Input.GetAxis("Horizontal") * speedPlayer;
        //float deltaZ = Input.GetAxis("Vertical") * speedPlayer;
        
         deltaX = _JoyStick.Horizontal() * speedPlayer;
         deltaZ = _JoyStick.Vertical() * speedPlayer;
        Vector3 movePlayer = new Vector3(deltaX, gravityPlayer, deltaZ);
        movePlayer = Vector3.ClampMagnitude(movePlayer, speedPlayer);
        movePlayer *= Time.deltaTime;

        movePlayer = transform.TransformDirection(movePlayer);
        _charController.Move(movePlayer);


        //if (_charController.isGrounded && Input.GetButton("Jump"))
        //{
        //    movePlayer.y = jumpGravity;
        //    movePlayer.y -= gravityPlayer * Time.deltaTime;
        //    _charController.Move(movePlayer * Time.deltaTime);
        //}

    }
   
}
