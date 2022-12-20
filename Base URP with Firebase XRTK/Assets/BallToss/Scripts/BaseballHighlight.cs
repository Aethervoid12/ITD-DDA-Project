using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballHighlight : MonoBehaviour
{
    //Function for highlight when enter hovered.
    public void OnHover()
    {
        //Get all the renderers of this object
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach(MeshRenderer renderer in meshRenderers)
        {
            //Enables the property of the renderer's material
            renderer.material.EnableKeyword("_EMISSION");
        }
    }
    //Function to stop highlight when exit hovered.
    public void ExitHover()
    {
        //Get all the renderers of this object
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer renderer in meshRenderers)
        {
            //Disables the property of the renderer's material
            renderer.material.DisableKeyword("_EMISSION");
        }
    }

}
