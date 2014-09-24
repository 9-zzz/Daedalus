using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StrangeGooDialogue : MonoBehaviour
{

  public Text onScreenInfo;

  void OnMouseEnter()
  {
    onScreenInfo.text = "SPECIES: UNKOWN\n\nA strange Goo. Looks like it's best to avoid it...";
    onScreenInfo.CrossFadeAlpha(1, 1, true);
  }

  void OnMouseExit()
  {
    onScreenInfo.CrossFadeAlpha(0, 1, true);
  }


  // Use this for initialization
  void Start()
  {
    onScreenInfo.CrossFadeAlpha(0, 1, true);
  }

  // Update is called once per frame
  void Update()
  {

  }

}