using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskAnim : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] SpriteMask spriteMask;

    void Update()
    {
        spriteMask.sprite = sr.sprite;
    }
}
