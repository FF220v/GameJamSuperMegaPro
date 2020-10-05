using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liv : InterPerson
{
    public InterMoving door;
    void Start()
    {
        base.Start();
        di=new MyDialog(door);
    }
    class MyDialog:Dialog{
        Interactable door;
        public MyDialog(Interactable doora){door=doora;}
        public override DLine getNextLine(int val=0){
            string str="";
            int code=0, nexts=state+1;
            switch(DAY.n){
                case 0:
                    switch(state){
                        case 0:str="Hello"; break;
                        case 1:str="Hello again"; break;
                        case 2:str="Go away"; door.activeI=true; door.interact() ; code=-1; break;
                        default: break;
                    }
                break;
                default: 

                break;
            }
            state=nexts;
            return new DLine(code,str);
        }
    }
    public override void startNewDay(int day)
    {
        base.startNewDay(day);
        
    }
}
