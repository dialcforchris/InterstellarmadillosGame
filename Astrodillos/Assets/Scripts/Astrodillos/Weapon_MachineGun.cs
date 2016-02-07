using UnityEngine;
using System.Collections;

public class Weapon_MachineGun : Weapon 
{
    void Awake()
    {
        coolDown = 0.15f;
    }
    
}
