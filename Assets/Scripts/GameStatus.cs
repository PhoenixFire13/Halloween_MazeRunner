using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameManager.gameOver)
        {
            anim.SetTrigger("GameOver");
        }
	}
}
