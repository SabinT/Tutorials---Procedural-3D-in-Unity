using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TriangleGenerator : MonoBehaviour
{
    public Material Mat;
    
    // Start is called before the first frame update
    void Start()
    {
        // Generate Triangle
        Vector3 A = new Vector3(3, 0, 5);
        Vector3 B = new Vector3(6, 0, 0);
        Vector3 C = new Vector3(0, 0, 0);

        TriangleMesh mesh = new TriangleMesh();
        mesh.Vertices.Add(A);
        mesh.Vertices.Add(B);
        mesh.Vertices.Add(C);

        mesh.Indices.Add(0);
        mesh.Indices.Add(1);
        mesh.Indices.Add(2);

        var mr = this.GetComponent<MeshRenderer>();
        var mf = this.GetComponent<MeshFilter>();

        mf.mesh.SetVertices(mesh.Vertices);
        mf.mesh.SetIndices(mesh.Indices, MeshTopology.Triangles, 0);

        mr.material = this.Mat;
    }
}
