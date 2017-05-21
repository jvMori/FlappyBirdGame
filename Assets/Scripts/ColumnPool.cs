using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour {

	public int columnPoolSize = 5;
	public GameObject columnPrefab;
	public float spawnRate = 1.5f;
	public float columnMin = -0.6f;
	public float columnMax = 0.7f;

	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2 (-5f, -5f);
	private float timeSinceLastSpawned;
	private float spawnXPosition = 3f;
	private int currentColumn = 0;

	// Use this for initialization
	void Start () {
		timeSinceLastSpawned = 0f;

		columns = new GameObject[columnPoolSize];

		for (int i = 0; i < columnPoolSize; i++) {

			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;

		if (GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
			
			timeSinceLastSpawned = 0;

			float spawnYPosition = Random.Range (columnMin, columnMax);

			columns [currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);

			currentColumn++;

			if (currentColumn >= columnPoolSize) {
				currentColumn = 0;
			}
		}
	}
}
