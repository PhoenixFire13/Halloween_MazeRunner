using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartRateDisplay : MonoBehaviour {

    private GUIText txt;

	// Use this for initialization
	void Start () {
        txt = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = "Heart Rate: " + (int)GetComponent<HeartRateManager>().getHR();
    }
}
