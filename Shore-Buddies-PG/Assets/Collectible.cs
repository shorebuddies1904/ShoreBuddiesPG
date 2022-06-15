using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool isCollected = false;

    public bool Collect()
    {
        if(isCollected)
            return false;

        isCollected = true;
        Destroy(gameObject);
        return true;
    }
}
