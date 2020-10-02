using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class SOUND_MNG
{
    static AudioClip ac1;
    static AudioSource as1;

    static public void Init(){
        ac1=Resources.Load<AudioClip>("hoo");
        // as1=
        // as1.loop=false;
        // as1.clip=ac1;
    }

    static public void playSound(){
        // Debug.Log("SOUND-- -"+ac1+" "+as1);
        // as1.Play();
    }
}
