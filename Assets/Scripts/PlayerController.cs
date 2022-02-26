using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float restartDelay = 2f;
    [SerializeField] private AudioSource deathSoundFx;

    GameManager gm;
    bool isDead = false;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        isDead = false;
    }

    // Triggers when player falls
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death" && !isDead)
        {
            KillPlayer();
        }
    }

    // Triggers on collision
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death" && !isDead)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        isDead = true;
        StartCoroutine(gm.ProcessPlayerDeath(restartDelay));
        deathSoundFx.Play();
        Debug.Log("DEATH CALLS");
    }
}
