using UnityEngine;
using System;

// Q: Why use "Serializable" instead of "System.Serializable"?
[Serializable]

// Q: Why need to create an entire class to hold specific attributes for each room generated?
// Q: Can't just instantiate maze room and then reference that specific clone for its materials?
public class MazeRoomSettings {

	public Material floorMaterial, wallMaterial;
}
