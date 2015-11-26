using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static bool isPaused;
	public static float speed;
	public float startSpeed;
	public GameObject ball;
	public float bounceGravityScale;
	public Transform obsticlePlaceholder;
	public GameObject obsticle;
	public float maxSpawnWait;
	public float minSpawnWait;
	public int maxStartWait;
	public int minStartWait;
	public int maxWaveWait;
	public int minWaveWait;
	public int hazardCount;
	int score;
	public Text scoreText;

	// Use this for initialization
	void Start ()
	{
		isPaused = false;
		speed = startSpeed;

		score = 0;

		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			ball.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			ball.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * -10000);
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (Random.Range (minStartWait, maxStartWait));
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Instantiate (obsticle, obsticlePlaceholder.position, obsticlePlaceholder.rotation);
				yield return new WaitForSeconds (Random.Range (minSpawnWait, maxSpawnWait));
			}
			yield return new WaitForSeconds (Random.Range (minWaveWait, maxWaveWait));
		}
	}

	public void incScore ()
	{
		score++;
		scoreText.text = score+"";
	}
}
