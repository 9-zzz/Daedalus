using UnityEngine;
using System.Collections;

public class oldcrosshair : MonoBehaviour 
{
  public Texture2D crosshairOuter;
  public Texture2D crosshairSide1;
  public Texture2D crosshairSide2;
  public Texture2D crosshairCenter;
  float xMin;
  float yMin;
  float xMin2;
  float yMin2;
  float xMin3;
  float yMin3;
  float targetxMin2;
  float targetyMin2;
  float targetxMin3;
  float targetyMin3;
  private int crosshairLag = 11;

  void OnGUI()
  {
    GUI.DrawTexture(new Rect(xMin, yMin, 200, 200), crosshairOuter);
    GUI.DrawTexture(new Rect(xMin2, yMin2, 15, 25), crosshairSide1);
    GUI.DrawTexture(new Rect(xMin3, yMin3, 15, 25), crosshairSide2);
  }

  void Update () 
  {
    xMin = Screen.width - (Screen.width - Input.mousePosition.x) - 100;
    yMin = (Screen.height - Input.mousePosition.y) - 100;    

    targetxMin2 = Screen.width - (Screen.width - Input.mousePosition.x)-16.25f;
    targetyMin2 = (Screen.height - Input.mousePosition.y) - 7.5f; //raised higher than center, not - 7

    targetxMin3 = Screen.width - (Screen.width - Input.mousePosition.x)+10;
    targetyMin3 = (Screen.height - Input.mousePosition.y) -7.5f;

    //Interpolate to target position in 1 second
    xMin2 = Mathf.Lerp(xMin2, targetxMin2, 1f * Time.deltaTime * crosshairLag);
    //Interpolate to target position in 1 second
    yMin2 = Mathf.Lerp(yMin2, targetyMin2, 1f * Time.deltaTime * crosshairLag);

    xMin3 = Mathf.Lerp(xMin3, targetxMin3, 1f * Time.deltaTime * crosshairLag);
    yMin3 = Mathf.Lerp(yMin3, targetyMin3, 1f * Time.deltaTime * crosshairLag);

    if(Input.GetButton("Fire1"))
    {//little bobbing :) 7:25am
      xMin2 = xMin2 - 2;
      xMin3 = xMin3 + 2;
    }

  }
}
