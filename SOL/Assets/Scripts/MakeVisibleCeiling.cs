using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisibleCeiling : MonoBehaviour
{
  public GameObject replacement;
  private bool neverDone = true;
  public Camera cam;
  public Collider col;
  public Vector3 viewPos;

  void Update() {
    viewPos = cam.WorldToViewportPoint(this.gameObject.transform.position);
    if (viewPos.z < -1f && VisibilityManager.allowWallsVisible) {
      Invisible();
    }
  }

    void Invisible(){
      if(neverDone) {
        replacement.SetActive(true);
        VisibilityManager.IncreaseCount();
        neverDone = false;
        col.enabled = false;
      }
    }
}
