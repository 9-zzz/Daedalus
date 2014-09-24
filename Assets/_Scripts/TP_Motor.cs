using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TP_Motor : MonoBehaviour
{

  public static TP_Motor Instance;

  private Color myColor;
  public float dashBar = 100;
  public int playerHealth;
  public float dashRechargeRate = 0.5f;
  private bool currentlyDashing = false;
  public AudioClip dashSound;
  public AudioClip doubleJumpSound;
  public GameObject jumpSphere;
  private Component[] DashTrailGroup;
  public Slider DashVisualBar;
  public Slider HealthVisualBar;
  public Slider HealthLerpVisualBar;

  public float ForwardSpeed = 10f;
  public float BackwardSpeed = 2f;
  public float StrafingSpeed = 5f;
  public float SlideSpeed = 10f;
  public float JumpSpeed = 6f;
  public float Gravity = 31f;
  public float TerminalVelocity = 20f;
  public float SlideThreshold = 0.6f;
  public float MaxControllableSlideMagnitude = 0.4f;

  private Vector3 slideDirection;

  public Vector3 MoveVector { get; set; }
  public float VerticalVelocity { get; set; }

  public bool Infinity_Jump = false;
  public int numOfJumps;

  void Awake()
  {
    Instance = this;

    playerHealth = 100;

    if (HealthVisualBar != null)
      HealthVisualBar.value = playerHealth;
  }


  public void UpdateMotor()
  {
    if (playerHealth <= 0)
      Application.LoadLevel(Application.loadedLevel);

    HealthVisualBar.value = playerHealth;

    HealthLerpVisualBar.value = Mathf.Lerp(HealthLerpVisualBar.value, HealthVisualBar.value, (Time.deltaTime*2) );

    if (!currentlyDashing)
      rechargeDashBar();

      DashVisualBar.value = dashBar;

    SnapAllignCharacterWithCamera();
    ProcessMotion();

    if (TP_Controller.CharacterController.isGrounded)
      numOfJumps = 3;

    //Debug.Log("number of jumps left: " + numOfJumps);
  }

  void ProcessMotion()
  {
    //Transform movevector into worldspace relative to our character;s rotation
    MoveVector = transform.TransformDirection(MoveVector);

    //then normalize our movevector if our magnitude is greater than 0, fixes diagonals
    if (MoveVector.magnitude > 1)
      MoveVector = Vector3.Normalize(MoveVector);

    //Apply sliding important placement
    //ApplySlide();

    //Multiply movevector by movespeed
    MoveVector *= MoveSpeed();// now a method, transmission

    //multiply  movevector by delta.time for value per second than per frame
    //MoveVector *= Time.deltaTime;//moved down, was for clarification

    //Reapply Vertical Velocity.y
    MoveVector = new Vector3(MoveVector.x, VerticalVelocity, MoveVector.z);

    //Apply gravity
    ApplyGravity();

    //move the character in worldspace
    TP_Controller.CharacterController.Move(MoveVector * Time.deltaTime);

  }

  void ApplyGravity()
  {
    if (MoveVector.y > -TerminalVelocity)
      MoveVector = new Vector3(MoveVector.x, MoveVector.y - Gravity * Time.deltaTime, MoveVector.z);

    if (TP_Controller.CharacterController.isGrounded && MoveVector.y < -1)
      MoveVector = new Vector3(MoveVector.x, -1, MoveVector.z);
  }

  void ApplySlide()
  {
    if (!TP_Controller.CharacterController.isGrounded)//if not grounded do nothing
      return;

    slideDirection = Vector3.zero;

    RaycastHit hitInfo;

    //cast from 0,1,0 to 0,-1,0 and put out into hitInfo
    if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hitInfo))
    {
      Debug.DrawLine(transform.position + Vector3.up, Vector3.down);

      if (hitInfo.normal.y < SlideThreshold)
        slideDirection = new Vector3(hitInfo.normal.x, -hitInfo.normal.y, hitInfo.normal.z);
    }

    if (slideDirection.magnitude < MaxControllableSlideMagnitude)
    {
      MoveVector += slideDirection;
    }
    else
    {
      MoveVector = slideDirection;

    }

  }

  public void createJumpSphere()
  {
    if (jumpSphere != null)
    {
      Instantiate(jumpSphere, transform.position, transform.rotation);
    }
  }

  public void Jump()
  {
    if (numOfJumps > 0)
    {
      GameObject.Find("Player").GetComponent<SendingPositiveVibes>().lowVibration = 1;
      GameObject.Find("Player").GetComponent<SendingPositiveVibes>().highVibration++;

      numOfJumps--;

      if (numOfJumps <= 1)
      {
        createJumpSphere();
        audio.PlayOneShot(doubleJumpSound);
      }

      VerticalVelocity = JumpSpeed;
    }

    //else if(TP_Controller.CharacterController.isGrounded ){//if on the ground. important for double jump or jet
    //Infinity_Jump = true;
    //numOfJumps=1;
    //}
  }

  void SnapAllignCharacterWithCamera()
  {
    if (MoveVector.x != 0 || MoveVector.z != 0)
    {
      transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
          Camera.main.transform.eulerAngles.y,
          transform.eulerAngles.z);
    }
  }

  float MoveSpeed()
  {
    var moveSpeed = 0f;//local var, need f

    switch (TP_Animator.Instance.MoveDirection)
    {
      case TP_Animator.Direction.Stationary:
        //moveSpeed /= 1.09f;
        moveSpeed = 0;
        currentlyDashing = false;
        disTrails();
        break;

      case TP_Animator.Direction.Forward:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(ForwardSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = ForwardSpeed;
          currentlyDashing = false;
        }
        break;

      case TP_Animator.Direction.Backward:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(BackwardSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = BackwardSpeed;
          currentlyDashing = false;
        }

        break;

      case TP_Animator.Direction.Left:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(StrafingSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = StrafingSpeed;
          currentlyDashing = false;
        }

        break;

      case TP_Animator.Direction.Right:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(StrafingSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = StrafingSpeed;
          currentlyDashing = false;
        }

        break;

      case TP_Animator.Direction.LeftForward:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(ForwardSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = ForwardSpeed;
          currentlyDashing = false;
        }
        break;

      case TP_Animator.Direction.RightForward:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(ForwardSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = ForwardSpeed;
          currentlyDashing = false;
        }
        break;


      case TP_Animator.Direction.LeftBackward:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(BackwardSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = ForwardSpeed;
          currentlyDashing = false;
        }
        break;

      case TP_Animator.Direction.RightBackward:

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetButton("Dash")))
        {
          moveSpeed = doDash(BackwardSpeed);
        }
        else
        {
          disTrails();
          moveSpeed = ForwardSpeed;
          currentlyDashing = false;
        }
        break;

    }

    if (slideDirection.magnitude > 0)
      moveSpeed = SlideSpeed;

    disTrails();
    return moveSpeed;

  }

  void rechargeDashBar()
  {
    if (dashBar <= 100)
    {
      dashBar+= dashRechargeRate;//when not dashing
    }
  }

  public float doDash (float speedToIncrease)
  {
    if (dashBar > 0)
    {
      currentlyDashing = true;
      speedToIncrease *= 3;
      audio.PlayOneShot(dashSound);
      dashBar--;
      enableTrails();
      myColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));//rgb
      renderer.material.SetColor("_OutlineColor", myColor);
      return speedToIncrease;
    }
    else
    {
      return speedToIncrease;
    }
  }

  void enableTrails()
  {
    //transform.Find("dashTrail2").GetComponent<TrailRenderer>().enabled = true;
    //transform.Find("dashTrail").GetComponent<TrailRenderer>().enabled = true;
    DashTrailGroup = GetComponentsInChildren<TrailRenderer>();
    foreach (TrailRenderer trail in DashTrailGroup)
    {
      trail.enabled = true;
      trail.time = 1;
    }
  }

  void disTrails()//this method needs game time to fully work.
  {
    DashTrailGroup = GetComponentsInChildren<TrailRenderer>();
    foreach (TrailRenderer trail in DashTrailGroup)
    {
      trail.time -= 0.009f;

      if (trail.time == 0)
        trail.time = 0;
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("EnemyBullet"))
    {
      iTween.ShakePosition(gameObject, iTween.Hash("x", 0.5f, "y", 0.5f, "z", 0.5f, "time", 0.25f));
      playerHealth -= 5;
      GameObject.Find("Player").GetComponent<SendingPositiveVibes>().highVibration++;
    }

  }

  //void OnControllerColliderHit(ControllerColliderHit hit) { }

}//End of class