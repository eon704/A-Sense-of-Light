using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Grid grid;
    public Blob activeBlob;
    int activeBlobIndex;

    List<Blob> blobs;

    public CameraControl cameraControl;

    public GameObject key;
    public float distanceToPickUp;

    public GameStatus gameStatus;

    public float moveDelay;
    float lastMoveTime;

    // Start is called before the first frame update
    void Start()
    {
        blobs = grid.blobs;
        lastMoveTime = Time.time;

        SelectBlob(0);

        foreach (Blob blob in blobs)
        {
            grid.MoveBlob(blob, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check the key
        CheckKey();

        // Switch Blob
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SelectNextBlob();
            lastMoveTime = 0f;
        }

        // Zoom out on hold
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cameraControl.ZoomOut();
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            cameraControl.ZoomIn();
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

    void SelectNextBlob()
    {
        activeBlobIndex = (activeBlobIndex + 1) % blobs.Count;
        activeBlob = blobs[activeBlobIndex];
        cameraControl.UpdateFollowTarget(activeBlob.transform);
    }

    void SelectBlob(int index)
    {
        if (index >= blobs.Count)
        {
            Debug.LogWarning("Accessing out of range blob");
            return;
        }
        activeBlob = blobs[index];
        activeBlobIndex = index;
        cameraControl.UpdateFollowTarget(activeBlob.transform);
    }

    public void FocusOnActiveBlob()
    {
        cameraControl.UpdateFollowTarget(activeBlob.transform);
    }

    void CheckKey()
    {
        if (key == null)
        {
            return;
        }
        // Check proximity to the Key
        
        if (GetSqrDistanceTo(key.transform.position) < distanceToPickUp)
        {
            Destroy(key);
            Debug.Log("Found Key");
            gameStatus.FoundKey();
        }
    }

    float GetSqrDistanceTo(Vector3 target)
    {
        return (activeBlob.transform.position - target).sqrMagnitude;
    }
}
