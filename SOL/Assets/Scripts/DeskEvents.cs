using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskEvents
{
    public delegate void DeskFunctions (GameObject obj);
    public static event DeskFunctions OnDeskNotify;
    //public static event DeskFunctions DeskPlayingNotify;


    public static void OnDeskCall (GameObject obj) {
      OnDeskNotify?.Invoke(obj);
    }

    // public static void DeskPlayingCall (GameObject obj) {
    //   DeskPlayingNotify?.Invoke(obj);
    // }
}
