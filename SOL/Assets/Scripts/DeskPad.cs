using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskPad : MonoBehaviour
{
    public VisibilityManager vm;
    public GameObject firstMem;
    public GameObject secondMem;
    public GameObject thirdMem;
    public GameObject fourthMem;

    private void Awake () {
      DeskEvents.OnDeskNotify += OnDeskAction;
    }

    private void OnDeskAction (GameObject obj){
      if (obj.tag == "Skull" && VisibilityManager.pickUpSkullAudioComplete && !VisibilityManager.skullUsed) {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        vm.ShowFirstMemory();
        Debug.Log("You have put the skull on the desk.");
      }

      if (obj.tag == "Radio" && VisibilityManager.preSecondMemoryEnd && !VisibilityManager.radioUsed) {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        vm.ShowSecondMemory(obj);
        Debug.Log("You have put the radio on the desk.");
      }

      if (obj.tag == "Plush" && VisibilityManager.preSecondMemoryEnd && !VisibilityManager.plushUsed) {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        vm.ShowSecondMemory(obj);
        Debug.Log("You have put the plush on the desk.");
      }

      if (obj.tag == "Skull_Second" && VisibilityManager.preFourthMemoryEnd && !VisibilityManager.secondSkullUsed) {
        //this will enable the correect hologram. Hologram itself will have coroutine to hide itself once it ends.
        Debug.Log("You have put the other skull on the desk.");
        vm.ShowFourthMemory();
      }
    }

    private void OnDestroy(){
      DeskEvents.OnDeskNotify -= OnDeskAction;
    }
}
