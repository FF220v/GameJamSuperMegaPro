using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected AudPlayer player;
    protected void Start() {

        GameObject.FindObjectOfType<PlControl>().addInter(this);
        player=GameObject.FindObjectOfType<AudPlayer>();
    }
    public bool activeI=true;
    public virtual void lightMe(){
        GetComponent<Renderer>().material.color += new Color(.3f,.3f,.3f);
    }
    public virtual void unlightMe(){
        GetComponent<Renderer>().material.color -= new Color(.3f,.3f,.3f);
    }
    public virtual void interact(int val=0){
        Debug.Log("Interaction!");
    }
    public virtual void justDestroy(){
        gameObject.SetActive(false);
        Debug.Log("Destruction");
    }
    public virtual void startNewDay(int day){
        
        // gameObject.SetActive(true);
    }
}
