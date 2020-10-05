using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerNPC : InterPerson
{
    public GameObject crowd;
    bool soldOut=false;
    void Start()
    {
        base.Start();
        di=new MyDialog(crowd,this);
    }
    class MyDialog:Dialog{
        GameObject crowd;
        SellerNPC np;
        public MyDialog(GameObject crowda,SellerNPC npc){crowd=crowda;np=npc;}
        public override DLine getNextLine(int val=0){
            string str="";
            int code=0, nexts=state+1;
            switch(DAY.n){
                default: 
                    if(np.soldOut)
                        switch(state){
                            case 0:str="Hey, man."; break;
                            case 1:str="Sick tie."; break;
                            case 2:str="You can break free, I think.."; break;
                            default: break;
                        }
                    else
                        switch(state){
                            case 0:str="Hello, how'd you get in here?"; break;
                            case 1:str="You wanna buy all my icecream?"; break;
                            case 2:str="Like ALL off it?"; break;
                            case 3:str="Yeah, Cool. Its yours."; crowd.gameObject.SetActive(false); np.soldOut=true;break;
                            case 4:str="Stay frosty, man."; break;
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
        if(soldOut)crowd.gameObject.SetActive(false);
    }
}
