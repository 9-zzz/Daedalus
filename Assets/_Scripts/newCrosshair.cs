using UnityEngine;
using System.Collections;

public class newCrosshair : MonoBehaviour 
{
  public Texture2D center;
  public Texture2D topLeft;
  public Texture2D bottomLeft;
  public Texture2D topRight;
  public Texture2D bottomright;
  float xMin;
  float yMin;
  float xMin2;
  float yMin2;
  float targetxMin2;
  float targetyMin2;
  private int crosshairLag = 11;

  void OnGUI()
  {
    //GUI.DrawTexture(new Rect(xMin, yMin, 10, 10), center);
    GUI.DrawTexture(new Rect(xMin2, yMin2, 200, 200), topLeft);
    GUI.DrawTexture(new Rect(xMin, yMin, 96, 80), center, ScaleMode.ScaleToFit, true, 1);
  }

  void Start () 
  {
    //Screen.lockCursor = true;
    //Screen.showCursor = false;
  }

  void Update () 
  {
    xMin = Screen.width - (Screen.width - Input.mousePosition.x) - 25;
    yMin = (Screen.height - Input.mousePosition.y) - 25;    

    targetxMin2 = Screen.width - (Screen.width - Input.mousePosition.x) - 7;
    targetyMin2 = (Screen.height - Input.mousePosition.y) - 15; //raised higher than center, not - 7

    //Interpolate to target position in 1 second
    xMin2 = Mathf.Lerp(xMin2, targetxMin2, 1f * Time.deltaTime * crosshairLag);
    //Interpolate to target position in 1 second
    yMin2 = Mathf.Lerp(yMin2, targetyMin2, 1f * Time.deltaTime * crosshairLag);

    if(Input.GetButton("Fire1"))//little bobbing :) 7:25am
      yMin2 = yMin2 - 2;
  }
}
