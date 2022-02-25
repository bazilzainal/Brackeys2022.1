using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHorizontal : MonoBehaviour
{
    [SerializeField] float rightLimitMagnitude = 1;
    [SerializeField] float leftLimitMagnitude = 1;
    [SerializeField] float movementMagnitude = 1;
    float movement;
    float rightLimit;
    float leftLimit;

    void Start() {
        rightLimit = transform.position.x + rightLimitMagnitude;
        leftLimit = transform.position.x - 5 - leftLimitMagnitude;
        movement = 0.01f * movementMagnitude;
    }
    void Update()
    {
        // Makes enemy move within a certain position
        var pos = transform.position;
        if (pos.x <= leftLimit || pos.x >= rightLimit ) {
            movement *= -1;
        }
        pos.x += movement;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Remove enemy when camera moves on
        if (other.gameObject.tag == "Pusher") {
            Destroy(gameObject);
        }        
    }

}
