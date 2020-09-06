using UnityEngine;
using UnityEditor;

public class EditModeFunctions : EditorWindow
{
    public Grid grid;

    [MenuItem("Window/Edit Mode Functions")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<EditModeFunctions>("Edit Mode Functions");
    }

    private void OnEnable()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Spawn Grid"))
        {
            SpawnGrid();
        }
    }

    void SpawnGrid()
    {
        if (grid.transform.childCount > 0)
        {
            Debug.LogError("Please delete all children of before generating a new grid");
            return;
        }
        Debug.Log("Generating grid");

        for (int j = 0; j < grid.Height; j++)
        {
            for (int i = 0; i < grid.Width; i++)
            {
                GameObject cellObject = Instantiate(grid.GridCell, new Vector3(i, j, 0f) + grid.offset, Quaternion.identity);
                cellObject.name = "Cell (" + i + "," + j + ")";
                cellObject.transform.parent = grid.transform;
            }
        }

    }
}
