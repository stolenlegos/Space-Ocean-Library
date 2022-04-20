using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearSkull : MonoBehaviour
{
  private bool neverDone = true;
  public Camera cam;
  public Vector3 viewPos;

  void Update() {
    viewPos = cam.WorldToViewportPoint(this.gameObject.transform.position);
    if (viewPos.z < -1f && VisibilityManager.allowShelvesVisible) {
      Invisible();
    }
  }

    void Invisible(){
      if(neverDone) {
        this.gameObject.SetActive(false);
        neverDone = false;
      }
    }
}
