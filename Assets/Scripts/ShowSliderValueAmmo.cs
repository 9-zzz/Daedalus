using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowSliderValueAmmo : MonoBehaviour
{

  public void UpdateLabel(float value)
  {
    Text lbl = GetComponent<Text>();
    if (lbl != null)
      lbl.text = Mathf.RoundToInt (value) + "/120";
      //lbl.text = "AMMO";
  }
}
