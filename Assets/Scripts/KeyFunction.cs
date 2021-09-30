using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<KeyController>().claimKey();
            gameObject.SetActive(false);
        }
    }
}
