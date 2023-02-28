using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.GetComponent<Rigidbody>().position.x, transform.position.y, transform.position.z);
    }
}
