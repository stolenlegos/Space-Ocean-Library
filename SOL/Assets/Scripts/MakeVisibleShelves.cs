using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisibleShelves : MonoBehaviour
{
  public GameObject replacement;
  private bool neverDone = true;

    void OnBecameInvisible(){
      if(neverDone && VisibilityManager.allowDeskandSkullVisible) {
        replacement.SetActive(true);
        VisibilityManager.IncreaseCount();
        neverDone = false;
      }
    }
}
