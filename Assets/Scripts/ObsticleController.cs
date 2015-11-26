using UnityEngine;
using System.Collections;

public class ObsticleController : MonoBehaviour
{


	public GameObject sprite;
	public GameObject particle;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag.Contains ("worldend")) {
			DestroyMe ();
		}
	}

	void DestroyMe ()
	{
		particle.SetActive (true);
		sprite.SetActive (false);
		GetComponent<Mover> ().StopMoving ();
		Destroy (this.gameObject,2);	
	}


}
