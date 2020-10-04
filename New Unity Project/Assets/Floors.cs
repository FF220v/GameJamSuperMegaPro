using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floors : MonoBehaviour
{
    Transform pl;
    public int xdist=4,zdist=4, floorH=2;
    public GameObject[] floors;
    int inside=100;
    // Start is called before the first frame update
    void Start()
    {
        pl=GameObject.FindObjectOfType<PlControl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        int newins=inside;
        Vector3 dist=pl.position-transform.position;
        if(Mathf.Abs(dist.x)<xdist && Mathf.Abs(dist.z)<zdist){
            newins=(int)Mathf.Floor(pl.position.y/floorH);
            // Debug.Log(inside+" "+dist);
        }else{
            newins=100;
        }
        if(inside!=newins){
            inside=newins;
            for(int i=0;i<floors.Length;i++){
                    DisableAllRenderers(floors[i],i<inside);
                }
        }
    }
    void DisableAllRenderers(GameObject obj, bool val)
    {
        Renderer[] allRenderers;
        allRenderers = obj.GetComponentsInChildren< Renderer >();
        foreach(var re in allRenderers ){ re.enabled = val; }
    }
}
