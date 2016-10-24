using UnityEngine;
using System.Collections;

public class DelaySoundEffect : MonoBehaviour {

    AudioSource aud;

    public float delayTime;

	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
        StartCoroutine("InitialWaitAndPlay");
    }

	// Update is called once per frame
	IEnumerator InitialWaitAndPlay()
    {
        yield return new WaitForSeconds(delayTime);
        aud.Play();

        StartCoroutine("InitialWaitAndPlay");
    }
}
