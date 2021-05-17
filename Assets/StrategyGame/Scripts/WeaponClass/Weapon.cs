using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public int attackRadius;
    public int attackType;          //Attack type 1 = Single tile target
                                    //Attack type 2 = blast style target
                                    //attack type 3 = cross style target
    public int damageRadius;
    public int damageAmount;
}
