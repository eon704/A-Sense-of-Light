using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isOccupied = false;
    public bool isButtonCell = false; 
    public ColorButton button;

    public bool isPortalCell = false;
    public Portal portal;

    private void Start()
    {
        if (!portal)
            isPortalCell = false;
        else
            isPortalCell = true;


        if (!button)
            isButtonCell = false;
        else
            isButtonCell = true;

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
