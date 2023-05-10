using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public float moveSpeed = 5.0f; // speed at which to move the cube
public float moveDistance = 1.0f; // distance to move the cube
public KeyCode moveUpKey = KeyCode.W; // keyboard key to move the cube up
public KeyCode moveDownKey = KeyCode.S; // keyboard key to move the cube down
public KeyCode moveLeftKey = KeyCode.A; // keyboard key to move the cube left
public KeyCode moveRightKey = KeyCode.D; // keyboard key to move the cube right
private Vector3 targetPosition; // the target position to move the cube to
private bool isMoving = false; // flag indicating whether the cube is currently moving

void Update() {
    if (!isMoving) {
        if (Input.GetKeyDown(moveUpKey)) {
            targetPosition = transform.position + Vector3.forward * moveDistance;
            isMoving = true;
        }
        else if (Input.GetKeyDown(moveDownKey)) {
            targetPosition = transform.position + Vector3.back * moveDistance;
            isMoving = true;
        }
        else if (Input.GetKeyDown(moveLeftKey)) {
            targetPosition = transform.position + Vector3.left * moveDistance;
            isMoving = true;
        }
        else if (Input.GetKeyDown(moveRightKey)) {
            targetPosition = transform.position + Vector3.right * moveDistance;
            isMoving = true;
        }
    }

    MoveCube();
}

void MoveCube() {
    if (isMoving) {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        if (transform.position == targetPosition) {
            isMoving = false;
        }
    }
}


}
