using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip door;
    public AudioClip talk1;
    public AudioClip talk2;
    public AudioClip talk3;
    public AudioClip talk4;

    public void playS(string nm){
                Debug.Log(" __ "+nm);src.volume=.7f;
        switch(nm){
            case "door":src.clip=door;src.volume=.1f; break;
            case "talk":
                Debug.Log("LOF");
                if(Random.value<.5f){
                    src.clip=talk1;
                }else if(Random.value<.5f){
                    src.clip=talk2;     
                }else if(Random.value<.5f){
                    src.clip=talk3;     
                }else{src.clip=talk4;}
             break;
            
        }
        src.Play();
    }
}
