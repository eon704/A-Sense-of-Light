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

    public void CheckBlob(Blob blob)
    {
        if (Vector3.Equals(blob.transform.position, transform.position))
        {
            if (blob.color == activationColor)
            {
                activated = true;
                return;
            }
        }
        activated = false;
    }

}
