﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        this.weaponName = "Frag";
        this.attackRadius = 7;
        this.damageRadius = 1;
        this.damageAmount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
