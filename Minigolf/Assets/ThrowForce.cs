using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class XRObjectThrower : MonoBehaviour
{

    public TMP_Text scoreText;
    public bool[] holes = new bool[3];

    void Start()
    {
        GameObject textObject = GameObject.FindWithTag("ScoreTag");
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
        if( transform.position[1]>=-0.05 && transform.position[1]<=0.075 
            && transform.position[0] >= -1.4 && transform.position[0] <= 1.55
            && transform.position[2] >= -0.08 && transform.position[2] <= 0.95)
        { 
            Debug.Log("Bila este in gaura 1");
            scoreText.text = "Felicitari!!! Mergi la pista2";
            holes[0] = true;
            Debug.Log(transform.position);

            /*XRGrabInteractable grabInteractable = GameObject.Find("GrabObject").GetComponent<XRGrabInteractable>();
            grabInteractable.transform.position = new Vector3(1.78f, 0.15f, 2.5f);*/
        }
        else if (transform.position[1] >= -0.05 && transform.position[1] <= 0.075
            && transform.position[0] <= -1.60 && transform.position[0] >= -1.85
            && transform.position[2] >= 2.4 && transform.position[2] <= 2.6)// && holes[0])
        {
            holes[1] = true;
            Debug.Log("Bila este in gaura 2");
            scoreText.text = "Felicitari!!! Mergi la pista3";
            Debug.Log(transform.position);
        }
        else if (transform.position[1] >= -0.05 && transform.position[1] <= 0.075
            && transform.position[0] <= -1.37 && transform.position[0] >= -1.55
            && transform.position[2] >= 4.89 && transform.position[2] <= 5.08)// && holes[0] && holes[1])
        {
            holes[2] = true;
            Debug.Log("Bila este in gaura 3");
            scoreText.text = "Felicitari!!! Ai terminat!";
            Debug.Log(transform.position);
        }
        else
            Debug.Log(transform.position);
    }
}
