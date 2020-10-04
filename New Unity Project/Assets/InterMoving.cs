using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterMoving : Interactable
{
    Vector3 strtPos, targPos, strtRot, targRot;
    bool move=false, pause=false;
    public float speed=1f;
    public Vector3 dir=Vector3.right;
    Transform par;
    // public LayerMask playerLayer;
    void Start()
    {
        par=transform;
        strtPos=par.localPosition;
        strtRot=par.rotation.eulerAngles;
        targPos=strtPos+dir;
        Debug.Log("tar "+strtPos+" "+targPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log("par st tar "+par.localPosition+" "+strtPos+" "+targPos);
        if(move&&!pause){
            Vector3 dif=targPos-par.localPosition;
            if(Mathf.Abs(dif.x)<=.05f&&Mathf.Abs(dif.y)<=.05f&&Mathf.Abs(dif.z)<=.05f){
                par.localPosition=targPos;
                targPos=strtPos;
                strtPos=par.localPosition;
                move=false;
            }else{
                par.position+=new Vector3(Mathf.Clamp(dif.x*speed,-.1f,.1f),Mathf.Clamp(dif.y*speed,-.1f,.1f),Mathf.Clamp(dif.z*speed,-.1f,.1f));
                if(Physics.CheckBox(transform.position,transform.localScale*.5f,transform.rotation,LayerMask.GetMask("Player")))
                    par.position-=new Vector3(Mathf.Clamp(dif.x*speed,-.1f,.1f),Mathf.Clamp(dif.y*speed,-.1f,.1f),Mathf.Clamp(dif.z*speed,-.1f,.1f));
                // Debug.Log(" "+dif);
            }
        }
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //         Debug.Log("Touched a rail");
    //     if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
    //     {

    //     }
    // }
    
    public override void interact(int val=0){
        Debug.Log("Interaction! MOVING");
        move=true;
    }
}
