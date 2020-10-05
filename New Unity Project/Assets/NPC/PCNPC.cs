using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCNPC : InterPerson
{
    public int typing=0;
    void Start()
    {
        base.Start();
        di=new MyDialog(this);
    }
    class MyDialog:Dialog{
        PCNPC pc;
        public MyDialog(PCNPC p){ pc=p; }
        public override DLine getNextLine(int val=0){
            string str="";
            int code=0, nexts=state+1;
            pc.typing++;
            switch(state){
                case 0:str="Bip Boop"; break;
                case 1:str="Whaoee"; break;
                case 2:str="Bip Boop"; break;
                case 3:str="Whaoe"; break;
                case 4:str="Bip Bop"; break;
                case 5:str="Whaoee"; break;
                case 6:str="Bee Bop"; break;
                case 7:str="Whaoe"; break;
                case 8:str="Pip piip"; break;
                case 9:str="oooo"; break;
                case 10:str="Bip Boop"; break;
                case 11:str="Whaoee"; break;
                case 12:str="Bip Boop"; break;
                case 13:str="Whaoe"; break;
                case 14:str="Bip Bop"; break;
                case 15:str="Whaoee"; break;
                case 16:str="Bee Bop"; break;
                case 17:str="Whaoe"; break;
                case 18:str="Pip piip"; break;
                case 19:str="oooo"; break;
                case 20:str="Bip Boop"; break;
                case 21:str="Whaoee"; break;
                case 22:str="Bip Boop"; break;
                case 23:str="Whaoe"; break;
                case 24:str="Bip Bop"; break;
                case 25:str="Whaoee"; break;
                case 26:str="Bee Bop"; break;
                case 27:str="I'm so fkn tired"; break;
                case 28:str="hour to deadline"; break;
                case 29:str="And all my ideas in garbage again"; break;
                default: break;
            }
            state=nexts;
            return new DLine(code,str);
        }
    }
    public override void startNewDay(int day)
    {
        base.startNewDay(day);
        typing=0;
    }
}
