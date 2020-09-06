using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isOccupied = false;

    public void SetOccupied()
    {
        isOccupied = true;
    }

    public void UnsetOccupied()
    {
        isOccupied = false;
    }
}
