using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItem : MonoBehaviour
{
  private void OnTriggerEnter (Collider other) {
    if (other.tag == "DeskPad") {
      DeskEvents.OnDeskCall(this.gameObject);
    }
  }
}
