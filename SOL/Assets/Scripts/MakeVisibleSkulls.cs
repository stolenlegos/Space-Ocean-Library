using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisibleSkulls : MonoBehaviour
{
  public GameObject replacement;
  public GameObject shelfItems;
  private bool neverDone = true;

    void OnBecameInvisible(){
      if(neverDone && VisibilityManager.secondMemoryEnd && VisibilityManager.ThirdMemoryEnd) {
        shelfItems.SetActive(false);
        replacement.SetActive(true);
        VisibilityManager.IncreaseCount();
        neverDone = false;
      }
    }
}
