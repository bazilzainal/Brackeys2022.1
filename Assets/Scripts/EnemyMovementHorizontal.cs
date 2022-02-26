using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHorizontal : MonoBehaviour
{
    [SerializeField] float rightLimitMagnitude = 1;
    [SerializeField] float leftLimitMagnitude = 1;
    [SerializeField] float movementMagnitude = 30;
    Vector3 movement;
    float rightLimit;
    float leftLimit;

    Vector3 lastpos;

    float timeLimit = 0.5f;
    float lastCheckTime = 0;
    
    void Start() {
        rightLimit = transform.position.x + rightLimitMagnitude;
        leftLimit = transform.position.x - 5 - leftLimitMagnitude;
        movement = new Vector3(-movementMagnitude, 0, 0);
    }
    void Update()
    {
        // Makes enemy move within a certain position
        var pos = transform.position;

        // Update limit if enemy goes out of bounds
        if (pos.x <= leftLimit) {
            movement = -movement;
            leftLimit = pos.x;
        } else if (pos.x >= rightLimit) {
            movement = -movement;
            rightLimit = pos.x;
        }
        transform.position += movement * Time.deltaTime;

        // Change direction of enemy if stuck
        if (Time.time - lastCheckTime > timeLimit) {
            if (movement.x < 0) {
                if (pos.x - lastpos.x > movement.x) {
                    movement = -movement;
                    lastpos = transform.position;
                    lastCheckTime = Time.time;
                }
            } else {
                if (lastpos.x - pos.x < movement.x) {
                    movement = -movement;
                    lastpos = transform.position;
                    lastCheckTime = Time.time;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Remove enemy when camera moves on
        if (other.gameObject.tag == "Pusher") {
            Destroy(gameObject);
        }        
    }

}
