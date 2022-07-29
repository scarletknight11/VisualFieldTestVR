using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class BoxBlur : MonoBehaviour {

    [SerializeField] private Shader shader;
    
    [Range(2, 100)][SerializeField] private int iterations = 10;

    [Range(0, 1)][SerializeField] private float neighborhoodSize = 1f;
    
    private Material material;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //if the material is empty
        if(material == null)
            //apply shader
            material = new Material(shader);
        

        //Simple Blur Effect
        material.SetInt("_Iterations", iterations);
        material.SetFloat("neighborhoodSize", neighborhoodSize);

        // Setting a texture in order to render first the first shader pass
        // then at the end render onto the destination
        var tmp = RenderTexture.GetTemporary(source.width, source.height);
        Graphics.Blit(source, tmp, material, 0);
        Graphics.Blit(tmp, destination, material, 1);
        RenderTexture.ReleaseTemporary(tmp);
    }
}
