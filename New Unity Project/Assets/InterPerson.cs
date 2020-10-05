using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterPerson : Interactable
{
    protected Dialog di;
    public Text txt; 
    string aname="Person";
    // PlControl pl;

    // private void Start() {
    //     pl=GameObject.FindObjectOfType<PlControl>();
    // }
    // private void Update() {
    //     // if((pl.transform.position-transform.position).magnitude>5){
    //     //     Debug.Log("unconnect");
    //     // }
    // }

    public override void interact(int val=0){
        DLine ln=di.getNextLine(val);
        if(ln==null){
            activeI=false;
        }else{
            Debug.Log(aname+":"+ln.str);
            txt.text=ln.str;
        }
    }
    public override void startNewDay(int day)
    {
        di.state=0;
        
    }
}
