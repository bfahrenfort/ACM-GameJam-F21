using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private float timer = 1.0f;
    public void RandomizeBlock()
    {
        if(timer < 0.0f)
        {
            timer = 1.0f;
            var random = new System.Random();
            this.transform.position = new Vector2(this.transform.position.x, ((float)random.Next(-400, 500)) / 100);
        }
        timer -= Time.deltaTime;
    }
}
