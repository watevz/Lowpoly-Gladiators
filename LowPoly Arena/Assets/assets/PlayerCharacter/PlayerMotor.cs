using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

    void Awake ()
    {
        // Set up references.
        playerRigidbody = GetComponent <Rigidbody> ();
    }

    public void Move (Vector3 direction, float moveSpeed)
    {
        // Normalise the movement vector and make it proportional to the speed per second.
        Vector3 movement = direction.normalized * moveSpeed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition (transform.position + movement);
    }

    public void TurnToFace (Vector3 mousePosition)
    {
        // Create a vector from the player to the point on the floor the raycast from the mouse hit.
        Vector3 playerToMouse = mousePosition - transform.position;

        // Ensure the vector is entirely along the floor plane.
        playerToMouse.y = 0f;

        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
        Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

        // Set the player's rotation to this new rotation.
        playerRigidbody.MoveRotation (newRotation);
    }
}