using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWobblerCharacterResonating : TextWobbler
{

    [Range(0f, 10f)]
    public float resonanceRate;
    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < textMesh.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMesh.textInfo.characterInfo[i];

            int index = c.vertexIndex;

            Vector3 offset = Distort(Time.time + i)*Distort((Time.time + i)/resonanceRate);
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
}
