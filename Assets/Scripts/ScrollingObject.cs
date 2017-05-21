using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollingObject : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        BirdScript.instance.flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        BirdScript.instance.flapButton.onClick.AddListener(() => ScrollBg());
    }
	
	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver == true) {
			rb2d.velocity = Vector2.zero;
		}
	}

    private void ScrollBg()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
    }
}
