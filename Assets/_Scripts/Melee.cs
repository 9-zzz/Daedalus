using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{

  public GameObject Sword;
  public Vector3 swordOffset;
  public Vector3 swordOffset2;
  GameObject swordInst;
  Vector3 rotAround;

  void Update()
  {
    swordOffset = transform.TransformPoint(new Vector3(2.7f, 2.7f, -1.1f));
    swordOffset2 = transform.TransformPoint(new Vector3(3, 0, 0));
    //swordOffset = transform.TransformPoint(Vector3.right * 3);

    if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire3"))
    {
      //(Instantiate(Sword, swordOffset, Quaternion.Euler(-45,90,270)) as GameObject).transform.parent = transform;
      //swordInst = Instantiate(Sword, swordOffset, transform.localRotation) as GameObject;
      //swordInst.transform.parent = transform;
      //swordInst.transform.localEulerAngles = new Vector3(0, 90, 270);
      (Instantiate(Sword, swordOffset, Quaternion.Euler(-38, 130, 242)) as GameObject).transform.parent = transform;

    }

    if (Input.GetMouseButtonDown(2) || Input.GetButtonDown("Fire2"))
    {
      //(Instantiate(Sword, swordOffset, Quaternion.Euler(-45,90,270)) as GameObject).transform.parent = transform;
      //swordInst = Instantiate(Sword, swordOffset, transform.localRotation) as GameObject;
      //swordInst.transform.parent = transform;
      //swordInst.transform.localEulerAngles = new Vector3(0, 90, 270);
      (Instantiate(Sword, swordOffset2, Quaternion.Euler(0, 90, 270)) as GameObject).transform.parent = transform;

    }

  }

}
