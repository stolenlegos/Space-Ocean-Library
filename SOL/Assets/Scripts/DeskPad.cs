using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskPad : MonoBehaviour
{
    private void Awake () {
      DeskEvents.OnDeskNotify += OnDeskAction;
    }

    private void OnDeskAction (GameObject obj){
      if (obj.tag == "Skull") {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        Debug.Log("You have put the skull on the desk.");
      }
    }

    private void OnDestroy(){
      DeskEvents.OnDeskNotify -= OnDeskAction;
    }
}
