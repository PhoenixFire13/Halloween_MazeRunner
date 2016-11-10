using UnityEngine;
using System.Collections;

public class ParticlesTrigger : MonoBehaviour {

    ParticleSystem trap;

    // Use this for initialization
    void Awake () {
        trap = GetComponentInParent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trap.Play();

            if (tag == "RedTrap")
            {
                other.gameObject.GetComponentInChildren<HeartRateManager>().increaseHR(40f);
            }
            else if (tag == "BlueTrap")
            {
                other.gameObject.GetComponentInChildren<HeartRateManager>().increaseHR(30f);
            }
            else if (tag == "GreenTrap")
            {
                other.gameObject.GetComponentInChildren<HeartRateManager>().increaseHR(20f);
            }
            else if (tag == "YellowTrap")
            {
                other.gameObject.GetComponentInChildren<HeartRateManager>().increaseHR(10f);
            }

            Destroy(gameObject);
        }
    }
}
