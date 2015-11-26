using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

	bool isDestroyed=false;

	void Start ()
	{
		GetComponent<Rigidbody2D> ().velocity = transform.right * -GameController.speed;
	}

	void Update ()
	{
		if (GameController.isPaused ) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		} else if (GetComponent<Rigidbody2D> ().velocity == Vector2.zero && !isDestroyed) {
			GetComponent<Rigidbody2D> ().velocity = transform.right * -GameController.speed;
		}
	}

	public void StopMoving(){
		isDestroyed = true;
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}
}
