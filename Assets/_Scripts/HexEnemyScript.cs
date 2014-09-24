using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HexEnemyScript : MonoBehaviour
{

  public static HexEnemyScript Instance;

  //public GameObject hexsTarget;
  public AudioClip hexsSound;
  public AudioClip hexsDeath;
  public int hexsHealth=6;
  public bool Activated = false;
  public ParticleSystem deathExpl;

  void Start()
  {
  }

  void Update()
  {
    if(hexsHealth > 0)
    {
      float distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

      if(distance < 100)
        Activated = true;

      if(Activated){

        audio.PlayOneShot(hexsSound);

        transform.LookAt(GameObject.Find("Player").transform.position);

        if (distance < 20)
        {
          rigidbody.AddRelativeForce(new Vector3(0, 0, 100));
          transform.Translate(Vector3.forward * (Time.deltaTime*50), Space.Self);
        }
        else if(distance > 200)
        {
          rigidbody.AddRelativeForce(new Vector3(0, 0, 200));
        }
        else if (distance > 250)
        {
          rigidbody.AddRelativeForce(new Vector3(0, 0, 400));
        }
        else
        {
          rigidbody.AddRelativeForce(new Vector3(0, 0, 20));
          transform.Translate(Vector3.forward * (Time.deltaTime*20), Space.Self);
        }
        //transform.Translate(Vector3.forward * (Time.deltaTime*5), Space.Self);
      }
    }
    else
    {
      AudioSource.PlayClipAtPoint(hexsDeath, transform.position);
      callDeathExplosion();
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (Activated)
    {
      if (other.CompareTag("PlayerBullet"))
      {
      GameObject.Find("spawnPoint").GetComponent<Shoot>().special += 2;
        hexsHealth--;
        rigidbody.AddRelativeForce(new Vector3(0, 0, -2000));
      }

      if (other.CompareTag("Player"))
      {
        AudioSource.PlayClipAtPoint(hexsDeath, transform.position);
        callDeathExplosion();
        Destroy(gameObject);
      }

      if (other.CompareTag("sword"))
      {
        callDeathExplosion();
        Destroy(gameObject);
      }

      if (other.gameObject.tag == "specialbeam")
      {
        callDeathExplosion();
        Destroy(gameObject);
      }

    }
  }

  void callDeathExplosion()
  {
    Instantiate(deathExpl, transform.position, transform.rotation);
  }

}
