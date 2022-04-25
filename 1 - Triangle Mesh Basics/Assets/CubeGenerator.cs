using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CubeGenerator : MonoBehaviour
{
    public Material Mat;
    
    // Start is called before the first frame update
    void Start()
    {
        var mesh = new TriangleMesh();
        
        // Create cube
        mesh.Vertices.Add(new Vector3(0,1,1));
        mesh.Vertices.Add(new Vector3(1,1,1));
        mesh.Vertices.Add(new Vector3(1,1,0));
        mesh.Vertices.Add(new Vector3(0,1,0));
        
        mesh.Vertices.Add(new Vector3(0,0,1));
        mesh.Vertices.Add(new Vector3(1,0,1));
        mesh.Vertices.Add(new Vector3(1,0,0));
        mesh.Vertices.Add(new Vector3(0,0,0));
        
        mesh.Indices.AddRange(new [] { 0,1,2 });
        mesh.Indices.AddRange(new [] { 0,2,3 });

        mesh.Indices.AddRange(new [] { 1,0,4 });
        mesh.Indices.AddRange(new [] { 5,1,4 });

        mesh.Indices.AddRange(new [] { 2,1,5 });
        mesh.Indices.AddRange(new [] { 2,5,6 });

        mesh.Indices.AddRange(new [] { 3,2,7 });
        mesh.Indices.AddRange(new [] { 2,6,7 });

        mesh.Indices.AddRange(new [] { 5,4,6 });
        mesh.Indices.AddRange(new [] { 6,4,7 });

        mesh.Indices.AddRange(new [] { 0,3,4 });
        mesh.Indices.AddRange(new [] { 4,3,7 });

        var mr = this.GetComponent<MeshRenderer>();
        var mf = this.GetComponent<MeshFilter>();

        mf.mesh.SetVertices(mesh.Vertices);
        mf.mesh.SetIndices(mesh.Indices, MeshTopology.Triangles, 0);

        mr.material = this.Mat;
    }

}