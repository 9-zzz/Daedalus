using UnityEngine;
using XInputDotNetPure;
using System.Collections;

/*Use this script by calling: 
GameObject.Find("Player").GetComponent<SendingPositiveVibes>().highVibration ++;
Where desired.*/

public class SendingPositiveVibes : MonoBehaviour
{
  public float highVibration = 0;
  public float lowVibration = 0;
  float time;
  float speed;

  void Start()
  {
    speed = 0.25f;
  }

  // Update is called once per frame.
  void Update()
  {
    //Debug.Log("These are the vibration vars = " + highVibration + " - " + lowVibration);

    GamePad.SetVibration(0, lowVibration, highVibration); //2nd parameter is the left motor in the controller ... etc.

    time += Time.deltaTime * speed; //how quickly the Vibration variables are interpolated to zero.

    if ((highVibration > 0) || (lowVibration > 0))
    {
      highVibration = Mathf.Lerp(highVibration, 0, time); //Lerp to zero, stop at zero.

      lowVibration = Mathf.Lerp(lowVibration, 0, time); //Lerp to zero, stop at zero.
    }
  }

}