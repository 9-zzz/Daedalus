using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetColorOfSpecialBar : MonoBehaviour
{

  public Color myColor;
  public Color color;
  public Image imageThing;
  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

    myColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));//rgb

    if (GameObject.Find("spawnPoint").GetComponent<Shoot>().fullSpecial)
    {
      imageThing.color = myColor;

    }

  }

}