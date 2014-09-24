using UnityEngine;
using System.Collections;

public class HexPortal2 : MonoBehaviour
{
  public ParticleSystem portalByebye;
  public float rotationsPerSecond = 0.1f;
  public bool yielded = false;

  void Update ()
  {
      Vector3 euler = transform.localEulerAngles;
      euler.x += rotationsPerSecond * 360f * Time.deltaTime;
      euler.y += (rotationsPerSecond * 4) * 360f * Time.deltaTime;
      euler.z += rotationsPerSecond * 360f * Time.deltaTime;
      transform.localEulerAngles = euler;
      StartCoroutine(MyMethod2());
      StartCoroutine(MyMethod());

  }

  IEnumerator MyMethod() {
 yield return new WaitForSeconds(8);
 Instantiate(portalByebye, transform.position, transform.rotation);
      Destroy(gameObject);
}
  IEnumerator MyMethod2()
  {
  if(!yielded)
  {
    yield return new WaitForSeconds(1);
    yielded = true;
  }
      transform.Translate(Vector3.left * (Time.deltaTime * 40), Space.World);
  }
}