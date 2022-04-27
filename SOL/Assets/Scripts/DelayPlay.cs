using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DelayPlay : MonoBehaviour
{
  public float Delay;
  public AudioSource source;
    void OnEnable() {
      source.PlayDelayed(Delay);
    }
}
