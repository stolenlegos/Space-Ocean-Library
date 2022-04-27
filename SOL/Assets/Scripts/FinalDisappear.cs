using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDisappear : MonoBehaviour
{
    void OnBecameInvisible() {
      if (VisibilityManager.fourthMemoryEnd) {
        this.gameObject.SetActive(false);
      }
    }
}
