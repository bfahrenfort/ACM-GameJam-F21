using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public void RandomizeBlock()
    {
        var random = new System.Random();
        transform.position = new Vector2(transform.position.x, ((float)random.Next(-400, 500)) / 100);
    }
}
