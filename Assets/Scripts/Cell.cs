using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isOccupied = false;
    public bool triggerCell = false;

    public bool isPortalCell = false;
    public Portal portal;

    private void Start()
    {
        if (!portal)
            isPortalCell = false;
        else
            isPortalCell = true;
    }


    public void SetOccupied()
    {
        isOccupied = true;
    }

    public void UnsetOccupied()
    {
        isOccupied = false;
    }
}
