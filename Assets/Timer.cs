using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public int timeLim;
    private Text txt;
    private int timeLeft;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        txt.text = "Time Left: " + timeLim;
        timeLeft = timeLim;
        StartCoroutine(timer());
	}
	
	// Update is called once per frame
	void Update () {
	    if (timeLeft == 0)
        {
            StopAllCoroutines();
        }
	}

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        timeLeft -= 1;
        txt.text = "Time Left: " + timeLeft;
        yield return timer();
    }
}
