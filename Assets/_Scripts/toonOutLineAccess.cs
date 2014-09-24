using UnityEngine;
using System.Collections;

public class toonOutLineAccess : MonoBehaviour
{
  public Color myColor;
  public Component[] DashTrailGroup;

  void Update()
  {

    myColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));//rgb

    DashTrailGroup = GetComponentsInChildren<TrailRenderer>();

    foreach (TrailRenderer trail in DashTrailGroup)
    {
      trail.renderer.material.SetColor("_Emission", myColor);
    }

      renderer.material.SetColor("_OutlineColor", Color.black);

  }

}
