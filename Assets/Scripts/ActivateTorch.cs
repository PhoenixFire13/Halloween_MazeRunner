using UnityEngine;
using System.Collections;

public class ActivateTorch : MonoBehaviour {

    Light torch;
    TorchLight torchScript;

	// Use this for initialization
	void Awake () {
        torch = GetComponentInChildren<Light>();
        torchScript = GetComponentInChildren<TorchLight>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Timer.timerOn)
        {
            torch.enabled = true;
            torchScript.enabled = true;
        }
	}
}
