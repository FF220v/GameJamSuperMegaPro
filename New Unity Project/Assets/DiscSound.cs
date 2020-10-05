using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSound : MonoBehaviour
{
    public AudioClip backHome;
    public AudioClip backTower;
    public AudioClip backBar;
    public AudioClip backDream;
    public AudioSource src;
    public float ang1,ang2,ang3;//,ang4,ang5
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            float ay=transform.rotation.eulerAngles.y;
            // Debug.Log(" ay "+ay);
        if(!src.isPlaying){
            if(ay>ang1){
                src.PlayOneShot(backHome);
            }else if(ay>ang2){
                src.PlayOneShot(backTower);
            }else if(ay>ang3){
                src.PlayOneShot(backBar);
            }else{
                src.PlayOneShot(backDream);
            }
        }
    }
}
