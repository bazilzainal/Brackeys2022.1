using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float restartDelay = 2f;
    [SerializeField] float finishDelay = 1f;
    [SerializeField] private AudioSource deathSoundFx;
    [SerializeField] private AudioSource coinSoundFx;

    GameManager gm;
    bool isDead = false;

    void Awake()
    {
        isDead = false;
    }

    private void Start()
    {
        gm = GameObject.Find("SessionManager").GetComponent<GameManager>();
        
    }
    // Triggers when player falls
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death" && !isDead)
        {
            KillPlayer();
        }

        if (other.gameObject.tag == ("Coin")) {
            Coin coin = other.gameObject.GetComponent<Coin>();
            getCoin(other, coin);
            coinSoundFx.Play();
        } 

        if (other.tag == "FinishTag")
        {
            Debug.Log("Finish game!");
            StartCoroutine(gm.FinishLevel(finishDelay));
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

    private void getCoin(Collider2D other, Coin coin) {
        if (coin.getPickUpStatus()) return;
            coin.pickUp(); // Set coin's pick up status to true
            gm.addScore(10);
            Destroy(other.gameObject); //Remove coin gameObject that was pickedup
    }

    private void KillPlayer()
    {
        isDead = true;
        StartCoroutine(gm.ProcessPlayerDeath(restartDelay));
        deathSoundFx.Play();
        Debug.Log("DEATH CALLS");
    }
}
