using UnityEngine;
using System.Collections;

public class autoDestroyJsphere : MonoBehaviour
{

  private GameObject player;
  float rotationsPerSecond = 2f;
  // Use this for initialization
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");

  }

  // Update is called once per frame
  void Update()
  {
    if (gameObject != null)
    {
      Vector3 euler = transform.localEulerAngles;
      euler.y += (rotationsPerSecond) * 360f * Time.deltaTime;
      transform.localEulerAngles = euler;

      transform.position = new Vector3(player.transform.position.x, (player.transform.position.y-7), player.transform.position.z);

      transform.localScale *= 1.09f;
      Color opac = renderer.material.color;
      opac.a /= 1.1f;
      renderer.material.color = opac;

      if (transform.localScale.y > 7)
      {
        Destroy(gameObject);
      }
    }
  }

}
