using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisibilityManager : MonoBehaviour
{
    [Header("Objs to turn off at start of game")]
    public List<GameObject> HideThisList = new List<GameObject>();

    [Header("Player's Interacable Script")]
    public SkullParent skullParent;

    [Header("Water Stuff")]
    public GameObject water;
    public Material waterMat;
    public Color yellow;
    public Color orange;
    public Color blueOne;
    public Color blueTwo;

    [Header("Water Heights")]
    public Vector3 waterStart;
    public Vector3 firstWaterLevel;
    public Vector3 secondWaterLevel;
    public Vector3 thirdWaterLevel;
    public Vector3 fourthWaterLevel;
    public Vector3 fifthWaterLevel;

    [Header("Memory Holograms")]
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

    [Header("Audio Timings")]
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

    [Header("Audio Objects")]
    public GameObject AudioBlockOne;
    public GameObject AudioBlockTwo;
    public GameObject AudioBlockFour;
    public GameObject AudioBlockSeven;

    [Header("Epilogue Needs")]
    public GameObject StudyBaseObj;
    private string CreditsScene = "Credits";

    private int waterLevel;
    private float t;

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
        waterLevel = 0;
        t = 0;

        foreach (GameObject obj in HideThisList){
          obj.SetActive(false);
        }
    }

    void Start() {
      StartCoroutine(IntroSoundsTimer());
      waterMat.SetColor("_Diffuse", blueOne);
      waterMat.SetColor("_DiffuseGrazing", blueTwo);
    }

    void OnDestroy() {
      waterMat.SetColor("_Diffuse", blueOne);
      waterMat.SetColor("_DiffuseGrazing", blueTwo);
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

      if (firstSkullAudioComplete && !pickUpSkullAudioStarted && skullParent.beingHeld) {
        StartCoroutine(PickUpFirstSkull());
        AudioBlockTwo.SetActive(true);
      }

      if(waterLevel == 1) {
        water.transform.position = Vector3.Lerp(waterStart, firstWaterLevel, t);
        t += 0.2f * Time.deltaTime;
      } else if(waterLevel == 2) {
        water.transform.position = Vector3.Lerp(firstWaterLevel, secondWaterLevel, t);
        t += 0.2f * Time.deltaTime;
      } else if(waterLevel == 3) {
        water.transform.position = Vector3.Lerp(secondWaterLevel, thirdWaterLevel, t);
        t += 0.2f * Time.deltaTime;
      } else if(waterLevel == 4) {
        water.transform.position = Vector3.Lerp(thirdWaterLevel, fourthWaterLevel, t);
        t += 0.2f * Time.deltaTime;
      } else if(waterLevel == 5) {
        water.transform.position = Vector3.Lerp(fourthWaterLevel, fifthWaterLevel, t);
        waterMat.SetColor("_Diffuse", Color.Lerp(blueOne, yellow, t));
        waterMat.SetColor("_DiffuseGrazing", Color.Lerp(blueTwo, orange, t));
        t += 0.2f * Time.deltaTime;
      }

      if (fourthMemoryEnd && t >= 1) {
        epiHolo.SetActive(true);
        //StartCoroutine(EpilogueTimer());
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
      AudioBlockOne.SetActive(true);
      StartCoroutine(FirstLineTimer());
      yield return new WaitForSeconds(firstSkullDialogueLength);
      firstSkullAudioComplete = true;
      Debug.Log("First skull dialogue finished");
    }

    private IEnumerator FirstLineTimer(){
      yield return new WaitForSeconds(6.25f);
      //raise water first time here
      waterLevel++;
      // waterMat.SetColor("_Diffuse", yellow);
      // waterMat.SetColor("_DiffuseGrazing", orange);
    }

    private IEnumerator PickUpFirstSkull(){
      pickUpSkullAudioStarted = true;
      //AudioBlockTwo.SetActive(true);
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
      mem1Holo.GetComponent<AudioSource>().spatialBlend = 0;
      Debug.Log("first memory finished");
      //make skull able to be picked up
      yield return new WaitForSeconds(postFirstMemlength);
      allowPickUp = true;
      mem1Holo.SetActive(false);
      Debug.Log("Finish first memory post dialogue");
      //raise water second time here
      waterLevel++;
      t = 0;
      allowShelvesVisible = true;
    }

    private IEnumerator PreSecondMemoryTimer(){
      preSecondMemoryStart = true;
      AudioBlockFour.SetActive(true);
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
      mem2Holo.GetComponent<AudioSource>().spatialBlend = 0;
      Debug.Log("second memory finished");
      //make item able to be picked up
      yield return new WaitForSeconds(postSecondMemlength);
      allowPickUp = true;
      mem2Holo.SetActive(false);
      secondMemoryEnd = true;
      Debug.Log("Finish second memory post dialogue");
      waterLevel++;
      t = 0;
      //raise water third or fourth time here;
    }

    private IEnumerator ThirdMemoryTimer(){
      //make items unable to be picked up
      allowPickUp = false;
      mem3Holo.SetActive(true);
      yield return new WaitForSeconds(ThirdMemoryLength);
      mem3HoloMesh.SetActive(false);
      mem3Holo.GetComponent<AudioSource>().spatialBlend = 0;
      Debug.Log("third memory finished");
      //make item able to be picked up
      yield return new WaitForSeconds(postThirdMemlength);
      allowPickUp = true;
      mem3Holo.SetActive(false);
      ThirdMemoryEnd = true;
      Debug.Log("Finish third memory post dialogue");
      waterLevel++;
      t = 0;
      //raise water third or fourth time here;
    }

    private IEnumerator PreFourthMemoryTimer(){
      preFourthMemoryStart = true;
      AudioBlockSeven.SetActive(true);
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
      mem4Holo.GetComponent<AudioSource>().spatialBlend = 0;
      Debug.Log("fourth memory finished");
      //make item able to be picked up
      yield return new WaitForSeconds(postFourthMemlength);
      fourthMemoryEnd = true;
      allowPickUp = true;
      mem4Holo.SetActive(false);
      Debug.Log("Finish Fourth memory post dialogue");
      //raise water fifth time here;
      waterLevel++;
      t = 0;
    }
  /*
    private IEnumerator EpilogueTimer() {
      yield return new WaitForSeconds(10f);
      StudyBaseObj.SetActive(false);
      SceneManager.LoadScene(CreditsScene, LoadSceneMode.Additive);
    }
    */
}
