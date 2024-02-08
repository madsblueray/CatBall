using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImageWobblerMesh : ImageWobbler
{

    void Update()
    {
        vertices = spriteRenderer.sprite.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector2 offset = Distort(Time.time + i);

            vertices[i] = vertices[i] + offset;
        }
        spriteRenderer.sprite.OverrideGeometry(vertices, spriteRenderer.sprite.triangles);
        //textMesh.canvasRenderer.SetMesh(mesh);
    }

    public override Vector2 Distort(float time)
    {
        return new Vector2(Mathf.Cos(time*x), Mathf.Sin(time*y))*amplitude;
    }
}
