
using UnityEngine;

	[RequireComponent(typeof(Rigidbody))]
public class Controls : MonoBehaviour {
	public Rigidbody rb;
	public float sidewaysForce = 150f;
	public float jumpForce=30f;
	public bool moving=false;
	public SphereCollider spCol;
	public LayerMask groundLays;
	public GameObject floorBlock=null;
	BlockMove bmov;
	SoundMng smn;
	// public bool isGrounded=false;

	void Start(){
		 rb = GetComponent<Rigidbody>();
		spCol=GetComponent<SphereCollider>();
		bmov=FindObjectOfType<BlockMove>();
		smn=FindObjectOfType<SoundMng>();
	}

	void Update(){
		Collider[] lst=getGround();
		if(lst.Length>0){
			if(floorBlock==null || floorBlock!=lst[0].gameObject)setFloorBlock(lst[0].gameObject);
			if(Input.GetKeyDown(KeyCode.Space)){
				rb.velocity=new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
				smn.playSound("jump");
			}
			rb.drag=(moving)?0:8;
		}else{
			rb.drag=0;
			if(floorBlock){
				setFloorBlock(null);
				smn.playSound("jump"); 
			}
		}

	}

	// We marked this as "Fixed"Update because we're using it to mess with physics.
	void FixedUpdate (){
		var dx=0; var dy=0;
		float mult=1f;
		if (Input.GetKey("d")){dx++;}
		if (Input.GetKey("w")){dy--;}
		if (Input.GetKey("a")){dx--;}
		if (Input.GetKey("s")){dy++;}
		if((dx+dy)%2==0)mult=0.7f;
		moving=(dx!=0||dy!=0);
		rb.AddForce(sidewaysForce * Time.deltaTime*dx*mult, 0, -sidewaysForce * Time.deltaTime*dy*mult, ForceMode.VelocityChange);
	}

	private Collider[] getGround(){
		return Physics.OverlapCapsule(spCol.bounds.center,new Vector3(spCol.bounds.center.x,spCol.bounds.min.y-.1f,spCol.bounds.center.z),
			spCol.radius*.2f,	groundLays);
	}

	void setFloorBlock(GameObject fb){
		if(floorBlock)floorBlock.GetComponent<Renderer>().material.color -= new Color(.1f,.1f,.1f,1f);
		floorBlock=fb;
		if(floorBlock){
			floorBlock.GetComponent<Renderer>().material.color += new Color(.1f,.1f,.1f,1f);// = Color.grey;
			bmov.newFloorBlock(floorBlock);
		}
	}
}