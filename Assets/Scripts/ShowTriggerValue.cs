using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowTriggerValue : MonoBehaviour
{

  Text text;
  public double value;
  public double value2;
  public double DPH;
  public double DPV;
  public double Hstick;
  public double Vstick;
  public double RHstick;
  public double RVstick;
  public double RstickPress;
  public bool RstickPressB;

  void Awake()
  {
    text = GetComponent<Text>();
  }

  void Update()
  {
    value = System.Math.Round((Input.GetAxis("LeftTrigger")), 2);
    value2 = System.Math.Round((Input.GetAxis("RightTrigger")), 2);

    DPH = System.Math.Round((Input.GetAxis("DpadH")), 2);
    DPV = System.Math.Round((Input.GetAxis("DpadV")), 2);

    Hstick = System.Math.Round((Input.GetAxis("Horizontal")), 5);
    Vstick = System.Math.Round((Input.GetAxis("Vertical")), 5);

    RHstick = System.Math.Round((Input.GetAxis("RightStickHorizontal")), 5);
    RVstick = System.Math.Round((Input.GetAxis("RightStickVertical")), 5);

    RstickPress = System.Math.Round((Input.GetAxis("RightStickPress")), 5);
    RstickPressB = Input.GetButton("RightStickPress");


    text.text =
      "Left Trigger Value = " + value +
      "\nRight Trigger Value = " + value2 +
      "\nD-Pad H Value = " + DPH +
      "\nD-Pad V Value = " + DPV +
      "\nH stick Value = " + Hstick +
      "\nV stick Value = " + Vstick +
      "\nRight H stick Value = " + RHstick +
      "\nRight V stick Value = " + RVstick +
      "\nRight Press stick Value = " + RstickPress +
      "\nRight Press stick B-Value = " + RstickPressB;
  }

}