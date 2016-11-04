using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

	public IntVector2 size;

	public MazeCell cellPrefab;

	public float generationStepDelay;

	public MazePassage passagePrefab;

	public MazeDoor doorPrefab;

    // Q: Why is the range written like this?
    // A: 
    [Range(0f, 1f)]
	public float doorProbability;

	public MazeWall[] wallPrefabs;

	public MazeRoomSettings[] roomSettings;

	private MazeCell[,] cells;

	private List<MazeRoom> rooms = new List<MazeRoom>();

	public IntVector2 RandomCoordinates {
		get {
            // Q: Why is there a need to use return statement?
            // A: 
            return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
		}
	}

    // specifies first cell generated
    public IntVector2 InitialCoordinates {
        get {
            return new IntVector2(10, 0);
        }
    }

    // checks if coordinates are in quadrant 1 (all positive coordinates) and less than maze size
	public bool ContainsCoordinates (IntVector2 coordinate) {
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}

    // return MazeCell at coordinates
	public MazeCell GetCell (IntVector2 coordinates) {
		return cells[coordinates.x, coordinates.z];
	}

	public IEnumerator Generate () {
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);

		cells = new MazeCell[size.x, size.z];
		List<MazeCell> activeCells = new List<MazeCell>();

		DoFirstGenerationStep(activeCells);
		while (activeCells.Count > 0) {
			yield return delay;
			DoNextGenerationStep(activeCells);
		}


        // hide all rooms after done generating
		for (int i = 0; i < rooms.Count; i++) {
			rooms[i].Hide();
		}
	}

	private void DoFirstGenerationStep (List<MazeCell> activeCells) {
		MazeCell newCell = CreateCell(InitialCoordinates);
        // Q: Why need to exclude index -1?
        // A: 
        newCell.Initialize(CreateRoom(-1));
		activeCells.Add(newCell);
	}

	private void DoNextGenerationStep (List<MazeCell> activeCells) {
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];

        // if already have MazeCell at index, remove index from activeCells and return to Generate()
		if (currentCell.IsFullyInitialized) {
			activeCells.RemoveAt(currentIndex);
			return;
		}

		MazeDirection direction = currentCell.RandomUninitializedDirection;
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();

		if (ContainsCoordinates(coordinates)) {
			MazeCell neighbor = GetCell(coordinates);

			if (neighbor == null) {
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
            // if current room has same settings as neighbor room, the two rooms are the same room
			else if (currentCell.room.settingsIndex == neighbor.room.settingsIndex) {
				CreatePassageInSameRoom(currentCell, neighbor, direction);
			}
			else {
				CreateWall(currentCell, neighbor, direction);
			}
		}
        // creates wall as maze edge
		else {
			CreateWall(currentCell, null, direction);
		}
	}

	private MazeCell CreateCell (IntVector2 coordinates) {
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;

		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
        // Q: How is the maze cell's position calculated?
        // A: 
        newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);

		return newCell;
	}

	private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
        // incomplete code to instantiate entrance and exit
        /*
        if (cell == cells[10, 0]) {
            MazeDoor door = Instantiate(doorPrefab);
            door.Initialize(otherCell, cell, direction);
            door = Instantiate(doorPrefab);

            otherCell.Initialize(cell.room);
            door.Initialize(otherCell, cell, direction.GetOpposite());
            return;
        }
        */

        // Q: How does the following line of code work?
        // A: 
        MazePassage prefab = Random.value < doorProbability ? doorPrefab : passagePrefab;
		MazePassage passage = Instantiate(prefab) as MazePassage;

		passage.Initialize(cell, otherCell, direction);
        // Q: Why do we need to re-assign the varriable?
        // A: 
        passage = Instantiate(prefab) as MazePassage;

        // if instantiated a door, create a new room
		if (passage is MazeDoor) {
			otherCell.Initialize(CreateRoom(cell.room.settingsIndex));
		}
        // else, add cell to existing room
		else {
			otherCell.Initialize(cell.room);
		}

        // Q: What is purpose of adding the following line?
        // A: 
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	private void CreatePassageInSameRoom (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
		MazePassage passage = Instantiate(passagePrefab) as MazePassage;

		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());

        // if system considers rooms different, change to same room
		if (cell.room != otherCell.room) {
			MazeRoom roomToAssimilate = otherCell.room;
			cell.room.Assimilate(roomToAssimilate);
			rooms.Remove(roomToAssimilate);
			Destroy(roomToAssimilate);
		}
	}

	private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
        // randomly choose which wall prefab to instantiate
		MazeWall wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
		wall.Initialize(cell, otherCell, direction);

        // Q: What does the following code do?
        // A: 
		if (otherCell != null) {
			wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)]) as MazeWall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}

    // Q: Why is it necessary to have a parameter that accepts an index to exclude in the maze room?
    // A: Because then you won't pick the same room settings as the previous room
	private MazeRoom CreateRoom (int indexToExclude) {
		MazeRoom newRoom = ScriptableObject.CreateInstance<MazeRoom>();
		newRoom.settingsIndex = Random.Range(0, roomSettings.Length);
		if (newRoom.settingsIndex == indexToExclude) {
            // how is this random? lol
			newRoom.settingsIndex = (newRoom.settingsIndex + 1) % roomSettings.Length;
		}
		newRoom.settings = roomSettings[newRoom.settingsIndex];
		rooms.Add(newRoom);
		return newRoom;
	}

    // incomplete
    private void CreateExit (MazeCell cell, MazeCell other) {
        MazeDirection direction = (MazeDirection)Random.Range(0f, 4f);
        MazeCellEdge edge = cell.GetEdge(direction);
    }
}