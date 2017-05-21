using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	public float scrollSpeed = -1f;
	public Text scoreText;


    private int score = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

        if (MenuManager.turnOnOff)
        {
            AudioListener.volume = 1f;
        } else
        {
            AudioListener.volume = 0f;
        }
	}
	

	public void BirdScored () {
		if (gameOver) {
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void BirdDied () {
		gameOverText.SetActive (true);
		gameOver = true;
        StartCoroutine("GoToMenu");
	}


    private IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menu");
    }

}
