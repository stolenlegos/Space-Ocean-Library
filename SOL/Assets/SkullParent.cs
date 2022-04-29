using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullParent : MonoBehaviour
{
  public bool beingHeld;
  public Transform LeftHand;
  public Transform RightHand;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.IsChildOf(LeftHand) || this.gameObject.transform.IsChildOf(RightHand)) {
          beingHeld = true;
        } else {
          beingHeld = false;
        }
    }
}
