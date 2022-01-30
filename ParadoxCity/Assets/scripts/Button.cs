using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

	public int what;
	public Animator anim;

    void Start()
    {
		anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
	  
    }

	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.name.Equals ("characterA")) {
			what = 11;
			anim.SetBool ("push", true);
		} 
		else if (collision.gameObject.name.Equals ("characterB"))
		{
				what = 2;
				anim.SetBool ("push", true);
		}
		else
		{
			what = 15;
			anim.SetBool ("push", false);
		}
	}
}
