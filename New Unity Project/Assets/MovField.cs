using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovField : Field
{
    public Vector3 dir;
    protected override void action(){

            PlControl pl=GameObject.FindObjectOfType<PlControl>();
            pl.addSpeed(dir);
    } 
}