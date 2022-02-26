using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float currX;
    [SerializeField] float currY;

    [SerializeField] float worldYLimit = -10f;

    private void Start() {
        currX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = player.transform.position.x;

        currX += moveSpeed * Time.deltaTime;

        currY = player.transform.position.y;

        if (currY < worldYLimit)
        {
            currY = worldYLimit;
        }


        if (playerX <= currX)
        {

            transform.position = new Vector3(currX, currY, player.transform.position.z);

        } else {
            transform.position = new Vector3(playerX, currY, player.transform.position.z);
            currX = playerX;
        }



    }
}
