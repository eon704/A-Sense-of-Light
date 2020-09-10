using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Color activationColor;
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    public bool CheckBlob(Blob blob)
    {
        if (Vector3.Equals(blob.transform.position, transform.position))
        {
            if (blob.color == activationColor)
            {
                activated = true;
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
        activated = false;
    }
}
