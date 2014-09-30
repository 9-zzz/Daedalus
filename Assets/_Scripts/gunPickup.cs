using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gunPickup : MonoBehaviour
{
  Vector3 originalPosition;
  public Text onScreenInfo;

  // Use this for initialization
  void Start()
  {
    originalPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = new Vector3(transform.position.x, originalPosition.y + Mathf.Sin(Time.time * 5) * 1f, transform.position.z);

    transform.Rotate(0.0f, 2f, 0.0f * Time.deltaTime); //rotates 50 degrees per second around  axis
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      onScreenInfo.text = "Picked up cannon fire weapon, hold middle click, release to fire";
      GameObject.Find("BulletspawnPoint").GetComponent<CannonSpawnPoint>().cannonState = true;
      onScreenInfo.CrossFadeAlpha(0, 3, true);
    }
  }

}