using UnityEngine;
using System.Collections;

public class TorchLight : MonoBehaviour {

    Light torch;
    float rangeAmount;
    float intensityAmount;

	// Use this for initialization
	void Start () {
        torch = GetComponent<Light>();

        rangeAmount = torch.range / Timer.timeLim;
        intensityAmount = torch.intensity / Timer.timeLim;
    }
	
	// Update is called once per frame
	void Update () {
        ChangeRange(rangeAmount);
        ChangeIntensity(intensityAmount);
	}

    void ChangeRange (float amount)
    {
        torch.range -= amount * Time.deltaTime;
    }

    void ChangeIntensity (float amount)
    {
        torch.intensity -= amount * Time.deltaTime;
    }
}
