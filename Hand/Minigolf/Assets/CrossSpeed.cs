using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;  

public class CrossSpeed : MonoBehaviour
{

    public float maxThrowForce = 1000f;
    public float forceAdjustmentSpeed = 100f;
    public KeyCode increaseForceKey = KeyCode.O; 
    public KeyCode decreaseForceKey = KeyCode.P; 

    private XRGrabInteractable grabInteractable;
    private float currentThrowForce = 0f;
    private bool isHoldingObject = false;
    private bool hasCounted = false;
    private IXRInteractor interactor;


    private int numberOfThrows = 0;
    public TMP_Text powerText;
    public TMP_Text scoreText;


    void Start()
    {
        grabInteractable = GameObject.Find("GrabBata").GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        GameObject textObject = GameObject.FindWithTag("PowerTag");
        if (textObject != null)
        {
            powerText = textObject.GetComponent<TMP_Text>();
            powerText.text = "Putere : 0%";
        }
        else
        {
            Debug.LogError("No Text object found with tag 'PowerText'!");
        }

        textObject = GameObject.FindWithTag("ScoreTag");
        if (textObject != null)
        {
            scoreText = textObject.GetComponent<TMP_Text>();
            scoreText.text = "Lovituri : 0";
        }
        else
        {
            Debug.LogError("No Text object found with tag 'ScoreText'!");
        }

    }

    void Update()
    {

        if (isHoldingObject && interactor != null)
        {
            if (Input.GetKey(increaseForceKey))
            {
                currentThrowForce += forceAdjustmentSpeed * Time.deltaTime;

            }
            else if (Input.GetKey(decreaseForceKey))
            {
                currentThrowForce -= forceAdjustmentSpeed * Time.deltaTime;
            }
            currentThrowForce = Mathf.Clamp(currentThrowForce, 0, maxThrowForce);
            powerText.text = "Putere : " + ((int)(currentThrowForce / 10)).ToString() + "%";
        }

    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isHoldingObject = true;
        interactor = args.interactorObject;  // Schimbăm de la interactor la interactorObject
        currentThrowForce = 0f;  // Resetăm forța la început
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHoldingObject = false;
        interactor = null;  // Resetăm interactorul
        powerText.text = "Ia crosa!";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            hasCounted = false;

            if (ballRigidbody != null)
            {
                Vector3 hitDirection = collision.contacts[0].normal;
                ballRigidbody.AddForce(-hitDirection / 1000 * currentThrowForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (ballRigidbody != null && !hasCounted)
            {
                numberOfThrows++;
                scoreText.text = "Lovituri : " + numberOfThrows.ToString();
                hasCounted = true;
            }
        }
    }
}
