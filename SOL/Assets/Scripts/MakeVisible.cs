using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisible : MonoBehaviour
{
  public MeshFilter mesh;
  public Mesh firstMesh;
  public Mesh secondMesh;
    void Start()
    {
      mesh.mesh = firstMesh;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible(){
      mesh.mesh = secondMesh;
    }
}
