using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	//Player Handling
	public float speed = 8;
	public float acceleration = 12;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	
	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics> ();
	}
	
	// Update is called once per frame
	void Update () {
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		amountToMove.x = currentSpeed;
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}
	
	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if(n == target){
			return n;
		}
		
		else{
			float dir = Mathf.Sign(target - n); //must be increaded or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return(dir == Mathf.Sign(target-n))? n: target; //if n has no passed target then return target, otherwise return n
		}
	}
}
