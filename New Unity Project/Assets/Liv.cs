using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liv : InterPerson
{
    public InterMoving door;
    // Start is called before the first frame update
    void Start()
    {
        di=new LivDialog(door);
    }
    class LivDialog:Dialog{
        InterMoving door;
        public LivDialog(InterMoving doora){door=doora;}
        public override DLine getNextLine(int val=0){
            string str="";
            int code=0, nexts=state+1;
            switch(state){
                case 0:str="Hello"; break;
                case 1:str="Hello again"; break;
                case 2:str="Go away"; door.activeI=true; door.interact() ; code=-1; break;

            }
            state=nexts;
            return new DLine(code,str);
        }
    }
}
