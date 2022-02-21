using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        if (horizontalInput != 0)
        {
            transform.Translate(new Vector3(horizontalInput * moveForce * Time.fixedDeltaTime, 0, 0));
        }

        if (verticalInput != 0)
        {
            transform.Translate(new Vector3(0, verticalInput * moveForce * Time.fixedDeltaTime, 0));
        }
    }
}
