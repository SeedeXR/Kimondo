using System;
using UnityEngine;

public class FireBallVFXController : MonoBehaviour
{
   public GameObject fireballVFX;
   public float cameraShakeIntensity;

   private void OnCollisionEnter(Collision other)
   {
      fireballVFX.SetActive(false);
      
      // camera shake
      
      CinemachineCameraShaker.Instance.ShakeCamera(cameraShakeIntensity, 0.1f);
   }
}
