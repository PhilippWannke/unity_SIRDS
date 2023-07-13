using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public ComputeShader shader;

    private void OnPostRender()
    {

        Debug.Log("exec");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Debug.Log("exec");
        int kernelHandle = shader.FindKernel("CSMain");

        RenderTexture tex = new RenderTexture(256, 256, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
        tex.enableRandomWrite = true;
        tex.Create();

        shader.SetTexture(kernelHandle, "Result", tex);
        shader.Dispatch(kernelHandle, 256 / 8, 256 / 8, 1);

        Graphics.Blit(tex, dest);
    }
}
