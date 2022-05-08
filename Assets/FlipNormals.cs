using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System.Linq;

public class FlipNormals : MonoBehaviour
{
    public KeyCode keyFlip;
    
    [ContextMenu( "Flip" )]
    public void FlipMeshContext ( ) {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh. triangles = mesh. triangles. Reverse( ). ToArray( );
    }

    public void Update()
    {
        if (Input.GetKeyDown(keyFlip))
        {
            FlipMeshContext();
        }
    }
}
