using UnityEngine;
using System.Collections;

public class hexaShield : MonoBehaviour
{
  Vector3 start = new Vector3(0, 0, 0);
  Vector3 end = new Vector3(4.0f, 4.0f, 4.0f);
  float t = 0;

  // Use this for initialization
  void Start()
  {
    transform.parent.GetComponent<HexEnemyScript>().shieldRef = gameObject;
    //take this gameObject at start and make it equal to a public GameObject in parent's script

  }

  // Update is called once per frame
  void Update()
  {
    if (transform.localScale.y < 4)
    {
      gameObject.transform.localScale = Vector3.Lerp(start, end, t / 0.75f);
      t += Time.deltaTime;
    }
    transform.Rotate(0.3f, 0.1f, 0.1f * Time.deltaTime); //rotates 50 degrees per second around  axis
  }

  void OnTriggerEnter(Collider other)
  {

  if(other.gameObject.tag == "PlayerBullet")
      other.rigidbody.velocity = other.transform.forward * 0;
  }

}