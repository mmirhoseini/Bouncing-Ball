using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
	public Vector2 ballBounce;
	float startGravityScale;
	public GameController gameController;
	public GameObject particle;
	public GameObject sprite;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag.Contains ("ground")) {
			Bounce ();
		} else if (other.gameObject.tag.Contains ("enemy")) {
			GameController.isPaused = true;
			particle.SetActive (true);
			sprite.SetActive (false);
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

			GetComponent<AudioSource> ().Play ();

			Destroy (this.gameObject, 2);	
		}
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.tag.Contains ("ground")) {
			Bounce ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag.Contains ("score")) {
			gameController.incScore ();
		} 
	}

	void Bounce ()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		GetComponent<Rigidbody2D> ().AddForce (ballBounce);
	}

//	void OnTriggerEnter2D (Collider2D other)
//	{
//		if (other.gameObject.tag.Contains ("ground")) {
//			GetComponent<Rigidbody2D> ().AddForce (ballBounce);
//			GetComponent<Rigidbody2D> ().velocity=Vector2.zero;
//		}
//	}
}
