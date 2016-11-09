﻿using UnityEngine;
using System.Collections;

public class HeartRateManager : MonoBehaviour {

    public float restingHR, minorHeartRisk, majorHeartRisk, tstep;
    private float currentHR, t;

	// Use this for initialization
	void Start () {
        t = 1.5f;
        currentHR = restingHR;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log((int)returnHRToRest());
	}

    //Returns the heart rate back down to the resting heart rate over time and oscillates slightly above and slightly below the resting heart rate
    public float returnHRToRest ()
    {
        float currentHR = (10.0f / t) + restingHR + (Mathf.Sin(t) * 25 * Mathf.Exp(-(Mathf.PingPong(t , 1.0f) + 2)));
        t += tstep;
        return currentHR;
    }

    //Use the increaseHR method to increase the heart rate by the parameter
    public void increaseHR (float increase)
    {
        float finalHR = currentHR + increase;
        t = 10.0f / (finalHR - restingHR);
    }

    public float getHR ()
    {
        return currentHR;
    }

}