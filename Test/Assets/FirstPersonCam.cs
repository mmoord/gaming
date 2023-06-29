using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public Rigidbody rb;
    private float xRotation;
    private float yRotation;
    public Transform t;
    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        

    }

    float horizontalSpeed = 1000.0f;
    float verticalSpeed = 1000.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = t.position;

        float horizontal = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        float vertical = verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        yRotation += horizontal;
        xRotation -= vertical;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.eulerAngles = new Vector3(xRotation, yRotation, 0); 
        

        //print("Rotations" + transform.eulerAngles);
    }
}
