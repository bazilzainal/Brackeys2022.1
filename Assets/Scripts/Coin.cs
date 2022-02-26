using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool isPickedUp = false;
    // Start is called before the first frame update

    public void pickUp() {
        isPickedUp = true;
    }

    public bool getPickUpStatus() {
        return isPickedUp;
    }
}
