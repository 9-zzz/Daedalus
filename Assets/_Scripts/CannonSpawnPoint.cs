using UnityEngine;
using System.Collections;

public class CannonSpawnPoint : MonoBehaviour
{

  public bool cannonState = false;
  public GameObject cannonBallPF;
  public float ballYforce = 0;
  public float ballZforce = 0;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButton(2) && ballZforce <= 1500000)
    {
      ballYforce += 350;
      ballZforce += 2000;
    }

    if (cannonState && Input.GetMouseButtonUp(2))
    {
      var cannonBallInstance = Instantiate(cannonBallPF, transform.position, transform.rotation) as GameObject;
      cannonBallInstance.rigidbody.AddRelativeForce(0, ballYforce, ballZforce);
      ballYforce = 0;
      ballZforce = 0;
    }
  }

}