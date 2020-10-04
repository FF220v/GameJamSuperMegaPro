using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovField : MonoBehaviour
{
    public Vector3 dir;
    public int timer=0;
    private void FixedUpdate() {
        if(timer>0)timer--;
        if(timer<=0&&Physics.CheckBox(transform.position,transform.localScale*.5f,transform.rotation,LayerMask.GetMask("Player"))){
            PlControl pl=GameObject.FindObjectOfType<PlControl>();
            pl.addSpeed(dir);
            timer=20;
        }

    }
}