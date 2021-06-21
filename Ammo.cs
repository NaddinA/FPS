using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable] //shows class stuff in inspector
    private class AmmoSlot
    {   
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType){ return GetAmmoSlot(ammoType).ammoAmount; }

    public void AmmoConsumption(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }
    
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType  == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
    //create a public method that allows us to increase our current ammo
    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount+=ammoAmount;
    }
}
