using UnityEngine;

public class Player : MonoBehaviour {

    public float latSpeed, rotSpeed;

	private MazeCell currentCell;

	private MazeDirection currentDirection;

    private Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

	public void SetLocation (MazeCell cell) {
		if (currentCell != null) {
			currentCell.OnPlayerExited();
		}
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		currentCell.OnPlayerEntered();
	}

    // change code
	private void Move (float v) {
        //Vector3 movement = new Vector3(0f, 0f, v);
        Vector3 movement = new Vector3(Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * v, 0f, Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * v);
        movement *= Time.deltaTime * latSpeed;
        
        transform.localPosition = transform.position + movement;

		/*
        MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
        */
	}

	private void Look (MazeDirection direction) {
		transform.localRotation = direction.ToRotation();
		currentDirection = direction;
	}

    private void Turn (float h) {
        float newRotate = transform.eulerAngles.y + h * rotSpeed;
        Quaternion rotate = Quaternion.Euler(0f, newRotate, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.time);
    }

	private void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(v);
        Turn(h);

        /*
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
			Move(currentDirection);
		}
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
			Move(currentDirection.GetNextClockwise());
		}
		else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
			Move(currentDirection.GetOpposite());
		}
		else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			Move(currentDirection.GetNextCounterclockwise());
		}
		else if (Input.GetKeyDown(KeyCode.Q)) {
			Look(currentDirection.GetNextCounterclockwise());
		}
		else if (Input.GetKeyDown(KeyCode.E)) {
			Look(currentDirection.GetNextClockwise());
		}
        */
	}
}