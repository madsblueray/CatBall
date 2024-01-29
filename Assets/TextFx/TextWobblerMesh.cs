using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWobblerMesh : TextWobbler
{

    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Distort(Time.time + i);

            vertices[i] = vertices[i] + offset;
        }

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }

    public override Vector2 Distort(float time)
    {
        return new Vector2(Mathf.Cos(time*x), Mathf.Sin(time*y))*amplitude;
    }
}
