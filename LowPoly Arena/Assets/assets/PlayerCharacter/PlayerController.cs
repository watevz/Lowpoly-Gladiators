using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    PlayerState playerState;
    Animator anim;                      // Reference to the animator component.
    PlayerMotor motor;
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    void Awake ()
    {
        // set initial state
        playerState = new PlayerState();
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");

        // Set up references.
        anim = GetComponent <Animator> ();
        motor = GetComponent<PlayerMotor>();
    }


    void Update ()
    {
        HandleInput();
    }

    void HandleInput() {
        //check for key presses
        if (Input.GetKeyDown(KeyCode.W))
        {
            motor.Move(Vector3.forward, playerState.moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            motor.Move(Vector3.back, playerState.moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            motor.Move(Vector3.right, playerState.moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            motor.Move(Vector3.left, playerState.moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            
        }

        // tell the motor to update character facing
         // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            motor.TurnToFace(floorHit.point);
        }
    }
}
