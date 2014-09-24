using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tobiasAi : MonoBehaviour
{
  public bool hitwithbeam = false;
  public GameObject ammoPickupPF;
  GameObject ammoPickup;
  Color dangerColor;
  public Text onScreenInfo;

  void OnMouseOver()
  {
    //onScreenInfo.text = "SPECIES: TOBIAS SQUANCHILIUS\n\n\"Hi! I'm harmless and fun to shoot! Shooting me boosts your special attack bar!\nI can only be destroyed by your special attack.\"";
    onScreenInfo.text = "TOBIAN";
    onScreenInfo.CrossFadeAlpha(1, 1, true);
  }

  void OnMouseExit()
  {
    onScreenInfo.CrossFadeAlpha(0, 1, true);
  }

  void Update()
  {
    if (hitwithbeam)
    {
      dangerColor = new Color(Random.Range(0.0f, 1.0f), 0.0f, 0.0f);//rgb
      iTween.ShakePosition(gameObject, iTween.Hash("x", 1f, "y", 0.3f, "z", 4f, "time", 0.25f));
      transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
      renderer.material.SetColor("_OutlineColor", dangerColor);
    }
  }

  void shootOutAmmo()
  {
    ammoPickup = Instantiate(ammoPickupPF, transform.position, transform.rotation) as GameObject;
    ammoPickup.rigidbody.AddRelativeForce(0, 1200, 0);
  }

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "PlayerBullet")
      GameObject.Find("spawnPoint").GetComponent<Shoot>().special += 6;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "sword")
      iTween.ShakePosition(gameObject, iTween.Hash("x", 0.8f, "y", 1f, "z", 1f, "time", 0.25f));

    if (other.gameObject.tag == "specialbeam")
    {
      hitwithbeam = true;
      StartCoroutine(DeathSequence());
    }
  }

  IEnumerator DeathSequence()
  {
    shootOutAmmo();
    shootOutAmmo();
    yield return new WaitForSeconds(2);
    Destroy(gameObject);
    shootOutAmmo();
    shootOutAmmo();
  }

}