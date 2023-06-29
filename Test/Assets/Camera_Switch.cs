using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    


public class Camera_Switch : MonoBehaviour
{
    public GameObject POV;
    public GameObject Main_Camera;
    // Start is called before the first frame update
    void Start()
    {
        POV = GameObject.Find("POV");
        Main_Camera = GameObject.Find("Main_Camera");
        POV.GetComponent<Camera>().enabled = true;
        Main_Camera.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (POV.GetComponent<Camera>().enabled == true && Input.GetKey("e")){
            POV.GetComponent<Camera>().enabled = false;
            Main_Camera.GetComponent<Camera>().enabled = true;
            
        }
        else if (Main_Camera.GetComponent<Camera>().enabled == true && Input.GetKey("e"))
        {
            Main_Camera.GetComponent<Camera>().enabled = false;
            POV.GetComponent<Camera>().enabled = true;
        }


    }
}
