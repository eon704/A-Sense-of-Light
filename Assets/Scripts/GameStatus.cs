using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public GameObject closedPortal;
    public GameObject openPortal;
    public bool foundKey;

    private void Start()
    {
        foundKey = false;
    }

    public void FoundKey()
    {
        foundKey = true;
    }

    public void TryToOpenPortal()
    {
        if (foundKey)
        {
            LevelComplete();
        } else
        {
            Debug.Log("No Key...");
        }
    }

    public void LevelComplete()
    {
        closedPortal.SetActive(false);
        openPortal.SetActive(true);
        Debug.Log("Win");
    }
}
