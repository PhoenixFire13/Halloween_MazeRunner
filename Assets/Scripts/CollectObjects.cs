using UnityEngine;
using System.Collections;

public class CollectObjects : MazeCell {

    public static int keyCount;

	// Use this for initialization
	void Awake () {
        keyCount = 0;
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DetermineCollected();
            Destroy(gameObject);
        }
    }

    void DetermineCollected()
    {
        if (tag == "ExitKey" || tag == "BasementKey")
        {
            keyCount++;
        }
    }
}
