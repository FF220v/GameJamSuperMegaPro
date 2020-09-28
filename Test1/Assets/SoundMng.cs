using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour
{
	AudioSource aus;
	public AudioClip backSnd;
	public AudioClip jumpSnd;

    void Start()
    {
        aus=GetComponent<AudioSource>();
        // aus.PlayOneShot(backSnd);
    }
    public void playSound(string name){
    	Debug.Log("SOUND");
        aus.PlayOneShot(jumpSnd);
    }
}
