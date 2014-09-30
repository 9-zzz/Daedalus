using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HexEnemyScript : MonoBehaviour
{
  public static HexEnemyScript Instance;
  //public GameObject hexsTarget;
  public AudioClip hexsSound;
  public AudioClip hexsDeath;
  public AudioClip hexsActivation;
  public int hexsHealth=4;
  public bool Activated = false;
  public bool activationSoundHasNotPlayed = true;
  public ParticleSystem deathExpl;
  public GameObject shieldRef;

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

        if (activationSoundHasNotPlayed)
        {
        audio.PlayOneShot(hexsActivation);
        activationSoundHasNotPlayed = false;
        }

        StartCoroutine(FadeShieldAlpha(0.0f, 1.0f));//start awesome coroutine

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

/*  void OnCollisionEnter(Collision other)
  {
    if (Activated)
    {
      if (other.gameObject.tag =="PlayerBullet")
      {
      GameObject.Find("spawnPoint").GetComponent<Shoot>().special += 2;
        hexsHealth--;
        rigidbody.AddRelativeForce(new Vector3(0, 0, -2000));
      }

      if (other.gameObject.tag =="Player")
      {
        AudioSource.PlayClipAtPoint(hexsDeath, transform.position);
        callDeathExplosion();
        Destroy(gameObject);
      }

      if (other.gameObject.tag =="sword")
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
  } */

  void OnTriggerEnter(Collider other)
  {
    if (Activated)
    {
      if (other.CompareTag("PlayerBullet"))
      {
      GameObject.Find("BulletspawnPoint").GetComponent<Shoot>().special += 2;
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

  IEnumerator FadeShieldAlpha(float aValue, float aTime)
  {
    if (shieldRef != null)
    {
      shieldRef.transform.collider.enabled = false;

      float alpha = shieldRef.transform.renderer.material.color.a;
      for (float t = 0.0f; t < 1.0f && shieldRef != null; t += Time.deltaTime / aTime)
      {
        shieldRef.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);

        Color newColor = new Color(1, 0, 0, Mathf.Lerp(alpha, aValue, t));
        shieldRef.transform.renderer.material.color = newColor;
        yield return null;

        if (newColor.a <= 0.001)
        {
          Debug.Log("DONE");
          Destroy(shieldRef);
        }
      }
    }
  }

  void callDeathExplosion()
  {
    Instantiate(deathExpl, transform.position, transform.rotation);
  }

}
