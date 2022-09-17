using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;

    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        createShape();
        updateMesh();
    }

    void createShape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0, 10, 0),
            new Vector3(10, 0, 0),
            new Vector3(0, 0, 10),
        };

        triangles = new int[]
        {
            0, 1, 2
        };
    }

    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
