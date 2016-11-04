using UnityEngine;

// enum = a collection of related constants
public enum MazeDirection {
	North,   // North = 0
	East,   // East = 1
	South,   // South = 2
	West   // West = 3
}

public static class MazeDirections {

	public const int Count = 4;

	public static MazeDirection RandomValue {
		get {
			return (MazeDirection)Random.Range(0, Count);
		}
	}

    // this is a private static MazeDirection array variable
	private static MazeDirection[] opposites = {
		MazeDirection.South,   // South = opposites[0]
		MazeDirection.West,   // West = opposites[1]
		MazeDirection.North,   // North = opposites[2]
		MazeDirection.East   // East = opposites[3]
	};

    // parameter references a variable "direction" used to reference this instance of MazeDirection
    // do not need to input parameteric value when calling function in other classes and functions
	public static MazeDirection GetOpposite (this MazeDirection direction) {
		return opposites[(int)direction];
	}

	public static MazeDirection GetNextClockwise (this MazeDirection direction) {
		return (MazeDirection)(((int)direction + 1) % Count);
	}

	public static MazeDirection GetNextCounterclockwise (this MazeDirection direction) {
		return (MazeDirection)(((int)direction + Count - 1) % Count);
	}
	
    // this is a private static IntVector2 array variable
	private static IntVector2[] vectors = {
		new IntVector2(0, 1),   // face forward
		new IntVector2(1, 0),   // face right
		new IntVector2(0, -1),   // face back
		new IntVector2(-1, 0)   // face left
	};
	
	public static IntVector2 ToIntVector2 (this MazeDirection direction) {
		return vectors[(int)direction];
	}

    // this is a private static Quaternion array variable
	private static Quaternion[] rotations = {
		Quaternion.identity,   // no turn
		Quaternion.Euler(0f, 90f, 0f),   // turn right
		Quaternion.Euler(0f, 180f, 0f),   // turn back
		Quaternion.Euler(0f, 270f, 0f)   // turn left
	};
	
	public static Quaternion ToRotation (this MazeDirection direction) {
		return rotations[(int)direction];
	}
}