using UnityEngine;
using System.Collections;

public class hexrotateysrot : MonoBehaviour {
  float rotationsPerSecond = 0.1f;
  GameObject player;
  public float distance;
  public bool doLoop = false;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    distance = Vector3.Distance(transform.position, player.transform.position);
  }

  void Update()
  {
    if (transform.parent.GetComponent<HexEnemyScript>().Activated)
    {
      distance = Vector3.Distance(transform.position, player.transform.position);

      Vector3 euler = transform.localEulerAngles;

      euler.z += (rotationsPerSecond * (800 / distance) * 360f * Time.deltaTime);

      //Debug.Log("this is rot " + euler.z);

      transform.localEulerAngles = euler;
    }
  }

}
