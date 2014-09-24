using UnityEngine;
using System.Collections;

public class PlatFloat : MonoBehaviour {

  public float height = 3.2f;
  public float speed = 0.02f;
  public float timingOffset = 0.0f;
  public float count=0.0f;

    void Update()
    {
      float offset = Mathf.Sin(Time.time * speed);
      transform.position = new Vector3(transform.position.x, transform.position.y + offset/2f, transform.position.z);

    }
}
