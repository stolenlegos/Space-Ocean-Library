using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
  private bool lookingAtThing;
  private GameObject pickObj;
  private GameObject heldObj;
  public Transform destination;
  private bool holdingSomething;

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward * 100f);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (Physics.Raycast(ray, out hit)) {
          if(hit.collider.tag == "Skull") {
            lookingAtThing = true;
          pickObj = hit.collider.gameObject;
          } else {
            lookingAtThing = false;
          }
        }

        Debug.Log(lookingAtThing);
    }

    public void GrabObj(InputAction.CallbackContext ctx) {
      if(ctx.performed && lookingAtThing && !holdingSomething){
        heldObj = pickObj;
        heldObj.transform.position = destination.position;
        heldObj.transform.SetParent(this.gameObject.transform);
        Rigidbody horb = heldObj.GetComponent<Rigidbody>();
        horb.useGravity = false;
        horb.isKinematic = true;
        holdingSomething = true;
      } else if(ctx.performed && holdingSomething) {
        heldObj.transform.SetParent(null);
        Rigidbody horb = heldObj.GetComponent<Rigidbody>();
        horb.useGravity = true;
        horb.isKinematic = false;
        holdingSomething = false;
      }
    }
}