using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterPC : Interactable
{
    public int typing=0;
    
    public override void interact(int val){
        Debug.Log("Interaction! PC");
        typing++;
    }
    
    public override void startNewDay(int day)
    {
        typing=0;
    }
}
