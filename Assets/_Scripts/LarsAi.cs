using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LarsAi : MonoBehaviour {

  public bool enemyIsActivated = false;
  public AudioClip hurtSound;
  public AudioClip LarsAwakens;
  bool larsAwakensPlayed = false;
  public AudioClip getHurtSound;
  public GameObject Character;//for lookat
  public GameObject prefab;
  public GameObject prefab2;
  public GameObject hexPrefab;
  private GameObject hexInstance;
  public GameObject reSpawn;
  public GameObject enemysBullet;
  public GameObject eSpawnPoint;
  public GameObject eBulletPF;
  public ParticleSystem enemySpawnBubble;
  public Slider LarsHealth;
  Vector3 aimPoint;
  Vector3 respwnpnt;
  //GameObject healthBoxDrop;
  int enemyHealth = 100;
  float nextShotTime = 0;
  float nextShotTime2 = 0;

  void Start(){
    enemyIsActivated = false;
  }

  void Update() {

    LarsHealth.value = enemyHealth;

    if(enemyIsActivated == true)
    {
      if (!larsAwakensPlayed)
      {
      
        AudioSource.PlayClipAtPoint(LarsAwakens, GameObject.Find("Player").transform.position);
        larsAwakensPlayed = true;
      }

      aimPoint = Character.transform.position;

      transform.LookAt(aimPoint);    
      //transform.LookAt(new Vector3(Character.transform.position.x, 0, Character.transform.position.z));

      Debug.DrawLine(transform.position, aimPoint);

      float distance = Vector3.Distance (transform.position, Character.transform.position);

      if(distance > 50){

        rigidbody.velocity = transform.forward * 30;

      }else{

        rigidbody.AddForce((aimPoint - transform.position).normalized * 19, ForceMode.VelocityChange);


        rigidbody.AddForce((aimPoint - transform.position).normalized * -19, ForceMode.VelocityChange);

      }
          enemyShootsBullet();
          enemyShootsHex();

      if(enemyHealth <= 0){

        //healthBoxDrop = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        //reSpawn = Instantiate(prefab2, transform.position, Quaternion.identity) as GameObject;// should give health and maybe respawn
        Destroy(gameObject);
      }
    }
  }//end of Update

  void OnCollisionEnter(Collision collision) {//for enemy itself not bullets

    if (collision.gameObject.tag == "PlayerBullet")
    {
      enemyIsActivated = true;
      GameObject.Find("spawnPoint").GetComponent<Shoot>().special += 2;
      enemyHealth -= 2;
    }
    /*GameObject PlayerInst = GameObject.Find("Character");
    playerCollisions playerScript = PlayerInst.GetComponent<playerCollisions>();//getting variables from playercollisions.cs

    if(collision.gameObject.tag == "Player"){//if enemies hit player
      audio.PlayOneShot(hurtSound);
      playerScript.health += 5;//opposites,,, sorry
    }//correctly editing variable in playercollisions script

    //if(playerScript.health >= 100){
    //is dead but restarts
    //}
    */

    //if ((collision.gameObject.tag == "Player")){
  }

  void enemyShootsBullet (){


    if(nextShotTime < Time.time){

    nextShotTime = Time.time + Random.Range(0f,5f);

      enemysBullet = Instantiate( eBulletPF, eSpawnPoint.transform.position, eSpawnPoint.transform.rotation) as GameObject;
      Instantiate(enemySpawnBubble, eSpawnPoint.transform.position, eSpawnPoint.transform.rotation);

      enemysBullet.transform.LookAt(aimPoint);          //fixes when hit point was = (0,0,0);

      Physics.IgnoreCollision(enemysBullet.collider, transform.collider);

      enemysBullet.rigidbody.velocity = enemysBullet.transform.forward * 200;
    }

  }

  void enemyShootsHex()
  {
    if (nextShotTime2 < Time.time)
    {
      nextShotTime2 = Time.time + Random.Range(0f, 15f);

      hexInstance = Instantiate(hexPrefab, eSpawnPoint.transform.position, eSpawnPoint.transform.rotation) as GameObject;
      hexInstance.transform.LookAt(aimPoint);          //fixes when hit point was = (0,0,0);

      hexInstance.rigidbody.velocity = enemysBullet.transform.forward * 50;

      Instantiate(enemySpawnBubble, eSpawnPoint.transform.position, eSpawnPoint.transform.rotation);

    }

  }


  IEnumerator wait()
  {
    Debug.Log("waiting for 5 seconds start");
    yield return new WaitForSeconds(5);
    Debug.Log("5 seconds over");
  }

  }//end of class
