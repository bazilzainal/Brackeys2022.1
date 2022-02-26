using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] float restartDelay = 2f;
    [SerializeField] private AudioSource deathSoundFx;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death")
        {
            deathSoundFx.Play();
            gm.Invoke("Restart", restartDelay);
            // gm.Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Death")
        {
            deathSoundFx.Play();
            gm.Invoke("Restart", restartDelay);

        }
    }
}
