using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float currX;

    private void Start() {
        currX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.transform.position.x;
        currX += moveSpeed * Time.deltaTime;


        if (playerX <= currX)
        {
            transform.position = new Vector3(currX, player.transform.position.y, player.transform.position.z);

        } else {
            transform.position = new Vector3(playerX, player.transform.position.y, player.transform.position.z);
            currX = playerX;
        }
        
    }
}
