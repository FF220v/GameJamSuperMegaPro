using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilNPC : InterPerson
{
    void Start()
    {
        base.Start();
        di=new MyDialog();
    }
    class MyDialog:Dialog{
        public int talks=0;
        public override DLine getNextLine(int val=0){
            string str="";
            int code=0, nexts=state+1;
            switch(talks){
                case 0:
                    switch(state){
                        case 0:str="So, this is it."; break;
                        case 1:str="Are you satisfied?"; break;
                        case 2: break;
                        default: break;
                    }
                break;
                case 1:
                    switch(state){
                        case 0:str="Keep working harder!"; break;
                        case 1:str="There's so much more days"; break;
                        case 2:str="To spend"; break;
                        default: break;
                    }
                break;
                case 2:
                    switch(state){
                        case 0:str="Walking in circles"; break;
                        case 1:str="Won't get you very far."; break;
                        default: break;
                    }
                break;
                case 3:
                    switch(state){
                        case 0:str="Run, sally"; break;
                        case 1:str="RUN"; break;
                        default: break;
                    }
                break;
                case 4:
                    switch(state){
                        case 0:str="High speeds opens"; break;
                        case 1:str="New Horizons.."; break;
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
        if(di.state!=0)((MyDialog)di).talks++;
        base.startNewDay(day);
    }
}
