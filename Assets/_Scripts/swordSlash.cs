using UnityEngine;
using System.Collections;

public class swordSlash : MonoBehaviour
{
  public AudioClip swordClang;

  void Start()
  {
  }

  void Update()
  {
    if (Input.GetMouseButton(1) || Input.GetButton("Fire3"))
    {
      //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("1"), "islocal", true, "time", 2));
      transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(-2.7f, -1.4f, 1.1f), 0.1f);
      //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(34, -111, 254), Time.deltaTime * 10f);
      transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(34, -111, 254), Time.deltaTime * 10f);


      //if (transform.rotation.y > 0.5)
      //Debug.Log("sword rotation " + (transform.rotation.y));
    }
    else if (Input.GetMouseButtonUp(1) || Input.GetButtonUp("Fire3"))
    {

      Destroy(gameObject);
    }


    if (Input.GetMouseButton(2) || Input.GetButton("Fire2"))
    {
    transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(0, 2, 3), 0.5f);
    //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(34, -111, 254), Time.deltaTime * 10f);
    transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(-25, 0, 0), Time.deltaTime * 12f);


    }
    else if(Input.GetMouseButtonUp(2) || Input.GetButtonUp("Fire2"))
    {
      Destroy(gameObject);

    }
  }

  
  void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("EnemyBullet"))
    {
      audio.PlayOneShot(swordClang);
      Destroy(other);
    }
  }

}
