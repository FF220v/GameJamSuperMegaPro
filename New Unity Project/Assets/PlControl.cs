using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlControl : MonoBehaviour
{
    public Transform worldDisc;
    public float spX=1f;
    public float spY=1f;
    public LayerMask worldlayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start cntrl");
    }

    // Update is called once per frame
    void Update()
    {
		int dx=0, dy=0;
		float mult=1f;
		if (Input.GetKey("d")){dx++;}
		if (Input.GetKey("w")){dy--;}
		if (Input.GetKey("a")){dx--;}
		if (Input.GetKey("s")){dy++;}
		if((dx+dy)%2==0)mult=0.7f; 

        worldDisc.position+=new Vector3(-dx*mult*spX*.1f,0,0);
        worldDisc.eulerAngles += new Vector3(0,dy*.1f*mult*spY,0);
        if(Physics.CheckBox(transform.position,Vector3.one*.5f,Quaternion.identity,worldlayer))
            Debug.Log("collision!");
        // else Debug.Log("Ncollision!");
    }

    void OnCollisionEnter() {
        // Debug.Log("collision!");
    }
}
