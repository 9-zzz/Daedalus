using UnityEngine;
using System.Collections;

public class PickupCollisions : MonoBehaviour
{

  public AudioClip ammoPickUpSound;
  public AudioClip dashPickUpSound;
  public ParticleSystem ammoPUParticles;
  public ParticleSystem dashPUParticles;

  // Use this for initialization
  void Start()
  {

  }

  void ammoFX(Vector3 position)
  {
    ParticleSystem explInstance = Instantiate(ammoPUParticles, position, transform.rotation) as ParticleSystem;
    Destroy(explInstance, 1);
  }

  void dashFX(Vector3 position)
  {
    ParticleSystem dashFXInstance = Instantiate(dashPUParticles, position, transform.rotation) as ParticleSystem;
    Destroy(dashFXInstance, 5);
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("ammodrop"))
    {
      GameObject.Find("Player").GetComponent<SendingPositiveVibes>().lowVibration++;
      audio.PlayOneShot(ammoPickUpSound);
      ammoFX(other.gameObject.transform.position);
      GameObject.Find("spawnPoint").GetComponent<Shoot>().ammo += 10;
      GameObject.Find("Score").GetComponent<ShowScoreValue>().score2 += 2;
      Destroy(other.gameObject);
    }

    if (other.CompareTag("dashPick"))
    {
      GameObject.Find("Player").GetComponent<SendingPositiveVibes>().lowVibration++;
      audio.PlayOneShot(dashPickUpSound);
      dashFX(other.gameObject.transform.position);
      GameObject.Find("Player").GetComponent<TP_Motor>().dashBar += 30;
      GameObject.Find("Player").GetComponent<TP_Motor>().numOfJumps += 2;
      Destroy(other.gameObject);
    }

    if (other.CompareTag("goo"))
    {
      Debug.Log("wtf");
      GameObject.Find("Player").GetComponent<TP_Motor>().playerHealth -= 1;
    }
  }
  /*void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "ammodrop")
    {
      audio.PlayOneShot(ammoPickUpSound);
      ammoFX(collision.gameObject.transform.position);
      GameObject.Find("spawnPoint").GetComponent<Shoot>().ammo += 20;
      GameObject.Find("Score").GetComponent<ShowScoreValue>().score2 += 10;
      Destroy(collision.gameObject);
    }
  }*/

}