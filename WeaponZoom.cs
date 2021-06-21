using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
   [SerializeField] Camera fpsCam;
   [SerializeField] RigidbodyFirstPersonController fpsController;
   [SerializeField] float FOVZoomIn = 20f;
   [SerializeField] float FOVZoomOUT = 60f;
   [SerializeField] float zoomOutSensitivity = 2f;

    float zoomInSensitivity = .5f;
    bool zoomedInToggle = false;
    private void OnDisable()
    {
        ZoomOut();
    }
    private void Update()
       {
           ZoomInOut();
       }
   void ZoomInOut()
   {
       if(Input.GetMouseButtonDown(1))
       {
           if(zoomedInToggle == false)
      {
        ZoomIn();
      }
      else
      {
        ZoomOut();
      }
    }
   }

  private void ZoomIn()
  {
    zoomedInToggle = true;
    fpsCam.fieldOfView = FOVZoomIn;
    fpsController.mouseLook.XSensitivity = zoomInSensitivity;
    fpsController.mouseLook.YSensitivity = zoomInSensitivity;
  }
    private void ZoomOut()
  {
    zoomedInToggle = false;
    fpsCam.fieldOfView = FOVZoomOUT;
    fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
    fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
  }
}
