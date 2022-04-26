using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisibleWater : MonoBehaviour
{
  public GameObject replacement;
  private bool neverDone = true;
  private bool allowWater = false;
  public Camera cam;
  public Vector3 viewPos;
  public GameObject windowWall;

    void Update() {
      viewPos = cam.WorldToViewportPoint(windowWall.transform.position);
      if(viewPos.z < -1f && VisibilityManager.allowDeskandSkullVisible) {
        allowWater = true;
      }
    }

    void OnBecameInvisible(){
      if(neverDone && VisibilityManager.allowDeskandSkullVisible && allowWater) {
        replacement.SetActive(true);
        VisibilityManager.IncreaseCount();
        neverDone = false;
      }
    }
}
