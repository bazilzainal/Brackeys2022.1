using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        if (horizontalInput != 0)
        {
            transform.Translate(new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0) + new Vector3(Random.Range(-0.05f,0.04f),0,0));
        }

        if (verticalInput != 0)
        {
            transform.Translate(new Vector3(0, verticalInput * moveSpeed * Time.deltaTime, 0) + new Vector3(0,Random.Range(-0.05f,0.04f),0));
        }
    }
}