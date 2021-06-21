using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas DRCanvas;
    [SerializeField] float impactTime = .3f;
    void Start()
    {
        DRCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        DRCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        DRCanvas.enabled = false;
    }
}
