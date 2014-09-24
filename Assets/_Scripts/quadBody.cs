using UnityEngine;
using System.Collections;

public class quadBody : MonoBehaviour
{
  private Vector3 currentAngle;

  // Use this for initialization
  void Start()
  {
    currentAngle = transform.eulerAngles;
  }

  // Update is called once per frame
  void Update()
  {
    currentAngle = new Vector3(0, (Mathf.LerpAngle(currentAngle.y, transform.GetChild(0).localEulerAngles.y, Time.deltaTime * 0.2f)), 0);

    transform.eulerAngles = currentAngle;
  }
}