using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoomStyleCameraController : MonoBehaviour
{

    //private SOL_InputSystem controls;
    private PlayerInput playerInput;
    private InputAction lookAction;
    private InputAction moveAction;
    private InputAction altitudeAction;
    private InputAction sprintModifierAction;

    public float sprintModifier;

    void Awake()
    {
        // controls = new SOL_InputSystem();

        playerInput = GetComponent<PlayerInput>();
        lookAction=playerInput.actions["Look"];
        moveAction = playerInput.actions["Move"];
        altitudeAction = playerInput.actions["Altitude"];
        sprintModifierAction = playerInput.actions["Sprint"];

        sprintModifier = 1;


        
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        //controls.Enable();
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        //controls.Disable();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

        Debug.Log(sprintModifierAction);

        if(sprintModifierAction.phase == InputActionPhase.Performed){
            sprintModifier = 2;
            Debug.Log("Sprinting");
        }
        if(sprintModifierAction.phase == InputActionPhase.Waiting){
            sprintModifier = 1;
            Debug.Log("Walking");
        }
        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector2 look = lookAction.ReadValue<Vector2>();
        float altitude = altitudeAction.ReadValue<float>();
        Debug.Log(look);


        transform.Translate(move.x * Time.deltaTime * sprintModifier, 0, move.y * Time.deltaTime * sprintModifier);
        transform.Translate(0, altitude * Time.deltaTime * sprintModifier, 0);
        transform.Rotate(0, look.x, 0, Space.World);
        transform.Rotate(-look.y, 0, 0, Space.Self);
    }



}