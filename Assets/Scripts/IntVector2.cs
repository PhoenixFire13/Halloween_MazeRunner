// Serialize = translate data or objects into a format that can be stored and reconstructed later on
[System.Serializable]

// A struct holds all record of data (varaiables, attributes, classes) in a new data type
/* Example: struct Book {
 *              char title[50];
 *              char author[50];
 *              char subject[100];
 *              int book_id;
 *          }
 */
public struct IntVector2 {
    // variables hold coordinates for maze size
	public int x, z;

    // constructor
	public IntVector2 (int x, int z) {
		this.x = x;
		this.z = z;
	}

	public static IntVector2 operator + (IntVector2 a, IntVector2 b) {
		a.x += b.x;
		a.z += b.z;
		return a;
	}
}