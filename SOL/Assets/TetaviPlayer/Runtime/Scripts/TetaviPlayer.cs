using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using static TetaviCAPI;

public class TetaviPlayer : TetaviPlayerBase
{
    Mesh meshNext = null;
    int meshNextSid;
    int workingTex = 0;
    

    new protected void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void CreateStreamDecoder()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying) 
        { 
            base.CreateStreamDecoder(); 
            return; 
        }
#endif
        AudioSource audioPlayer = gameObject.GetComponent<AudioSource>();
        stream = audioPlayer ? new TetaviStreamCompositeWithAudio(true, audioPlayer) : new TetaviStreamComposite(true);
    }

    new protected IEnumerator Start()
    {
        yield return base.Start();
#if UNITY_EDITOR
        if (!Application.isPlaying) yield return null;
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
		RegisterPlugin();
#endif
        //CreateTextureAndPassToPlugin();  -- moved to StartStream
        //SendMeshBuffersToPlugin();

        yield return StartCoroutine("CallPluginAtEndOfFrames");
    }
    

    protected override void StartStream(string pathToFile, bool noAudio = false)
    {
        base.StartStream(pathToFile, noAudio);
#if UNITY_EDITOR
        if (!Application.isPlaying) return;
#endif
        if (stream != null)
            CreateTextureAndPassToPlugin();
    }

    private void CreateTextureAndPassToPlugin()
    {
        for (int k = 0; k < 2; k++)
        {
            Destroy(texY[k]);
            Destroy(texUV[k]);
            texY[k] = new Texture2D(stream.GetWidth(), stream.GetHeight(), TextureFormat.R8, false);
            texY[k].filterMode = FilterMode.Point;
            texY[k].Apply();
            texUV[k] = new Texture2D(stream.GetWidth()/2 , stream.GetHeight() /2, TextureFormat.RG16, false);
            texUV[k].filterMode = FilterMode.Point;
            texUV[k].Apply();
        }
        SwitchWorkingTex(); ;
    }

    private void SwitchWorkingTex()
    {
        
        GetComponent<Renderer>().material.SetTexture("_TexY", texY[workingTex]);  // set shader to work on 1 textute set
        GetComponent<Renderer>().material.SetTexture("_TexUV", texUV[workingTex]);
        workingTex = workingTex != 0 ? 0 : 1;                                        // and the update to work on the other textute set
        stream.SetTexturesN12Targets(texY[workingTex].GetNativeTexturePtr(), texUV[workingTex].GetNativeTexturePtr(), texY[workingTex].width, texY[workingTex].height);
    }

    private IEnumerator CallPluginAtEndOfFrames()
    {
        while (true)
        {
            // Wait until all frame rendering is done
            yield return new WaitForEndOfFrame();

            if (meshNext != null)
            {
                // Issue a plugin event with arbitrary integer identifier.
                // The plugin can distinguish between different
                // things it needs to do based on this ID.
                // For our simple plugin, it does not matter which ID we pass here.
                GL.IssuePluginEvent(get_render_func(), meshNextSid); // stream.GetId());

                if (meshNext != null)
                {
                    meshRenderer.enabled = true;
                    // Set the mesh synched with texture rendering
                    meshFilter.mesh = meshNext;
                    meshNext = null;

                    // right after switching the mesh, switch the tex as well (assuming "atomic operation")
                    SwitchWorkingTex();
                }
            }
        }
    }

    override protected bool UpdateFrame(IntPtr frame, int sid)
    {
#if UNITY_EDITOR
        if (!Application.isPlaying) return base.UpdateFrame(frame, sid);
#endif
        if (!UpdateFramePrefix(frame))
            return false;
        meshNextSid = sid;
        if (debugNoLoadMesh >= 0)
            meshNext = CreateMesh(frame);
        if (debugNoLoadMesh == 1)
            debugNoLoadMesh = -1;
        //stream.ApplyRenderingFrame(frame); -- moved to be done together with GetFrameObj 
        UpdateFramePostfix();
        return true;
    }

#if DEVELOPMENT_BUILD || UNITY_EDITOR // FPS display
    new void OnGUI()
    {
        base.OnGUI();
    }
#endif
}
