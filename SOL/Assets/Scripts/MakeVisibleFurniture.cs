using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisibleFurniture : MonoBehaviour
{
  public List<GameObject> replacement = new List<GameObject>();
  private bool neverDone = true;

    void OnBecameInvisible(){
      if(neverDone && VisibilityManager.allowDeskandSkullVisible) {
        foreach (GameObject obj in replacement) {
          obj.SetActive(true);
        }
        VisibilityManager.IncreaseCount();
        neverDone = false;
      }
    }
}
