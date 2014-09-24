using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

  public ParticleSystem explosionPF;
  public bool didCollide = false;
  public GameObject DoNotExplodeOn;
  // Use this for initialization
  void Start()
  {
  Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("pickupcol").GetComponent<Collider>(), collider);
  }
   void bulletExplode() {
          ParticleSystem explosionInstance = Instantiate(explosionPF, 
          transform.position, 
          transform.rotation) as ParticleSystem;
      Destroy(explosionInstance, 2);
   }

  // Update is called once per frame
  void Update () {

      transform.Rotate(Vector3.forward * 25);

    if(didCollide){
      Destroy(gameObject);
      bulletExplode();
    }else{
      //bulletExplode();
      Destroy(gameObject, 10);


    }
    didCollide = false;
  }

  void OnCollisionEnter(Collision collision) {
    //if ((collision.gameObject.tag == "Player")){
    if ((collision.gameObject.name == "Character")){
      didCollide = false;
    }else{
      didCollide = true;
    }
  }


  }
