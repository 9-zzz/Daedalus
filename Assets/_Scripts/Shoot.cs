using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shoot : MonoBehaviour
{

  public Slider VisualAmmoBar;
  public Slider SpecialAttackBar;
  public AudioClip shootSound;
  public AudioClip fullSpecialSound;
  public AudioClip shootSpecialSound;
  public GameObject spawnPoint;
  public GameObject bulletPF;
  public GameObject specialBeamPF;
  public GameObject Character;
  private GameObject DangerZone;
  private GameObject projectile;
  private GameObject specialBeam;
  public bool isSomeState = false;
  public bool fullSpecial = false;
  public bool firingSpecial = false;
  public int ammo = 120;
  public float special = 0;
  float shootForce = 99;
  float fireRate = 0.07f;
  float timer = 0;
  float mixPar = 0;
  float RTVal;

  void fireSpecialAttack()
  {
    firingSpecial = true;

    specialBeam = Instantiate(specialBeamPF, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
    specialBeam.transform.Rotate(90, 0, 0);

    RaycastHit hit;

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//straight ray to mouse position
    //Ray ray = Camera.main.ScreenPointToRay( new Vector2(Screen.width/2, Screen.height/2));

    Vector3 aimPoint;//hit point placeholder

    if (Physics.Raycast(ray, out hit, 100))
    {//where the ray hits, so draw from anywhere to THIS = raycast from new THAT 
      aimPoint = hit.point;
    }
    else
    {                                        //if  ray doesn't hit anything, just make a point 100 units out into ray, to referece
      aimPoint = ray.origin + (ray.direction * 100);//aimPoint is some point 100 unitys into ray line
    }
    specialBeam.transform.LookAt(aimPoint);          //fixes when hit point was = (0,0,0);

  }

  void Fire()
  {
    if (ammo > 0)
    {
      GameObject.Find("Player").GetComponent<SendingPositiveVibes>().highVibration++;

      audio.PlayOneShot(shootSound);

      RaycastHit hit;

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//straight ray to mouse position
      //Ray ray = Camera.main.ScreenPointToRay( new Vector2(Screen.width/2, Screen.height/2));

      Vector3 aimPoint;//hit point placeholder

      if (Physics.Raycast(ray, out hit, 100))
      {//where the ray hits, so draw from anywhere to THIS = raycast from new THAT 
        aimPoint = hit.point;
      }
      else
      {                                        //if  ray doesn't hit anything, just make a point 100 units out into ray, to referece
        aimPoint = ray.origin + (ray.direction * 100);//aimPoint is some point 100 unitys into ray line
      }

      projectile = Instantiate(bulletPF, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

      projectile.transform.LookAt(aimPoint);          //fixes when hit point was = (0,0,0);

      Debug.DrawLine(spawnPoint.transform.position, aimPoint);

      Physics.IgnoreCollision(projectile.collider, Character.collider);

      projectile.rigidbody.velocity = projectile.transform.forward * shootForce;//this plus the LookAt aimpoint sends a bullet on the correct ray

      timer = 0;

      ammo--;

    }

  }

  void Update()
  {
    RTVal = Input.GetAxis("RightTrigger");

    if (VisualAmmoBar != null)
      VisualAmmoBar.value = ammo;

    if (SpecialAttackBar != null)
      SpecialAttackBar.value = special;

    if (ammo >= 120)
      ammo = 120;

    if (special >= 100)
    {
      //ammo += (120-ammo);//refill ammo
      fullSpecial = true;
      //audio.PlayOneShot(fullSpecialSound);
      special = 100;//stay at full no more no less
      //bar's color
    }

    timer += Time.deltaTime;

    if (Input.GetButton("Fire1") && (timer > fireRate) || ((RTVal > 0) && (timer > fireRate)) && !firingSpecial)
    {
      Fire();
    }

    if ((Input.GetKey("x") || Input.GetButton("RightStickPress")) && special > 0.01)
    {
      if (specialBeam != null && specialBeam.transform.localScale.z < 50)
      {

        TP_Motor.Instance.MoveVector = new Vector3(0, 0, 0);
        audio.PlayOneShot(shootSpecialSound);
        specialBeam.transform.localScale += new Vector3(0.4f, 0.4f, 1f);
        iTween.ShakePosition(specialBeam, iTween.Hash("x", 0.5f, "y", 0.5f, "z", 0.5f, "time", 0.5f));
      }
    }
    else if (specialBeam != null && specialBeam.transform.localScale.y >= 0)
    {
      specialBeam.transform.localScale -= new Vector3(0.3f, 0.3f, 0f);
      iTween.ShakePosition(specialBeam, iTween.Hash("x", 0.1f, "y", 0.1f, "z", 0.1f, "time", 0.25f));

      if (specialBeam != null && specialBeam.transform.localScale.y <= 0)
        Destroy(specialBeam);
    }
    //--------------------------------------------

    if (fullSpecial && (Input.GetKeyDown("x") || Input.GetButton("RightStickPress")))
    {
      fireSpecialAttack();
      fullSpecial = false;
    }

    if (firingSpecial)
    {
      mixPar += Time.deltaTime * 0.5f;
      special = Mathf.Lerp(special, 0, mixPar);

      if (special == 0)
      {
        firingSpecial = false;
        mixPar = 0;
      }
    }
    //Debug.Log("mixpar is = " + mixPar);

    if (Input.GetKeyDown("p"))
      special = 100;
  }//end update

}//end of class