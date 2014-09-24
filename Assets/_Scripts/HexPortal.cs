﻿using UnityEngine;

public class HexPortal : MonoBehaviour
{

  public float rotationsPerSecond = 0.1f;
  public bool Activated = false;
  public bool AllHexEnemysDestroyed = false;
  public Object[] hexEnemies;
  public AudioClip PortalActivated;
  bool soundPlayed = false;
  public GameObject theCamera;
  public string levelToLoad;

  void Update ()
  {

    checkIfAllEnemiesAreDead();

    if (AllHexEnemysDestroyed)
    {

      Activated = true;
      
      if (!soundPlayed)
      {
       AudioSource.PlayClipAtPoint(PortalActivated, theCamera.transform.position);
        soundPlayed = true;
      }
    }

    if (Activated)
    {
      Vector3 euler = transform.localEulerAngles;
      euler.x += rotationsPerSecond * 360f * Time.deltaTime;
      euler.y += (rotationsPerSecond * 4) * 360f * Time.deltaTime;
      euler.z += rotationsPerSecond * 360f * Time.deltaTime;
      transform.localEulerAngles = euler;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (Activated)
    {
      if (other.CompareTag("Player"))
      {
        Application.LoadLevel(levelToLoad);
      }
    }
  }

  void checkIfAllEnemiesAreDead()
  {
      hexEnemies = GameObject.FindGameObjectsWithTag("EnemyBullet");

      if (hexEnemies.Length == 0)
        AllHexEnemysDestroyed = true;
  }

}