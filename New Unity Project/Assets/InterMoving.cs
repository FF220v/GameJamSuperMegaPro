using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterMoving : Interactable
{
    [SerializeField]
    Vector3 strtPos, lastPos, targPos, targRot;//, strtRot
    bool move=false, pause=false;
    public float speed=1f;
    public Vector3 dir=Vector3.right;
    Transform tran;
    // public LayerMask playerLayer;
    void Start()
    {
        base.Start();
        tran=transform;
        strtPos=tran.localPosition;
        // strtRot=tran.rotation.eulerAngles;
        targPos=strtPos+dir;
        lastPos=strtPos;
        // Debug.Log("tar "+strtPos+" "+targPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log("par st tar "+par.localPosition+" "+strtPos+" "+targPos);
        if(move&&!pause){
            Vector3 dif=targPos-tran.localPosition;
            if(Mathf.Abs(dif.x)<=.05f&&Mathf.Abs(dif.y)<=.05f&&Mathf.Abs(dif.z)<=.05f){
                tran.localPosition=targPos;
                targPos=lastPos;
                lastPos=tran.localPosition;
                move=false;
            }else{
                // Debug.Log("bef "+dif+" "+tran.position+" "+tran.localPosition+" "+targPos);
                tran.localPosition+=dif*1f;
                // tran.position+=new Vector3(Mathf.Clamp(dif.x*speed,-.1f,.1f),Mathf.Clamp(dif.y*speed,-.1f,.1f),Mathf.Clamp(dif.z*speed,-.1f,.1f));
                if(Physics.CheckBox(transform.position,transform.localScale*.5f,transform.rotation,LayerMask.GetMask("Player")))
                    tran.localPosition-=dif*1f;
                    // tran.position-=new Vector3(Mathf.Clamp(dif.x*speed,-.1f,.1f),Mathf.Clamp(dif.y*speed,-.1f,.1f),Mathf.Clamp(dif.z*speed,-.1f,.1f));
                // Debug.Log("aft "+dif+" "+tran.position+" "+tran.localPosition+" "+targPos);
                // Debug.Log("aft "+tran.position);
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
        Debug.Log("Interaction! MOVING "+targPos);
        move=true;
    }
  public override void startNewDay(int day)
  {
    tran.localPosition=strtPos;
    targPos=strtPos+dir;
    base.startNewDay(day);
  }
}
