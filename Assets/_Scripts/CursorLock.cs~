using UnityEngine;
using System.Collections;

public class CursorLock : MonoBehaviour {

  void DidLockCursor() {
    Debug.Log("Locking cursor");
    //guiTexture.enabled = false;
  }

  void DidUnlockCursor() {
    Debug.Log("Unlocking cursor");
    //guiTexture.enabled = true;
  }

  void OnMouseDown() {
    Screen.lockCursor = true;
  }

  private bool wasLocked = false;

  void Update() {
    if(Screen.lockCursor == false)
    {
      if(Input.GetMouseButtonDown(0))
      {
        Screen.lockCursor = true;
      }
    } 

    if (Application.isEditor) { Screen.lockCursor = true; }

    if (Input.GetKeyDown("escape"))
      Screen.lockCursor = false;

    if (!Screen.lockCursor && wasLocked) {
      wasLocked = false;
      DidUnlockCursor();
    } else
      if (Screen.lockCursor && !wasLocked) {
        wasLocked = true;
        DidLockCursor();
      }
  }

}
