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
                HeartRateManager.increaseHR(40f);
            }
            else if (tag == "BlueTrap")
            {
                HeartRateManager.increaseHR(30f);
            }
            else if (tag == "GreenTrap")
            {
                HeartRateManager.increaseHR(20f);
            }
            else if (tag == "YellowTrap")
            {
                HeartRateManager.increaseHR(10f);
            }

            Destroy(gameObject);
        }
    }
}
