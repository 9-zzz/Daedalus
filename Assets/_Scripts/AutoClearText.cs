using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoClearText : MonoBehaviour
{

		Text text;

		// Use this for initialization
		void Start ()
		{
				text = GetComponent<Text> ();
		}

		// Update is called once per frame
		void Update ()
		{
				if (text.text != null) {
				}//clear it?
		}

}