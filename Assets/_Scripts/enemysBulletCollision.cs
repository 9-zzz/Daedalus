using UnityEngine;
using System.Collections;

public class enemysBulletCollision : MonoBehaviour {

  public AudioClip enemysBulletSound;
  public ParticleSystem explosionPF;
  //private ParticleSystem explosionInstance = null;
  public bool didCollide = false;
  public GameObject DoNotExplodeOn;
  int bulletLifeTime = 20;
  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update()
  {
    if (didCollide)
    {
      //explosionInstance = Instantiate(explosionPF, transform.position, transform.rotation) as ParticleSystem;
      Destroy(gameObject);
    }
    else
    {
      Destroy(gameObject, bulletLifeTime);
    }
    didCollide = false;
  }

  /*void OnTriggerEnter(Collider other) {
    if ((other.gameObject.tag == "enemysBullets")){
      didCollide = false;
    }
      didCollide = true;
      }*/

  void OnCollisionEnter(Collision collision)
  {
    /*GameObject PlayerInst = GameObject.Find("Character");
    playerCollisions playerScript = PlayerInst.GetComponent<playerCollisions>();

    if ((collision.gameObject.tag == "Player")){
      playerScript.health += 1;
    }*/

    if ((collision.gameObject.tag == "enemysBullets"))
    {
      didCollide = false;
    }

    didCollide = true;
  }

}
