using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{
    public List<GameObject> HideThisList = new List<GameObject>();

    public static int visibleItems;
    public float IntroDialogueTimeLength;
    public float firstSkullDialogueLength;
    public float firstMemoryLength;
    public float postFirstMemlength;

    public static bool allowWallsVisible;
    public static bool allowFurniatureVisible;
    public static bool allowDeskandSkullVisible;
    public static bool allowPickUpSkull;
    public static bool firstSkullAudioComplete;
    public static bool allowShelvesVisible;
    public static bool firstMemoryEnd;


    void Awake()
    {
        allowWallsVisible = false;
        allowFurniatureVisible = false;
        allowDeskandSkullVisible = false;
        allowPickUpSkull = false;
        firstSkullAudioComplete = false;
        allowShelvesVisible = false;
        firstMemoryEnd = false;

        visibleItems = 0;

        foreach (GameObject obj in HideThisList){
          obj.SetActive(false);
        }
    }

    void Start() {
      StartCoroutine(IntroDialogueTimer());
    }

    void Update(){
      if (visibleItems == 6) {
        allowDeskandSkullVisible = true;
      } else if (visibleItems == 8){
        Debug.Log("Desk and water visible");
        //play skull AudioClipPlayable
        StartCoroutine(FirstSkullDialogueTimer());
        allowPickUpSkull = true;
      }
    }

    public static void IncreaseCount() {
      visibleItems++;
    }

    public void ShowFirstMemory(){
      StartCoroutine(FirstMemoryTimer());
    }

    private IEnumerator IntroDialogueTimer() {
      yield return new WaitForSeconds(IntroDialogueTimeLength);
      allowWallsVisible = true;
    }

    private IEnumerator FirstSkullDialogueTimer(){
      yield return new WaitForSeconds(firstSkullDialogueLength);
      firstSkullAudioComplete = true;
    }

    private IEnumerator FirstMemoryTimer(){
      //make skull unable to be picked up
      yield return new WaitForSeconds(firstMemoryLength);
      firstMemoryEnd = true;
      //make first memory invisible here
      //make skull able to be picked up
      yield return new WaitForSeconds(postFirstMemlength);
      //raise water second time here
      allowShelvesVisible = true;
    }
}
