using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform player;
    public float dist = 0.5f;
    public float height = 0f;
    public float dampTrace = 100f;
	
    void Start()
    {
        //마우스커서 가운데 고정
        // transform.GetComponent<CharacterController>();
        // Cursor.lockState = CursorLockMode.Locked;   
    }

	void LateUpdate () {
       transform.position = Vector3.Lerp(transform.position, player.position - (player.forward*dist) + (Vector3.up * height), Time.deltaTime * dampTrace);
       transform.LookAt(player.position);
    }

    private void Zvalue(float value)
    {
        Vector3 ZeulerRot = transform.eulerAngles;
        ZeulerRot.z = value;
        transform.eulerAngles = ZeulerRot;
    }
    // public float inputDelay = 0.1f;
    // public float forwardVel = 12;
    // public float rotateVel = 100;

    // Quaternion targetRotation;
    // Rigidbody rBody;
    // float forwardInput, turnInput;

    // public Quaternion TargetRotation
    // {
    //     get { return targetRotation; }
    // }

    // void Start()
    // {
    //     targetRotation = transform.rotation;
    //     rBody = GetComponent<Rigidbody>();

    //     forwardInput = 0;
    //     turnInput = 0;

    // }

    // void GetInput()
    // {
    //     forwardInput = Input.GetAxis("Vertical");
    //     turnInput = Input.GetAxis("Horizontal");
    // }
    // void Update()
    // {
    //     GetInput();
    //     Turn();
    // }

    // void FixedUpdate()
    // {
    //     Run();   
    // }

    // void Run()
    // {
    //     if (Mathf.Abs(forwardInput) > inputDelay)
    //     {
    //         rBody.velocity = transform.forward * forwardInput * forwardVel;
    //     }
    //     else
    //         rBody.velocity = Vector3.zero;
    // }

    // void Turn()
    // {
    //     if (Mathf.Abs(turnInput) > inputDelay)
    //     {
    //         targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
    //     }
    //     transform.rotation = targetRotation;
    // }
}
