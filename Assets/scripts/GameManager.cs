using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Camera))]
public class GameManager : MonoBehaviour
{

    [FormerlySerializedAs("postprocessMaterial"), SerializeField]
    public Material PostprocessMaterial;

    public ComputeShader shader;
    public Shader depthShader;

    private Camera depthCam;
    private RenderTexture depthTex;

    private int noiseKernel;
    private RenderTexture tex;


    /// <summary>
    /// Start is called at the start of the game.
    /// We use it to initialize textures and shaders.
    /// </summary>
    private void Start()
    {
        depthCam = this.GetComponent<Camera>();
        depthCam.depthTextureMode = DepthTextureMode.Depth;

        noiseKernel = shader.FindKernel("Noise");
        tex = new RenderTexture(256, 256, 24, RenderTextureFormat.ARGB32) { enableRandomWrite = true };
        tex.Create();
        shader.SetTexture(noiseKernel, "Result", tex);
    }



    /// <summary>
    /// OnRenderImage is called after each Frame is rendered.
    /// We use it to replace the camera rendered image to our
    /// own image from the SIRDS shader.
    /// </summary>
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // noise shader
        //shader.Dispatch(noiseKernel, 256 / 8, 256 / 8, 1);
        //Graphics.Blit(tex, dest);

        Graphics.Blit(src, dest, PostprocessMaterial);
    }
}
