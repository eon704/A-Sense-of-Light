using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public Color activationColor;
    public bool activated;
    public GameObject activatable;
    public List<Cell> cellsToActivate;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;

        if (!activatable)
        {
            Debug.LogWarning("No activable object assigned");
        }

        Deactivate();
    }

    public void CheckBlob(Blob blob)
    {
        if (Vector3.Equals(blob.transform.position, transform.position))
        {
            if (blob.color == activationColor)
            {
                activated = true;
                Activate();
                return;
            }
        }
        Deactivate();
    }

    public void Activate()
    {
        activatable.SetActive(true);
        foreach (Cell cell in cellsToActivate)
        {
            cell.UnsetOccupied();
        }
    }

    public void Deactivate()
    {
        activatable.SetActive(false);
        foreach (Cell cell in cellsToActivate)
        {
            cell.SetOccupied();
        }
    }
}
