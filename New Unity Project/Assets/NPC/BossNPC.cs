using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNPC : InterPerson
{
    public InterMoving door1;
    public InterMoving door21;
    public InterMoving door22;
    public PCNPC pc;
    public GameObject car;
    void Start()
    {
        base.Start();
        di=new MyDialog(door1,door21,door22,pc,car);
    }
    class MyDialog:Dialog{
        Interactable door1;
        Interactable door21;
        Interactable door22;
        PCNPC pc;
        GameObject car;
        public MyDialog(Interactable doora1,Interactable doora2,Interactable doora3,PCNPC pcc,GameObject cara){door1=doora1;door21=doora2;door22=doora3;pc=pcc;car=cara;}
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
                        case 4:str="Have a nice life."; nexts=0;if(door21.activeI)break; door1.activeI=true; door1.interact();door21.activeI=true; door21.interact();door22.activeI=true; door22.interact(); car.SetActive(true); break;
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
                        case 3:str="Go away"; door1.activeI=true; door1.interact(); break;
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
        if(DAY.tower==0)door1.activeI=false;
    }
}
