using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOldFilm2 : MonoBehaviour {
    #region Variables
    //old film shader
    public float OldFilmEffectAmount = 1.0f;
    public Shader curShader;
    public Color sepiaColor = Color.white;
    public Texture2D vignetteTexture;

    public float vignetteAmount = 1.0f;
    public Texture2D scratchesTexture;

    public float scratchesYSpeed = 10.0f;
    public float scratchesXSpeed = 10.0f;
    public Texture2D dustTextures;

    public float dustYSpeed = 10.0f;
    public float dustXSpeed = 10.0f;

    private Material screenMat;
    private float randomValue;

    #endregion

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (curShader != null)
        {
            screenMat.SetColor("_SepiaColor", sepiaColor);
            screenMat.SetFloat("_VignetteAmount", vignetteAmount);
            screenMat.SetFloat("_EffectAmount", OldFilmEffectAmount);
            if (vignetteTexture)
            {
                screenMat.SetTexture("_VignetteTex", vignetteTexture);
            }
            if (scratchesTexture)
            {
                screenMat.SetTexture("_ScratchesTex", scratchesTexture);
                screenMat.SetFloat("_ScratchesYSpeed", scratchesYSpeed);
                screenMat.SetFloat("_ScratchesXSpeed", scratchesXSpeed);
            }
            if (dustTextures)
            {
                screenMat.SetTexture("_DustText", dustTextures);
                screenMat.SetFloat("_dustYSpeed", dustYSpeed);
                screenMat.SetFloat("_dustXSpeed", dustXSpeed);
                screenMat.SetFloat("_RandomValue", randomValue);
            }
            Graphics.Blit(source, destination, screenMat);
         }else {
            Graphics.Blit(source, destination);
         }
    }
   
    void Update()
    {
        vignetteAmount = Mathf.Clamp01(vignetteAmount);
        OldFilmEffectAmount = Mathf.Clamp(OldFilmEffectAmount, 0f, 1.5f);
        randomValue = Random.Range(-1f, 1f);
    }
}
