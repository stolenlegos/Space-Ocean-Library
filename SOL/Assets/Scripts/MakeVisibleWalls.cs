using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisibleWalls : MonoBehaviour
{
  public GameObject replacement;
  private bool neverDone = true;

    void OnBecameInvisible(){
      if(neverDone && VisibilityManager.allowWallsVisible) {
        replacement.SetActive(true);
        VisibilityManager.IncreaseCount();
        neverDone = false;
      }
    }
}
