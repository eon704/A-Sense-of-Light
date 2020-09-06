using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Blob : MonoBehaviour
{
    public Color color;
    Grid grid;
    public int x_coord;
    public int y_coord;

    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        x_coord = 0;
        y_coord = 0;

        grid.SetBlobIndex(this);
    }

}

public enum Color { RED, ORANGE, YELLOW, GREEN, SKYBLUE, SEABLUE, PURPLE };