using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvDialog : MonoBehaviour
{
    Transform pl;

    private void Start() {
        pl=GameObject.FindObjectOfType<PlCamera>().transform;

    }
    // Update is called once per frame
    void Update()
    {
        float dx=pl.position.x-transform.position.x, dz=pl.position.z-transform.position.z;
        Quaternion rotation = Quaternion.Euler(0,Mathf.Atan(dx/dz)*180/3.1415f , 0);
        transform.rotation=rotation;//new Vector3()
    }
}
