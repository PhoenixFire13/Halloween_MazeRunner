using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float turn = Input.GetAxis("Horizontal");
        Turn(turn);
	}

    void Turn (float h)
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            float newRotation = transform.eulerAngles.y + h;
            Quaternion rotation = Quaternion.Euler(0f, newRotation, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time);
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            float newRotation = transform.eulerAngles.y - h;
            Quaternion rotation = Quaternion.Euler(0f, newRotation, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time);
        }
    }
}
