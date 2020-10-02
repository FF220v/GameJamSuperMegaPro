using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -100f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

	BlockMove bmov;
	public GameObject floorBlock=null;

    Vector3 velocity;
    bool isGrounded;
    
private void Start() {
    
    bmov=FindObjectOfType<BlockMove>();
}

    void Update()
    {
		Collider[] lst=getGround();
        isGrounded = lst.Length>0;//Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
			if(floorBlock==null || floorBlock!=lst[0].gameObject)setFloorBlock(lst[0].gameObject);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
	private Collider[] getGround(){
		return Physics.OverlapSphere(groundCheck.transform.position,groundDistance,	groundMask);
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
