using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Rigidbody crb;
    private Vector3 playerVelocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            Vector3 left_Right = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            crb.MovePosition(transform.position + left_Right * Time.deltaTime * 5f);
            //crb.AddForce(Vector3.forward * 1f, ForceMode.Impulse);
        }
        if (Input.GetKey("up") || Input.GetKey("down"))
        {
            Vector3 forward_Back = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            crb.MovePosition(transform.position + forward_Back * Time.deltaTime * 5f);
            //crb.AddForce(Vector3.right * 1f, ForceMode.Impulse);
        }
        if (Input.GetKey("space"))
        {
            //crb.AddForce(Vector3.up * 0.01f, ForceMode.Impulse);
        }
    }
}
