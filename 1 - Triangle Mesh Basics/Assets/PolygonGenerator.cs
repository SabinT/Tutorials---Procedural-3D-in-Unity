using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PolygonGenerator : MonoBehaviour
{
    public Material Mat;

    public int SideCount;

    public float Radius;
    
    // Start is called before the first frame update
    void Start()
    {
        var mesh = new TriangleMesh();
        
        // Create polygon
        Vector3 O = new Vector3(0, 0, 0);
        mesh.Vertices.Add(O);

        // Create vertices
        for (int side = 0; side < this.SideCount; side++)
        {
            float angle = side * 2 * Mathf.PI / this.SideCount;

            Vector3 P = new Vector3(this.Radius * Mathf.Cos(angle), 0, this.Radius * Mathf.Sin(angle));
            mesh.Vertices.Add(P);
        }

        // Create triangles
        // O = 0
        // P(i +1) = 1 + (i + 1) % sides
        // P(i) = 1 + i
        for (int i = 0; i < this.SideCount; i++)
        {
            mesh.Indices.Add(0);
            mesh.Indices.Add(1 + (i + 1) % this.SideCount); // P(i +1)
            mesh.Indices.Add(1 + i); // P(i)
        }

        var mr = this.GetComponent<MeshRenderer>();
        var mf = this.GetComponent<MeshFilter>();

        mf.mesh.SetVertices(mesh.Vertices);
        mf.mesh.SetIndices(mesh.Indices, MeshTopology.Triangles, 0);

        mr.material = this.Mat;
    }

}
