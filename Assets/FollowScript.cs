using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    private float distToPlayer;
    [SerializeField] GameObject player;
    [SerializeField] float followSpeedMin = 10f;
    [SerializeField] float followSpeedMax = 20f;
    [SerializeField] float distanceAwayMin = 1f;
    [SerializeField] float distanceAwayMax = 3f;
    [SerializeField] float distanceError = 3f;
    [SerializeField] int countLimit = 5;
    int count = 0;
    float magDeltaLimit = 0;
    float followSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count>countLimit){
            magDeltaLimit = Random.Range(distanceAwayMin,distanceAwayMax);
            followSpeed = Random.Range(followSpeedMin,followSpeedMax);
            distToPlayer = Vector3.Distance(player.transform.position, transform.position) + Random.Range(-distanceError,distanceError);
            count = 0;
        }

        // float magDelta = (transform.position - player.transform.position).magnitude;
        if (distToPlayer > magDeltaLimit)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

        count++;
    }
}
