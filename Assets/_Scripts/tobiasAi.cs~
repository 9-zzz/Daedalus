using UnityEngine;
using System.Collections;

public class tobiasAi : MonoBehaviour {

  void OnCollisionEnter (Collision col)
  {
    if (col.gameObject.tag == "PlayerBullet")
      GameObject.Find("spawnPoint").GetComponent<Shoot>().special += 4;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "sword")
      iTween.ShakePosition(gameObject, iTween.Hash("x", 1f, "y", 1f, "z", 1f, "time", 0.25f));
  }
}
