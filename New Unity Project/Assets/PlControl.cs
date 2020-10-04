using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlControl : MonoBehaviour
{
    public Transform worldDisc;
    public float spX=1f, spY=1f, friction=.9f, jump=10f;
    public LayerMask worldlayer=-1, interLayer=-1;
    float freePosX, freePosY, vx, vz;//prefreePosX, prefreePosY,
    bool ePressed=false;
    Interactable target=null;
    Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start cntrl "+LayerMask.NameToLayer("WorldDisc"));
        freePosX=worldDisc.position.x;
        freePosY=worldDisc.eulerAngles.y;
        rb=GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        
		if (Input.GetKeyDown("e")){
            // ePressed=true;
            if(target)target.interact();
        }
		if (Input.GetKey(KeyCode.Space) && Physics.CheckBox(transform.position-Vector3.up*transform.localScale.y*.3f,transform.localScale*.3f,Quaternion.identity,worldlayer)){
           rb.velocity=new Vector3(0,jump,0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(vx!=0||vz!=0){
            if(Physics.CheckSphere(transform.position, GetComponent<CapsuleCollider>().radius, worldlayer)){//Vector3.one*.5f,Quaternion.identity,
                // Debug.Log("collision! ");
                worldDisc.position=new Vector3(freePosX,0,0);
                worldDisc.eulerAngles = new Vector3(0,freePosY,0);
                // worldDisc.position-=new Vector3(vx,0,0);
                // worldDisc.eulerAngles -= new Vector3(0,vy,0);
                vx=-0;
                vz=-vz*.5f;
            }else{
                // if(prefreePosX!=worldDisc.position.x)prefreePosX=freePosX;
                // if(prefreePosY!=worldDisc.eulerAngles.y)prefreePosY=freePosY;
                freePosX=worldDisc.position.x;
                freePosY=worldDisc.eulerAngles.y;
                worldDisc.position+=new Vector3(vx,0,0);
                worldDisc.eulerAngles += new Vector3(0,vz,0);
                // Debug.Log("No collision!");
            }
        }
		int dx=0, dy=0;
		float mult=1f;
		if (Input.GetKey("d")){dx++;}
		if (Input.GetKey("w")){dy--;}
		if (Input.GetKey("a")){dx--;}
		if (Input.GetKey("s")){dy++;}
		if((dx+dy)%2==0)mult=0.7f; 
        vx=(vx-dx*mult*spX*.01f)*friction;
        vz=(vz+dy*mult*spY*.01f)*friction;
        animator.SetFloat("speed", Mathf.Sqrt(50 * vx * vx + vz * vz));

		// if (ePressed){
        //     ePressed=false;
        Collider[] lst=Physics.OverlapSphere(transform.position,1.5f,interLayer);
        Interactable intt=null;
        foreach(var col in lst)if(col.gameObject.GetComponent<Interactable>().activeI)intt=col.gameObject.GetComponent<Interactable>();
        if(intt!=null){
            if(target!=intt){
                if(target)target.unlightMe();
                target=intt;
                target.lightMe();
            }
        }else{
            if(target){target.unlightMe();target=null;}
        }
    }
    public void addSpeed(Vector3 val){
        rb.velocity+=Vector3.up*val.y;
        vx+=val.x;
        vz+=val.z;
    }
}
