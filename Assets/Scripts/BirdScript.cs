using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour {

	public static BirdScript instance;
    
    
    [SerializeField] 
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

    [SerializeField]
    public AudioSource audioSource;

    
    public AudioClip flapClick, pointClip, diedClip;

	private float bounceSpeed = 150f;

	public bool isAlive;
	public bool didFlap;

	public Button flapButton;

	void Awake () {
		if (instance == null) {
			instance = this;
		}

		isAlive = true;

        myRigidBody.isKinematic = true;

		flapButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
        flapButton.onClick.AddListener(() => myRigidBody.isKinematic = false);
        flapButton.onClick.AddListener (() => BirdIsFlapping());

	}


    void FixedUpdate () {

		if (isAlive) {
			if (didFlap) {
				didFlap = false;
                myRigidBody.velocity = Vector2.zero;
                myRigidBody.AddForce(new Vector2(0, bounceSpeed));
                audioSource.PlayOneShot(flapClick);
                anim.SetTrigger ("Flap");
			}
		}
	}


  
	public void BirdIsFlapping(){
		didFlap = true;
	}

  
    void OnCollisionEnter2D()
    {
        myRigidBody.velocity = Vector2.zero;
        isAlive = false;
        anim.SetTrigger("BirdHurt");
        audioSource.clip = diedClip;
        audioSource.Play();
        GameController.instance.BirdDied();
    }

    
}
