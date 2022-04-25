using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    public List<GameObject> HideThisList = new List<GameObject>();
    public PickUp pickUp;
    public GameObject mem1Holo;
    public GameObject mem1HoloMesh;
    public GameObject mem2Holo;
    public GameObject mem2HoloMesh;
    public GameObject mem3Holo;
    public GameObject mem3HoloMesh;
    public GameObject mem4Holo;
    public GameObject mem4HoloMesh;
    public GameObject epiHolo;
    public GameObject epiHoloMesh;

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
    public float preFourthMemoryLength;
    public float FourthMemoryLength;
    public float postFourthMemlength;

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
    public static bool preFourthMemoryStart;
    public static bool fourthMemoryEnd;
    public static bool preFourthMemoryEnd;

    public static bool allowPickUp;
    public static bool skullUsed;
    public static bool plushUsed;
    public static bool radioUsed;
    public static bool secondSkullUsed;


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
        preFourthMemoryStart = false;
        preFourthMemoryEnd = false;
        fourthMemoryEnd = false;

        allowPickUp = true;
        skullUsed = false;
        plushUsed = false;
        radioUsed = false;
        secondSkullUsed = false;

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
      } else if (visibleItems == 14 && !preFourthMemoryStart){
        StartCoroutine(PreFourthMemoryTimer());
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

    public void ShowFourthMemory() {
      secondSkullUsed = true;
      StartCoroutine(FourthMemoryTimer());
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
      mem1Holo.SetActive(true);
      yield return new WaitForSeconds(firstMemoryLength);
      mem1HoloMesh.SetActive(false);
      firstMemoryEnd = true;
      Debug.Log("first memory finished");
      //make skull able to be picked up
      allowPickUp = true;
      yield return new WaitForSeconds(postFirstMemlength);
      mem1Holo.SetActive(false);
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
      mem2Holo.SetActive(true);
      yield return new WaitForSeconds(SecondMemoryLength);
      mem2HoloMesh.SetActive(false);
      secondMemoryEnd = true;
      Debug.Log("second memory finished");
      //make item able to be picked up
      allowPickUp = true;
      yield return new WaitForSeconds(postSecondMemlength);
      mem2Holo.SetActive(false);
      Debug.Log("Finish second memory post dialogue");
      //raise water third time here;
    }

    private IEnumerator ThirdMemoryTimer(){
      //make items unable to be picked up
      allowPickUp = false;
      mem3Holo.SetActive(true);
      yield return new WaitForSeconds(ThirdMemoryLength);
      mem3HoloMesh.SetActive(false);
      ThirdMemoryEnd = true;
      Debug.Log("third memory finished");
      //make item able to be picked up
      allowPickUp = true;
      yield return new WaitForSeconds(postThirdMemlength);
      mem3Holo.SetActive(false);
      Debug.Log("Finish third memory post dialogue");
      //raise water third time here;
    }

    private IEnumerator PreFourthMemoryTimer(){
      preFourthMemoryStart = true;
      yield return new WaitForSeconds(preFourthMemoryLength);
      Debug.Log("Finish pre fourth Memory");
      preFourthMemoryEnd = true;
    }

    private IEnumerator FourthMemoryTimer(){
      //make items unable to be picked up
      allowPickUp = false;
      mem4Holo.SetActive(true);
      yield return new WaitForSeconds(FourthMemoryLength);
      mem4HoloMesh.SetActive(false);
      fourthMemoryEnd = true;
      Debug.Log("fourth memory finished");
      //make item able to be picked up
      allowPickUp = true;
      yield return new WaitForSeconds(postFourthMemlength);
      mem4Holo.SetActive(false);
      Debug.Log("Finish Fourth memory post dialogue");
      //raise water third time here;
    }
}
