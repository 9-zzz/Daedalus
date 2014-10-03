using UnityEngine;
using System.Collections;

public class randomMove : MonoBehaviour
{
  public int zeroOrOne;
  public int forwardUnits;
  public Vector3 randomDirection;
  public bool canMove = false;
  public float firstWaitTime;
  public float secondWaitTime;

  // Use this for initialization
  void Start()
  {
    StartCoroutine(wait());
  }

  void randMoveForward()
  {
    zeroOrOne = Random.Range(0, 4);//range between zero and 1? WHY?!

    //Vector3 randomDirection = new Vector3(Random.value, 0, Random.value);
    switch (zeroOrOne)
    {
      case 0:
        randomDirection = new Vector3(0, 90.0f, 0);
        break;
      case 1:
        randomDirection = new Vector3(0, -90.0f, 0);
        break;
      case 2:
        randomDirection = new Vector3(0, 45.0f, 0);
        break;
      case 3:
        randomDirection = new Vector3(0, -45.0f, 0);
        break;
    }

    Debug.Log("Current Y-axis rotation: " + randomDirection.y);//should see even ammounts.

    transform.Rotate(randomDirection);//rotate this transform to the new random direction everytime this is called.

    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(90, Vector3.up), .05f);      


    //rigidbody.AddRelativeForce(Vector3.forward * 2000);//Could also addForce in the forward vector
  }

  IEnumerator wait()
  {
    while (true)
    {
      firstWaitTime = Random.Range(0.5f, 5.0f);//range between zero and 1? WHY?!
      yield return new WaitForSeconds(firstWaitTime);
      canMove = true;
      forwardUnits = Random.Range(0, 42);
      randMoveForward();
      secondWaitTime = Random.Range(0.0f, 2.0f);//range between zero and 1? WHY?!
      yield return new WaitForSeconds(secondWaitTime);
      canMove = false;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (canMove)
      transform.Translate(Vector3.forward * (Time.deltaTime * forwardUnits), Space.Self);
  }

/*  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "movEnemy")
    {
      Instantiate(movPart, col.transform.position, col.transform.rotation);
      Destroy(gameObject);
    }
  }*/

}
