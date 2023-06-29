using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class Movement : MonoBehaviour
{
    // Set Variable Types \\
    public Rigidbody rb;
    public Camera cam;
    private Vector3 playerVelocity;
    public Transform t;
    private float moveSpeed = 3.2f;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    float yforce = 0;
    float ydistance;
    public bool Awareness;
    private float _playerDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
    }

    
    private void MyInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }


    private void MovePlayer() {
        // Accounts for XZ Plane Movement
        moveDirection = t.forward * verticalInput + t.right * horizontalInput;
        moveDirection[1] = 0;
        // Debug.Log("Vector3 NEW" + moveDirection);
        rb.AddForce(moveDirection.normalized * moveSpeed * 30f, ForceMode.Force);

        // Checks/Executes if Character Can Jump
        ydistance = JumpCam();
        if (Input.GetKey("space") && (ydistance <= 1.1 && ydistance != 0)) {
            yforce = 15;
            rb.AddForce(0, yforce, 0, ForceMode.Impulse);
        }

        if (ydistance <= 1.1) {
            rb.drag = 5;
        } else
        {
            rb.drag = 4.5f;
        }
    }

    private float JumpCam() {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, Mathf.Infinity))
        {
             Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.green);
            return hit.distance;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * 1000, Color.red);
            return 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyInput();
        MovePlayer();   
    }
}
