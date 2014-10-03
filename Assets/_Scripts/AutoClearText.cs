using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoClearText : MonoBehaviour
{

  Text text;

  // Use this for initialization
  void Start()
  {
    text = GetComponent<Text>();
    text.CrossFadeAlpha(0, 1, true);//start this screen text at alpha zero for smooth fade in from the start
  }

  // Update is called once per frame
  void Update()
  {
    if (text.text != null)
    {
    }//clear it?
  }

}