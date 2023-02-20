using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour
{
    // Start is called before the first frame update

    public float spanSpeed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")){
            Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movementInput * spanSpeed * Time.deltaTime;
        }
    }
}
