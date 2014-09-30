using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{
  public ParticleSystem explosionPF;

  // Use this for initialization
  void Start()
  {
    //Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("pickupcol").GetComponent<Collider>(), collider);
  }

  void bulletExplode()
  {
    Instantiate(explosionPF, transform.position, transform.rotation);
  }

  // Update is called once per frame
  void Update()
  {
    Destroy(gameObject, 10);
  }

  void OnCollisionEnter(Collision collision)
  {
    if (!(collision.gameObject.tag == "hexShield"))
    {
      bulletExplode();
      Destroy(gameObject);
    }
  }

}