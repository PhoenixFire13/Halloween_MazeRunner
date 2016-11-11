using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public static int timeLim = 600;
    public static bool timerOn = false;

    private Text txt;
    public int timeLeft;

    // Use this for initialization
    void Start () {
        txt = GetComponent<Text>();
        txt.text = "Time Left: " + timeLim;
        timeLeft = timeLim;
        timerOn = true;
        StartCoroutine(timer());
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameManager.gameOver || timeLeft == 0)
        {
            StopAllCoroutines();

            if (!GameManager.gameOver)
            {
                GameManager.gameOver = true;
            }
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
