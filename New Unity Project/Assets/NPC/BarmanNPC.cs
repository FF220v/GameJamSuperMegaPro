using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarmanNPC : InterPerson
{
    public MovField jumps;
    void Start()
    {
        base.Start();
        di=new MyDialog(jumps);
    }
    class MyDialog:Dialog{
        MovField jumps;
        public MyDialog(MovField jumpsa){jumps=jumpsa;}
        public override DLine getNextLine(int val=0){
            string str="";
            int code=0, nexts=state+1;
            switch(DAY.n){
                case 0:
                    switch(state){
                        case 0:str="Hello, Sal"; break;
                        case 1:str="I've heard you made it!"; break;
                        case 2:str="Round on the house!"; break;
                        case 3:str="Don't forget your pal!"; break;
                        case 4:str="Maybe you've had enough.."; break;
                        case 5:str="Do not turn back"; jumps.gameObject.SetActive(true);break;
                        default: break;
                    }
                break;
                case 1:
                    switch(state){
                        case 0:str="Greetings my fellow!"; break;
                        case 1:str="As always, right?"; break;
                        case 2:str="Such a Suitable job"; break;
                        case 3:str="Don't forget your pal!"; break;
                        case 4:str="Maybe you've had enough.."; break;
                        case 5:str="Do not turn back"; jumps.gameObject.SetActive(true);break;
                        default: break;
                    }
                break;
                default: 
                    switch(state){
                        case 0:str=(Random.value>.5)?"Evening, Sal.":"Sal."; break;
                        case 1:str=(Random.value>.5)?"As always, right?":"Waht to try something new?"; break;
                        case 5:str="Take care"; jumps.gameObject.SetActive(true);break;
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
        
    }
}
