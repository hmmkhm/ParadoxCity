using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

	public float dumping = 1.5f;
	public Vector2 offset = new Vector2(2f,1f);
	public bool isLeft;
	public Transform player;
	private int lastX;



    void Start()
    {
		offset = new Vector2 (Mathf.Abs (offset.x), offset.y);
		FindPlayer (isLeft);
    }

    // Update is called once per frame
    void Update()
    {
		if (player) 
		{
			int currentX = Mathf.RoundToInt (player.position.x);
				if (currentX > lastX) isLeft = false; else if (currentX < lastX) isLeft = true;
				lastX = Mathf.RoundToInt(player.position.x);
			Vector3 target;
			if (isLeft)
			{
				target = new Vector3 (player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
			}
			else
			{
				target = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
			}

			Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
			transform.position = currentPosition;
		}
    }

	public void FindPlayer(bool playerIsLeft)
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		lastX = Mathf.RoundToInt (player.position.x);
		if (playerIsLeft) 
		{
			transform.position = new Vector3 (player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
		}
		else 
		{
			transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
		}
	}
}
