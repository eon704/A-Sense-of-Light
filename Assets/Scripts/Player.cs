using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Grid grid;
    public Blob activeBlob;
    int activeBlobIndex;
    public List<Blob> blobs;

    public float moveDelay;
    float lastMoveTime;

    // Start is called before the first frame update
    void Start()
    {
        lastMoveTime = Time.time;

        if (blobs.Count <= 0)
            Debug.LogError("No blobs added to player");

        activeBlob = blobs[0];
        activeBlobIndex = 0;

        foreach (Blob blob in blobs)
        {
            grid.MoveBlob(blob, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Switch blob
        {
            activeBlobIndex = (activeBlobIndex + 1) % blobs.Count;
            activeBlob = blobs[activeBlobIndex];
            lastMoveTime = 0f;
        } 

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            lastMoveTime = 0f;
        }

        if (Time.time - lastMoveTime < moveDelay)
            return;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            grid.MoveBlob(activeBlob, 0, 1);
            lastMoveTime = Time.time;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            grid.MoveBlob(activeBlob, 0, -1);
            lastMoveTime = Time.time;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            grid.MoveBlob(activeBlob, -1, 0);
            lastMoveTime = Time.time;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            grid.MoveBlob(activeBlob, 1, 0);
            lastMoveTime = Time.time;
        }
    }
}
