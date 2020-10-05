using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNPC : InterPerson
{
    public InterMoving door;
    public InterPC pc;
    void Start()
    {
        base.Start();
        di=new MyDialog(door,pc);
    }
    class MyDialog:Dialog{
        Interactable door;
        InterPC pc;
        public MyDialog(Interactable doora,InterPC pcc){door=doora;pc=pcc;}
        public override DLine getNextLine(int val=0){
            string str="";
            int code=0, nexts=state+1;
            switch(DAY.n){
                case 3:
                    switch(state){
                        case 0:str="Mr Dare, we are pleased"; break;
                        case 1:str="to inform you"; break;
                        case 2: str="that you are promoted"; break;
                        case 3: str="to the Second floor."; break;
                        case 4:str="Have a nice life."; door.activeI=true; door.interact(); nexts=0; break;
                        default: break;
                    }
                break;
                default: 
                if(DAY.tower==0)
                    switch(state){
                        case 0:str="Mr Dare."; break;
                        case 1:str="Take your seat and do typing"; break;
                        case 2: 
                            if(pc.typing==0){str="Go Do Typing, Mr Dare!"; nexts=2;}
                            else if(pc.typing<3){str="Now Do More Typing."; nexts=2;}
                            else str="You're free. For next 10 hours.";
                         break;
                        case 3:str="Go away"; door.activeI=true; door.interact(); break;
                        default: break;
                    }
                else
                    switch(state){
                        case 0:str="Mr Dare."; break;
                        case 1:str="Good Day"; break;
                        default: break;
                    }
                break;
            }
            state=nexts;
            return new DLine(code,str);
        }
    }
    public override void startNewDay(int day)
    {
        base.startNewDay(day);
        if(DAY.tower==0)door.activeI=false;
    }
}
