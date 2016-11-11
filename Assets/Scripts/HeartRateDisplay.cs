using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartRateDisplay : MonoBehaviour {

    private Text txt;

	// Use this for initialization
	void Start () {
        txt = GetComponentInChildren<Text>();
        StartCoroutine(updateHR());
	}
	
	// Update is called once per 
    void Update()
    {
        if (GameManager.gameOver)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator updateHR()
    {
        yield return new WaitForSeconds(0.5f);
        txt.text = "" + (int)GetComponent<HeartRateManager>().getHR();
        yield return updateHR();
    }
}
