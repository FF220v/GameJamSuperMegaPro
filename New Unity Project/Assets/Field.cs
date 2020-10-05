using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int timer=0;
    private void FixedUpdate() {
        // Debug.Log("fld");
        if(timer>0)timer--;
        if(timer<=0&&Physics.CheckBox(transform.position,transform.localScale*.5f,transform.rotation,LayerMask.GetMask("Player"))){
            timer=20;
            action();
        }
    }
    protected virtual void action(){

    } 
}
