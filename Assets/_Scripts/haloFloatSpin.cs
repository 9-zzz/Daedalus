using UnityEngine;
using System.Collections;

public class haloFloatSpin : MonoBehaviour {

  public float height = 3.2f;
  public float speed = 2f;
  public float timingOffset = 0.0f;
  public float count=0.0f;
  public float haloRotSpeed = 0.75f;

    void Update()
    {
      transform.Rotate(Vector3.up * haloRotSpeed);

      //float offset = Mathf.Sin(Time.time * speed);
      //transform.position = new Vector3(transform.position.x, transform.position.y + offset/2f, transform.position.z);

    }
}
