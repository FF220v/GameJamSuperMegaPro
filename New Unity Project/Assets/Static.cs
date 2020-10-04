using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static
{
    
}

public class Dialog{
    public int state=0;
    public virtual DLine getNextLine(int val=0){
        switch(state){
            case 0: break;
        }
        return null;
    }
}

public class DLine{
    public string str;
    public int code;
    public DLine(int codee, string strr)
    {
       str=strr;
       code=codee;
    }

}