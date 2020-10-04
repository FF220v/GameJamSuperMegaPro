using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlControl : MonoBehaviour
{
    public Transform worldDisc;
    public float spX=1f, spY=1f, friction=.9f;
    public LayerMask worldlayer, interLayer;
    float freePosX, freePosY, vx, vy;//prefreePosX, prefreePosY,
    bool ePressed=false;
    Interactable target=null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start cntrl");
        freePosX=worldDisc.position.x;
        freePosY=worldDisc.eulerAngles.y;
    }

    private void Update() {
        
		if (Input.GetKeyDown("e")){
            // ePressed=true;
            if(target)target.interact();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool collis=false;
        if(vx!=0||vy!=0){
            if(Physics.CheckSphere(transform.position, GetComponent<CapsuleCollider>().radius, worldlayer)){//Vector3.one*.5f,Quaternion.identity,
                // Debug.Log("collision! ");
                collis=true;
                worldDisc.position=new Vector3(freePosX,0,0);
                worldDisc.eulerAngles = new Vector3(0,freePosY,0);
                // worldDisc.position-=new Vector3(vx,0,0);
                // worldDisc.eulerAngles -= new Vector3(0,vy,0);
                vx=-0;
                vy=-vy*.5f;
            }else{
                // if(prefreePosX!=worldDisc.position.x)prefreePosX=freePosX;
                // if(prefreePosY!=worldDisc.eulerAngles.y)prefreePosY=freePosY;
                freePosX=worldDisc.position.x;
                freePosY=worldDisc.eulerAngles.y;
                worldDisc.position+=new Vector3(vx,0,0);
                worldDisc.eulerAngles += new Vector3(0,vy,0);
                // Debug.Log("No collision!");
            }
        }
        // if(collis)return;
		int dx=0, dy=0;
		float mult=1f;
		if (Input.GetKey("d")){dx++;}
		if (Input.GetKey("w")){dy--;}
		if (Input.GetKey("a")){dx--;}
		if (Input.GetKey("s")){dy++;}
		if((dx+dy)%2==0)mult=0.7f; 
        vx=(vx-dx*mult*spX*.01f)*friction;
        vy=(vy+dy*mult*spY*.01f)*friction;

		// if (ePressed){
        //     ePressed=false;
        Collider[] lst=Physics.OverlapSphere(transform.position,1.5f,interLayer);
        if(lst.Length>0){
            if(target!=lst[0]){
                if(target)target.unlightMe();
                target=lst[0].GetComponent<Interactable>();
                target.lightMe();
            }
        }else{
            if(target){target.unlightMe();target=null;}
        }
    }

    void OnCollisionEnter() {
        // Debug.Log("collision!");
    }
}
