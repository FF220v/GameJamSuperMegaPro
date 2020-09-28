using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform pltr;
    public Transform shaft;
    // Quaternion strtRot;
    
    void Start()
    {   
        // strtRot=transform.rotation;

    }
    // Update is called once per frame
    void Update(){
        Vector3 plpos= pltr.position, pos=transform.position ;
        float dx=plpos.x-pos.x, dy=plpos.y-pos.y, dz=plpos.z-pos.z, ds=Mathf.Sqrt(dx*dx+dz*dz);//FindObjectOfType<Player>()
        // transform.rotation=strtRot+new Vector3(0f,Mathf.Atan2(dx,dz),0f);
        float day=Mathf.Atan2(dx,dz)/Mathf.PI*180-transform.rotation.eulerAngles.y;
        float dax=Mathf.Atan2(ds,dy)/Mathf.PI*180-transform.rotation.eulerAngles.x-100;
        float daz=transform.rotation.eulerAngles.z;//-transform.rotation.eulerAngles.x;//
        // transform.Rotate( 0   , day, 0, Space.Self);//-daz
        transform.eulerAngles += new Vector3(dax,day,0);
        // Debug.Log("ATAN "+Mathf.Atan2(dx,dz)+" "+Mathf.Atan2(ds,dy));
        // transform.position+=new Vector3(0.0f, 1.0f, 0.0f);/
        // Debug.Log(Mathf.Atan2(ds,dy)/Mathf.PI*180+" "+transform.rotation.eulerAngles.x);//transform.rotation.eulerAngles
    }
}
