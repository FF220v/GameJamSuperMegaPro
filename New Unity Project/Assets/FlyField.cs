using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyField : MovField
{
    protected override void action(){

            PlControl pl=GameObject.FindObjectOfType<PlControl>();
            pl.addSpeed(Vector3.up*10f);
            pl.rb.useGravity=false;
            pl.rb.constraints=RigidbodyConstraints.None;
    } 
}
