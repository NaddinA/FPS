using System.Runtime.InteropServices.ComTypes;
using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDMG = 20f;
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }
     void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
      int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
      ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
      canShoot = false;
      if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
      {
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.AmmoConsumption(ammoType);
      }
      yield return new WaitForSeconds(timeBetweenShots);
      canShoot = true;
    }

  private void PlayMuzzleFlash()
  {
      MuzzleFlash.Play();
  }

  private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
     {
          CreateImpact(hit);
          EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
          if (target == null) return;
          target.TakeDamage(weaponDMG);
    }
        else { return; }
    }

  private void CreateImpact(RaycastHit hit)
  {
    GameObject impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
    Destroy(impact, .1f);
  }
}
