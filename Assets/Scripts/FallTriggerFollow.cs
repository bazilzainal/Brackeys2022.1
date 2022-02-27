using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTriggerFollow : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
