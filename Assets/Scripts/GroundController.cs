using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {
	public float scrollSpeed;
	public float tileSizeZ;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}

//	void OnTriggerExit2D (Collider2D other)
//	{
//		print (other.gameObject.tag);
//
//		if (other.gameObject.tag.Contains ("worldend")) {
//			this.transform.position.x=this.transform.position.x + this.transform.sc
//		}
//	}
}
