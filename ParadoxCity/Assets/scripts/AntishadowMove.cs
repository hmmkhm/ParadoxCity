using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntishadowMove : MonoBehaviour
{
	public Rigidbody2D rb;
	public Vector2 moveVector;
	public int speed = 2;
	public int fastSpeed = 4;
	private int realSpeed;
	public Animator anim;
	public SpriteRenderer sr;
	public bool faceRight = true;
    void Start()
    {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
		realSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
		Walk ();
		Run ();
		Reflect();
		Jump ();
		CheckingGround ();

    }
	void Walk()
	{
		moveVector.x = Input.GetAxis("Horizontal");
		anim.SetFloat ("moveX", Mathf.Abs (moveVector.x));
		rb.velocity = new Vector2(moveVector.x * realSpeed, rb.velocity.y);

	}

	//void Reflect()
	//{
		//if ((moveVector.x > 0 && !faceRight || moveVector.x < 0 && faceRight)) 
		//{
			//transform.localScale *= new Vector2 (-1, 1);
			//faceRight = !faceRight;
		//}
	//}
	//public bool faceRight = true;
	void Reflect()
	{
		if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
		{
			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
			faceRight = !faceRight;
		}
	}
	public float jumpForce = 50f;


	void Jump()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow) && onGround) 
		{
			//rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
			rb.AddForce(Vector2.up * jumpForce);
		}
	}
	public bool onGround;
	public Transform GroundCheck;
	public float checkRadius = 0.5f;
	public LayerMask Ground;

	void CheckingGround ()
	{
		onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
		anim.SetBool ("onGround", onGround);
	}
	void Run()
	{
		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			anim.SetBool ("run", true);
			realSpeed = fastSpeed;
		} 
		else 
		{
			anim.SetBool ("run", false);
			realSpeed = speed;
		}
	}


}