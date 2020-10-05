using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlControl : MonoBehaviour
{
    public Transform worldDisc;
    public float spX=1f, spZ=1f, friction=.9f, jump=10f;
    public float maxSp=3f, minSp=1f, accel=.1f, destroySp=2f;
    public LayerMask worldlayer=-1, interLayer=-1;
    [SerializeField]
    float vx, vz;//prefreePosX, prefreePosY,
    float freePosX, freePosY;
    public Camera playerCamera;
    public GameObject globalLightSource;
    public Material skyboxNight;
    public Material skyboxDay;
    public Material skyboxTransition;
    public Material skyboxTransitionLighter;
    public Material skyboxTransitionDarker;

    bool ePressed=false;
    [SerializeField]
    bool run=false;
    Interactable target=null;
    Rigidbody rb;
    Animator animator;
    public GameObject partiDestr;
    public GameObject partiSpeed;
    [SerializeField]
    int destruTimer=-23;
    List<Interactable> interList=new List<Interactable>();
    int dayNum=0;
    public bool wasOthSide=false;
    Skybox skybox;
    Light globalLight;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start cntrl "+LayerMask.NameToLayer("WorldDisc"));
        freePosX=worldDisc.position.x;
        freePosY=worldDisc.eulerAngles.y;
        rb=GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spZ=minSp;
        skybox = playerCamera.GetComponent<Skybox>();
        globalLight = globalLightSource.GetComponent<Light>();
    }

    private void Update() {
        
		if (Input.GetKeyDown("e")){
            // ePressed=true;
            if(target){
                if(Mathf.Abs(vz)<destroySp)target.interact();// && (Mathf.Abs(rb.velocity.y)<.1)
                else {
                    destroyThing(target);
                }
            } else if(run && destruTimer<=-23)destruTimer=23;
        }
		if (Input.GetKey(KeyCode.Space) && Physics.CheckBox(transform.position-Vector3.up*transform.localScale.y*.3f,transform.localScale*.3f,Quaternion.identity,worldlayer)){
           rb.velocity=new Vector3(0,jump,0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(vx!=0||vz!=0){
            if(Physics.CheckSphere(transform.position, GetComponent<CapsuleCollider>().radius, worldlayer)){//Vector3.one*.5f,Quaternion.identity,
                // Debug.Log("collision! ");
                worldDisc.position=new Vector3(freePosX,0,0);
                worldDisc.eulerAngles = new Vector3(0,freePosY,0);
                // worldDisc.position-=new Vector3(vx,0,0);
                // worldDisc.eulerAngles -= new Vector3(0,vy,0);
                vx=-0;
                vz=-vz*.5f;
                spZ=minSp;
                run=false;
            }else{
                // if(prefreePosX!=worldDisc.position.x)prefreePosX=freePosX;
                // if(prefreePosY!=worldDisc.eulerAngles.y)prefreePosY=freePosY;
                freePosX=worldDisc.position.x;
                freePosY=worldDisc.eulerAngles.y;
                worldDisc.position+=new Vector3(vx,0,0);
                worldDisc.eulerAngles += new Vector3(0,vz,0);
                if(worldDisc.eulerAngles.y>100&&worldDisc.eulerAngles.y<200) wasOthSide=true;
                // Debug.Log("No collision!"+worldDisc.rotation.y);
            }
        }
        int dx=0, dy=0;
		float mult=1f;
		if (Input.GetKey("d")){dx++;}
		if (Input.GetKey("w")){dy--;if(vz<-destroySp){run=true;}if(Mathf.Abs(spZ)<maxSp)spZ+=accel;}
		if (Input.GetKey("a")){dx--;}
		if (Input.GetKey("s")){dy++;run=false; spZ=minSp;}
		if((dx+dy)%2==0)mult=0.7f; 
        vx=(vx-dx*mult*spX*.01f)*friction;
        if(!run){vz=(vz+dy*mult*spZ*.01f)*friction;if(dy==0)spZ=minSp;}
        else {vz=(vz+dy*mult*spZ*.01f);if(dy!=0)vz*=friction;}
        animator.SetFloat("speed", Mathf.Sqrt(50 * vx * vx + vz * vz));

        if(run)partiSpeed.GetComponent<ParticleSystem>().Emit(1);
		// if (ePressed){
        //     ePressed=false;
        Collider[] lst=Physics.OverlapSphere(transform.position,1f,interLayer);
        Interactable intt=null;
        foreach(var col in lst)if(col.gameObject.GetComponent<Interactable>().activeI)intt=col.gameObject.GetComponent<Interactable>();
        if(destruTimer>=-23)destruTimer--;
        if(intt!=null){ 
            if(target!=intt){
                if(target)target.unlightMe();
                if(destruTimer>0){
                    destruTimer=-23;
                    destroyThing(intt);
                }else {
                    target=intt;
                    target.lightMe();
                }
            }
        }else{
            if(target){target.unlightMe();target=null;}
        }

        // Handling other object's stuff
        float rotation = worldDisc.eulerAngles.y;
        animator.SetFloat("speed", Mathf.Sqrt(50 * vx * vx + vz * vz));


        // Selecting day/night depending on disk angle with smooth transitions each 90 degrees
        if (rotation > 270f)
        {
            globalLight.color = new Color(93f / 255f, 113f / 255f, 255f / 255f);
            globalLight.intensity = 0.3f;
        }
        else if (rotation > 180f && rotation < 270f)
        {
            globalLight.color = new Color((255f - 162f * (rotation - 180f) / 90f) / 255f, (255f - 142f * (rotation - 180f) / 90f) / 255f, 255f / 255f);
            globalLight.intensity = 1.4f - 1.1f * (rotation - 180f) / 90f;
        }
        else if (rotation > 90f && rotation < 180f) {
            globalLight.color = new Color(1.0f, 1.0f, 1.0f);
            globalLight.intensity = 1.4f;
        }
        else if (rotation > 0f)
        {
            globalLight.color = new Color((93f + 162f * rotation / 90f) / 255f, (113f + 142f * rotation / 90f) / 255f, 255f / 255f);
            globalLight.intensity = 0.3f + 1.1f * rotation / 90f;
        }

        if (rotation > 270f)
        {
            skybox.material = skyboxNight;
        }
        else if (rotation > 240f && rotation < 270f)
        {
            skybox.material = skyboxTransitionDarker;
        }
        else if (rotation > 210f && rotation < 240f)
        {
            skybox.material = skyboxTransition;
        }
        else if (rotation > 180f && rotation < 210f)
        {
            skybox.material = skyboxTransitionLighter;
        }
        else if (rotation > 90f && rotation < 180f)
        {
            skybox.material = skyboxDay;
        }
        else if (rotation > 30f && rotation < 90f)
        {
            skybox.material = skyboxTransitionLighter;
        }
        else if (rotation > 0f && rotation < 60f)
        {
            skybox.material = skyboxTransition;
        }
        else if (rotation > 0f && rotation < 30f)
        {
            skybox.material = skyboxTransitionDarker;
        }

        skybox.material.SetFloat("_Rotation", worldDisc.eulerAngles.y);

        //skybox.material.SetFloat("_Exposure", 1.5f - 1.2f * rotation / 360);
    }
    void destroyThing(Interactable thing){
        partiDestr.GetComponent<ParticleSystem>().Emit(15);
        thing.justDestroy();
    }
    public void addSpeed(Vector3 val){
        rb.velocity+=Vector3.up*val.y;
        vx+=val.x;
        vz+=val.z;
    }
    public void addInter(Interactable obj){
        interList.Add(obj);
        Debug.Log("SIze  "+interList.Count);
    }
    public void startNextDay(){
        dayNum++;
        Debug.Log("________NEW DAY__________"+dayNum);
        foreach(var intr in interList)intr.startNewDay(dayNum);
    }
}