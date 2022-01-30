using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
	public int what;
	public Transform pos1,pos2;
	public float speed = 1;
	public Transform startPos;

	Vector3 nextPos;

    void Start()
    {
		nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = Vector3.MoveTowards (transform.position, nextPos, speed * Time.deltaTime);

		if (transform.position == pos1.position)  
		{
			nextPos = pos2.position;

		}
		if (transform.position == pos2.position)  
		{
			nextPos = pos1.position;

		}

			 
    
	}

	//private void OnDrawGizmos()
	//{
	//	Gizmos.DrawLine (pos1.position, pos2.position);
	//}

	//private void OnCollisionEnter2D (Collision2D collision)
	//{
		//if (collision.gameObject.name.Equals ("characterA")) {
			//what = 11;
			//transform.position = new Vector2 (transform.position.x + 2, transform.position.y); 
		//} 
		//else if (collision.gameObject.name.Equals ("characterB"))
		//{
			//what = 2;
			//transform.position = new Vector2 (transform.position.x + 2, transform.position.y); 
		//}
		//else
		//{
		//	what = 15;
		//	transform.position = new Vector2 (transform.position.x - 2, transform.position.y);
		//}
	//}
}
