using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathHelp;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class FirstPersonMovement : MonoBehaviour
{
    Camera mainCam;
    Rigidbody rigidBody;

    public float maxSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        ClampVelocity();
    }

    void Move()
    {
        Vector2 moveInput = new Vector2();

        moveInput.x = Input.GetAxis("Horizontal"); //right/left
        moveInput.y = Input.GetAxis("Vertical"); //forward/backward

        Vector3 tempForward = mainCam.transform.forward;

        mainCam.transform.forward = Vector3.Normalize(new Vector3(tempForward.x, 0f, tempForward.z));

        Vector3 moveDir = mainCam.transform.TransformVector(new Vector3(moveInput.x, 0f, moveInput.y));

        mainCam.transform.forward = tempForward;

        rigidBody.AddForce(moveDir, ForceMode.VelocityChange);
    }

    //clamps the magnitude of our XZ movement to less than our max speed value
    void ClampVelocity()
    {
        Vector3 tempVel = rigidBody.velocity;

        Vector2 tempXZVel = MathHelpers.Clamp(new Vector2(tempVel.x, tempVel.z), maxSpeed);

        rigidBody.velocity = new Vector3(tempXZVel.x, tempVel.y, tempXZVel.y);
    }
}
