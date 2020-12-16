using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 2.0f;
    //timer
    public Text timeText;
    private float time;
    private float timeSave;

    //PlayerMovement
    public float inputDelay = 50.0f;
    public float forwardVel = 0.1f;
    public float rotateVel = 150;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {
        targetRotation = transform.rotation;
        rBody = GetComponent<Rigidbody>();

        forwardInput = 0;
        turnInput = 0;

    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical"); //v
        turnInput = Input.GetAxis("Horizontal"); //h

        forwardInput = forwardInput * Speed * Time.deltaTime;
    }

    void Update()
    {
        GetInput();
        // Turn();
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine("front");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine("back");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("turnleft");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine("turnright");
        }
    }

    void FixedUpdate()
    {
        // Run();
    }

    private IEnumerator front()
    {
        Debug.Log("WWWWW");
        transform.Translate (new Vector3(0,0,40) * Speed);
        yield return new WaitForSeconds(0);
    }

    private IEnumerator back()
    {
        Debug.Log("SSSSS");
        transform.Translate (new Vector3(0,0,40) * Speed);
        yield return new WaitForSeconds(0);
    }

    private IEnumerator turnleft()
    {
        Debug.Log("AAAAA");
        targetRotation *= Quaternion.Euler(0,-90,0);
        transform.rotation = targetRotation;
        yield return new WaitForSeconds(0);
    }

    private IEnumerator turnright()
    {
        Debug.Log("FFFFF");
        targetRotation *= Quaternion.Euler(0,90,0);
        transform.rotation = targetRotation;
        yield return new WaitForSeconds(0);
    }

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
    //         targetRotation *= Quaternion.AngleAxis(rotateVel* turnInput * Time.deltaTime, Vector3.up);
    //     }
    //     transform.rotation = targetRotation;
    // }


    //캐릭터,시간 멈추기
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player") // 공이 골에 닿았다
        {
            Speed = 0;

            Time.timeScale = 0.0f;
        }
        else
        {
            Debug.Log("");
        }
    }
}