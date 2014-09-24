using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowSliderValueLars: MonoBehaviour
{
	public void UpdateLabel (float value)
	{
		Text lbl = GetComponent<Text>();
		if (lbl != null)
			//lbl.text = Mathf.RoundToInt (value * 100) + "";
			lbl.text = "LARS";
	}
}
