using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<BirdScript> () != null) {
			GameController.instance.BirdScored ();
            BirdScript.instance.audioSource.clip = BirdScript.instance.pointClip;
            BirdScript.instance.audioSource.Play();
		}
	}
}
