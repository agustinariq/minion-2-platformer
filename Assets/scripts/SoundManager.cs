using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip jumpSound, coinSound, tremorSound, deathSound;
	public static AudioSource audioSource;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource> ();
		jumpSound = Resources.Load<AudioClip> ("jump");
		coinSound = Resources.Load<AudioClip> ("coin");
		tremorSound = Resources.Load<AudioClip> ("tremor");
		deathSound = Resources.Load<AudioClip>("death");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound(string clip) {
		if (clip == "jump") {
			audioSource.PlayOneShot (jumpSound);
		}
		if (clip == "coin") {
			audioSource.PlayOneShot (coinSound);
		}
		if (clip == "tremor") {
			audioSource.PlayOneShot (tremorSound);
		}
		if (clip == "death") {
			audioSource.PlayOneShot (deathSound);
		}
	
	}
}
