using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntishadowMove : MonoBehaviour
{
	public Rigidbody2D rb;
	public Vector2 moveVector;
	public float speed = 2f;
	public Animator anim;
	public SpriteRenderer sr;
	public bool faceRight = true;
    void Start()
    {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
		Walk ();
		//Flip ();
		Reflect();

    }
	void Walk()
	{
		moveVector.x = Input.GetAxis("Horizontal");
		anim.SetFloat ("moveX", Mathf.Abs (moveVector.x));
		rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

	}

	void Reflect()
	{
		if ((moveVector.x > 0 && !faceRight || moveVector.x < 0 && faceRight)) 
		{
			transform.localScale *= new Vector2 (-1, 1);
			faceRight = !faceRight;
		}
	}

	void Flip()
	{
		//if (moveVector.x > 0) 
		//{
		//	sr.flipX = false;
		//} else if (moveVector.x < 0) 
		//{
		//	sr.flipX - true;
		//}
		sr.flipX = moveVector.x < 0;
	}
}
