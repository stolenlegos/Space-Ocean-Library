using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskPad : MonoBehaviour
{
    public VisibilityManager vm;

    private void Awake () {
      DeskEvents.OnDeskNotify += OnDeskAction;
    }

    private void OnDeskAction (GameObject obj){
      if (obj.tag == "Skull" && VisibilityManager.pickUpSkullAudioComplete) {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        vm.ShowFirstMemory();
        Debug.Log("You have put the skull on the desk.");
      }

      if (obj.tag == "Radio") {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        Debug.Log("You have put the radio on the desk.");
      }

      if (obj.tag == "Plush") {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        Debug.Log("You have put the plush on the desk.");
      }

      if (obj.tag == "Skull_Second") {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        Debug.Log("You have put the other skull on the desk.");
      }
    }

    private void OnDestroy(){
      DeskEvents.OnDeskNotify -= OnDeskAction;
    }
}
