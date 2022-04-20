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
    public float preSecondMemoryLength;
    public float SecondMemoryLength;
    public float postSecondMemlength;
    public float ThirdMemoryLength;
    public float postThirdMemlength;

    public static bool allowWallsVisible;
    public static bool allowDeskandSkullVisible;
    public static bool firstSkullAudioStarted;
    public static bool firstSkullAudioComplete;
    public static bool pickUpSkullAudioStarted;
    public static bool pickUpSkullAudioComplete;
    public static bool allowShelvesVisible;
    public static bool firstMemoryEnd;
    public static bool preSecondMemoryStart;
    public static bool preSecondMemoryEnd;
    public static bool secondMemoryEnd;
    public static bool ThirdMemoryEnd;

    public static bool allowPickUp;
    public static bool skullUsed;
    public static bool plushUsed;
    public static bool radioUsed;


    void Awake()
    {
        allowWallsVisible = false;
        allowDeskandSkullVisible = false;
        firstSkullAudioStarted = false;
        firstSkullAudioComplete = false;
        pickUpSkullAudioStarted = false;
        pickUpSkullAudioComplete = false;
        allowShelvesVisible = false;
        firstMemoryEnd = false;
        preSecondMemoryStart = false;
        preSecondMemoryEnd = false;
        secondMemoryEnd = false;
        ThirdMemoryEnd = false;

        allowPickUp = true;
        skullUsed = false;
        plushUsed = false;
        radioUsed = false;

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
      } else if (visibleItems == 13 && !preSecondMemoryStart){
        StartCoroutine(PreSecondMemoryTimer());
      }

      if (firstSkullAudioComplete && !pickUpSkullAudioStarted && pickUp.heldObj.tag == "Skull") {
        StartCoroutine(PickUpFirstSkull());
      }

      //Debug.Log(visibleItems);
    }

    public static void IncreaseCount() {
      visibleItems++;
    }

    public void ShowFirstMemory(){
      StartCoroutine(FirstMemoryTimer());
      skullUsed = true;
    }

    public void ShowSecondMemory(GameObject obj) {
      if(obj.tag == "Plush") {
        StartCoroutine(ThirdMemoryTimer());
        plushUsed = true;
      } else if (obj.tag == "Radio"){
        StartCoroutine(SecondMemoryTimer());
        radioUsed = true;
      }
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
      allowPickUp = false;
      yield return new WaitForSeconds(firstMemoryLength);
      firstMemoryEnd = true;
      Debug.Log("first memory finished");
      //make skull able to be picked up
      allowPickUp = true;
      yield return new WaitForSeconds(postFirstMemlength);
      Debug.Log("Finish first memory post dialogue");
      //raise water second time here
      allowShelvesVisible = true;
    }

    private IEnumerator PreSecondMemoryTimer(){
      preSecondMemoryStart = true;
      yield return new WaitForSeconds(preSecondMemoryLength);
      preSecondMemoryEnd = true;
      Debug.Log("pre second memory finished");
    }

    private IEnumerator SecondMemoryTimer(){
      //make items unable to be picked up
      allowPickUp = false;
      yield return new WaitForSeconds(SecondMemoryLength);
      secondMemoryEnd = true;
      Debug.Log("second memory finished");
      //make item able to be picked up
      allowPickUp = true;
      yield return new WaitForSeconds(postSecondMemlength);
      Debug.Log("Finish second memory post dialogue");
      //raise water third time here;
    }

    private IEnumerator ThirdMemoryTimer(){
      //make items unable to be picked up
      allowPickUp = false;
      yield return new WaitForSeconds(ThirdMemoryLength);
      ThirdMemoryEnd = true;
      Debug.Log("third memory finished");
      //make item able to be picked up
      allowPickUp = true;
      yield return new WaitForSeconds(postThirdMemlength);
      Debug.Log("Finish third memory post dialogue");
      //raise water third time here;
    }
}
