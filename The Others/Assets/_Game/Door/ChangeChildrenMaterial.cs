using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChildrenMaterial : MonoBehaviour
{
    public Material newMaterial;

    public void ChangeMaterial()
    {
        MeshRenderer[] childrenRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer renderer in childrenRenderers)
        {
            renderer.material = newMaterial;
        }
    }
}
