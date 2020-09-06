using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grid : MonoBehaviour
{

    public int Width, Height;
    public GameObject GridCell;
    public bool GenerateGrid = false;
    public Vector3 offset;

    GameObject[,] gridArray;
    
    Cell[,] cellArray;

    // Start is called before the first frame update
    void Awake()
    {
        gridArray = new GameObject[Width, Height];
        cellArray = new Cell[Width, Height];
        
        if (GenerateGrid)
        {
            SpawnGrid();

        }

        // Load Game objects
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject cell = transform.GetChild(i).gameObject;
            string coordinate = cell.name.Substring(6);
            coordinate = coordinate.Remove(coordinate.Length - 1);
            string[] xy = coordinate.Split(',');

            int x = int.Parse(xy[0]);
            int y = int.Parse(xy[1]);

            //Debug.Log("X: " + x + "; Y:" + y);
            gridArray[x, y] = cell;
            cellArray[x, y] = cell.GetComponent<Cell>();
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveBlob(Blob blob, int h_units, int v_units)
    {
        int x = blob.x_coord;
        int y = blob.y_coord;

        int new_x = x + h_units;
        int new_y = y + v_units;

        if (new_x < 0 || new_x >= Width || new_y < 0 || new_y >= Height) // out of bounds
            return;

        if (cellArray[new_x, new_y].isOccupied)
        {
           return;
        }
        else
        {
            cellArray[x, y].UnsetOccupied();
            blob.transform.position = new Vector3(new_x, new_y, 0) + offset;
            blob.x_coord += h_units;
            blob.y_coord += v_units;
            cellArray[new_x, new_y].SetOccupied();

        }
    }

    public void SetBlobIndex(Blob blob)
    {
        Vector3 coord = blob.transform.position - offset;

        if (Mathf.Round(coord.x) != coord.x || Mathf.Round(coord.y) != coord.y)
            Debug.LogWarning("Blob is not aligned to grid");

        if (coord.x < 0 || coord.x >= Width || coord.y < 0 || coord.y >= Height) // out of bounds
            return;

        int new_x = (int)coord.x;
        int new_y = (int)coord.y;

        blob.x_coord = new_x;
        blob.y_coord = new_y;

        if (cellArray[new_x, new_y].isOccupied)
        {
            Debug.LogWarning("Multiple Blobs on the same coordinate");
            return;
        }
        cellArray[new_x, new_y].SetOccupied();
    }

    Vector3 IndexToWorldPoint(int x, int y)
    {
        return gridArray[x, y].transform.position;
    }

    Vector2 WorldPointToIndex(Vector3 transformPosition)
    {
        Vector3 correctedVector = transformPosition - offset;
        return new Vector2(correctedVector.x, correctedVector.y);
    }

    void SpawnGrid()
    {
        if (transform.childCount > 0)
        {
            Debug.LogError("Please delete all children of before generating a new grid");
            return;
        }

        for (int j = 0; j < Height; j++)
        {
            for (int i = 0; i < Width; i++)
            {
                GameObject cellObject = Instantiate(GridCell, new Vector3(i, j, 0f) + offset, Quaternion.identity);
                cellObject.name = "Cell (" + i + "," + j + ")";
                cellObject.transform.parent = gameObject.transform;

                gridArray[i, j] = cellObject;
            }
        }
        GenerateGrid = false;

        AssignCells();
    }

    void AssignCells()
    {
        for (int j = 0; j < Height; j++)
        {
            for (int i = 0; i < Width; i++)
            {
                
                cellArray[i, j] = gridArray[i, j].GetComponent<Cell>();
            }
        }
    }
}
