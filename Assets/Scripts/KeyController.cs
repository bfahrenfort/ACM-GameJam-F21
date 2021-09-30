using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int NumberOfKeys = 0;
    private int CurrentNumKeys;

    private void Start()
    {
        CurrentNumKeys = NumberOfKeys;
    }
    public void claimKey()
    {
        CurrentNumKeys -= 1;
    }
    public void resetKey()
    {
        CurrentNumKeys = NumberOfKeys;
    }
    public bool AllKeysCollected()
    {
        if (CurrentNumKeys == 0)
            return true;
        else
            return false;
    }
}
