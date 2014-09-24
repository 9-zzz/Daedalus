using UnityEngine;
using System.Collections;

public class ReplenishAmmo : MonoBehaviour
{
  bool hasSeenPlayer = false;
  float upForce = 20;

  // Use this for initialization
  void Start()
  {
    Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), collider);
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.y < -142)
      Destroy(gameObject);

    var distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

    if (distance < 30)
      hasSeenPlayer = true;

    if (hasSeenPlayer)
    {
      transform.LookAt(GameObject.Find("Player").transform.position);
      rigidbody.AddRelativeForce(new Vector3(0, upForce, 150));
      transform.Translate(Vector3.forward * (Time.deltaTime * 25), Space.Self);
      upForce /= 2f;
    }

  }

}