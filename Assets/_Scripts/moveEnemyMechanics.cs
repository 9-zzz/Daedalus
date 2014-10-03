using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moveEnemyMechanics : MonoBehaviour
{

  public Text onScreenInfo;
  public int moveEnemyHealth = 10;
  public float distanceFromPlayer;
  public ParticleSystem movPart;

  void OnMouseOver()
  {
    onScreenInfo.text = "HEALTH " + moveEnemyHealth;
    onScreenInfo.CrossFadeAlpha(1, 1, true);
  }

  void OnMouseExit()
  {
    onScreenInfo.CrossFadeAlpha(0, 1, true);
  }

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    distanceFromPlayer = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);

    if (moveEnemyHealth <= 0)
    {
      onScreenInfo.CrossFadeAlpha(0, 1, true);
      Instantiate(movPart, transform.position, transform.rotation);
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.tag == "PlayerBullet")
    {
      moveEnemyHealth--;
    }
  }

}