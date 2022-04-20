using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    public List<GameObject> HideThisList = new List<GameObject>();
    public PickUp pickUp;

    public static int visibleItems;
    public float IntroSoundsTimeLength;
    public float firstSkullDialogueLength;
    public float pickUpSkullDialogueLength;
    public float firstMemoryLength;
    public float postFirstMemlength;

    public static bool allowWallsVisible;
    public static bool allowFurniatureVisible;
    public static bool allowDeskandSkullVisible;
    public static bool firstSkullAudioStarted;
    public static bool firstSkullAudioComplete;
    public static bool pickUpSkullAudioStarted;
    public static bool pickUpSkullAudioComplete;
    public static bool allowShelvesVisible;
    public static bool firstMemoryEnd;


    void Awake()
    {
        allowWallsVisible = false;
        allowFurniatureVisible = false;
        allowDeskandSkullVisible = false;
        firstSkullAudioStarted = false;
        firstSkullAudioComplete = false;
        pickUpSkullAudioStarted = false;
        pickUpSkullAudioComplete = false;
        allowShelvesVisible = false;
        firstMemoryEnd = false;

        visibleItems = 0;

        foreach (GameObject obj in HideThisList){
          obj.SetActive(false);
        }
    }

    void Start() {
      StartCoroutine(IntroSoundsTimer());
    }

    void Update(){
      if (visibleItems == 6) {
        allowDeskandSkullVisible = true;
        //make water rise first time (appear)
      } else if (visibleItems == 8  && !firstSkullAudioStarted){
        //play skull AudioClipPlayable
        StartCoroutine(FirstSkullDialogueTimer());
      }

      if (firstSkullAudioComplete && !pickUpSkullAudioComplete && pickUp.heldObj.tag == "Skull") {
        StartCoroutine(PickUpFirstSkull());
      }
      Debug.Log("Allow walls visible" + allowWallsVisible);
      Debug.Log("Allow furniature visible" + allowFurniatureVisible);
      Debug.Log("allow desk visible" + allowDeskandSkullVisible);
      // Debug.Log("first skull audio complete" + firstSkullAudioComplete);
      // Debug.Log("allow shelves visible" + allowShelvesVisible);
      // Debug.Log("first memory complete" + firstMemoryEnd);

    }

    public static void IncreaseCount() {
      visibleItems++;
    }

    public void ShowFirstMemory(){
      StartCoroutine(FirstMemoryTimer());
    }

    private IEnumerator IntroSoundsTimer() {
      yield return new WaitForSeconds(IntroSoundsTimeLength);
      allowWallsVisible = true;
      Debug.Log("Intro sounds finished");
    }

    private IEnumerator FirstSkullDialogueTimer(){
      firstSkullAudioStarted = true;
      yield return new WaitForSeconds(firstSkullDialogueLength);
      firstSkullAudioComplete = true;
      Debug.Log("First skull dialogue finished");
    }

    private IEnumerator PickUpFirstSkull(){
      pickUpSkullAudioStarted = true;
      yield return new WaitForSeconds(pickUpSkullDialogueLength);
      pickUpSkullAudioComplete = true;
      Debug.Log("Skull Pick up Audio finished");
    }

    private IEnumerator FirstMemoryTimer(){
      //make skull unable to be picked up
      yield return new WaitForSeconds(firstMemoryLength);
      firstMemoryEnd = true;
      Debug.Log("first memory finished");
      //make first memory invisible here
      //make skull able to be picked up
      yield return new WaitForSeconds(postFirstMemlength);
      Debug.Log("Finish first memory post dialogue");
      //raise water second time here
      allowShelvesVisible = true;
    }
}
