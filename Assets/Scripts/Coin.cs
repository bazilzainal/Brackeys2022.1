using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool isPickedUp = false;
    // Start is called before the first frame update
    [SerializeField] private Animator anim;

    public void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void pickUp() {
        isPickedUp = true;
        anim.enabled = false;

    }

    public bool getPickUpStatus() {
        return isPickedUp;
    }
}
