using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedField : Field
{
    public InterMoving door;
    protected override void action(){
        PlControl pl=GameObject.FindObjectOfType<PlControl>();
        if(pl.wasOthSide){pl.startNextDay();pl.wasOthSide=false;door.interact();}
    } 
}
