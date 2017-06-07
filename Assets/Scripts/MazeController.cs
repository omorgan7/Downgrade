// MazeController.cs
// remember you can NOT have even numbers of height or width in this style of block maze
// to ensure we can get walls around all tunnels...  so use 21 x 13 , or 7 x 7 for examples.
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
public class MazeController : MonoBehaviour {
    public int width, height;
	public float cubeWidth = 2f;
	public float cubeHeight = 1f;
    public float enemyOffet = 1f;
    public Material brick;
	public GameObject wall;
    public GameObject floorprefab;
    public GameObject enemyprefab;
    public GameObject endprefab;
    public GameObject player;
    public float difficultyDistance = 1f;
    private int[,] Maze;
    private Stack<Vector2> _tiletoTry = new Stack<Vector2>();
    private List<Vector2> offsets = new List<Vector2> { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0) };
    private System.Random rnd = new System.Random();
    private int _width, _height;
    private Vector2 _currentTile;
    public static String MazeString;
    public Vector2 CurrentTile {
        get { return _currentTile; }
        private set {
            if (value.x < 1 || value.x >= this.width - 1 || value.y < 1 || value.y >= this.height - 1){
                throw new ArgumentException("Width and Height must be greater than 2 to make a maze");
            }
            _currentTile = value;
        }
    }
    private static MazeController instance;
    public static MazeController Instance {
        get {return instance;}
    }
    public GameObject light_cube;
    public GameObject drone_cube;
    public GameObject weapon_cube;
    public GameObject other_cube;
    private GameObject box;

    private GameObject end;
    private Vector3 InitialPlayerDistance;



    void Awake()  { 
		instance = this;
        InitialPlayerDistance = player.transform.localPosition;
		MakeBlocks(); 
	}
// end of main program
// ============= subroutines ============
    void MakeBlocks() {
 
        Maze = new int[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++)  {
                Maze[x, y] = 1;
            }
        }
        CurrentTile = Vector2.one;
        _tiletoTry.Push(CurrentTile);
        Maze = CreateMaze();  // generate the maze in Maze Array.
        GameObject ptype;
        for (int i = 0; i <= Maze.GetUpperBound(0); i++)  {
            for (int j = 0; j <= Maze.GetUpperBound(1); j++) {
                if (Maze[i, j] == 1)  {
                    MazeString=MazeString+"X";  // added to create String
                    //ptype = GameObject.CreatePrimitive(PrimitiveType.Cube);
					ptype = Instantiate(wall,Vector3.zero,Quaternion.identity);
					ptype.transform.localScale = ptype.transform.localScale * cubeWidth;
                   ptype.transform.position = new Vector3(cubeWidth*i * ptype.transform.localScale.x, cubeHeight, cubeWidth*j * ptype.transform.localScale.z);
 
                    if (brick != null){
						ptype.GetComponent<Renderer>().material = brick;
					}
                    ptype.transform.parent = transform;
                }
                else if (Maze[i, j] == 0) {
                    float randomVal = UnityEngine.Random.value;
                    if(randomVal > 0.01f){
                        CreateFloor(i,j);
                        float spawnRandomVal = UnityEngine.Random.value;
                        if(spawnRandomVal <= 0.01f){
                            CreateEnemy(i,j);
                        }
                        else if(spawnRandomVal<= 0.02f){
                            CreateItem(i,j);
    
                        }
                    }

                }
            }
        }
        CreateEnd();

    }
    // =======================================
    public int[,] CreateMaze() {
 
        //local variable to store neighbors to the current square as we work our way through the maze
            List<Vector2> neighbors;
            //as long as there are still tiles to try
            while (_tiletoTry.Count > 0)
            {
                //excavate the square we are on
                Maze[(int)CurrentTile.x, (int)CurrentTile.y] = 0;
                //get all valid neighbors for the new tile
                neighbors = GetValidNeighbors(CurrentTile);
                //if there are any interesting looking neighbors
                if (neighbors.Count > 0)
                {
                    //remember this tile, by putting it on the stack
                    _tiletoTry.Push(CurrentTile);
                    //move on to a random of the neighboring tiles
                    CurrentTile = neighbors[rnd.Next(neighbors.Count)];
                }
                else
                {
                    //if there were no neighbors to try, we are at a dead-end toss this tile out
                    //(thereby returning to a previous tile in the list to check).
                    CurrentTile = _tiletoTry.Pop();
                }
            }
            //print("Maze Generated ...");
            return Maze;
        }
 
    // ================================================
        // Get all the prospective neighboring tiles "centerTile" The tile to test
        // All and any valid neighbors</returns>
        private List<Vector2> GetValidNeighbors(Vector2 centerTile) {
            List<Vector2> validNeighbors = new List<Vector2>();
            //Check all four directions around the tile
            foreach (var offset in offsets) {
                //find the neighbor's position
                Vector2 toCheck = new Vector2(centerTile.x + offset.x, centerTile.y + offset.y);
                //make sure the tile is not on both an even X-axis and an even Y-axis
                //to ensure we can get walls around all tunnels
                if (toCheck.x % 2 == 1 || toCheck.y % 2 == 1) {
             
                    //if the potential neighbor is unexcavated (==1)
                    //and still has three walls intact (new territory)
                    if (Maze[(int)toCheck.x, (int)toCheck.y]  == 1 && HasThreeWallsIntact(toCheck)) {
                 
                        //add the neighbor
                        validNeighbors.Add(toCheck);
                    }
                }
            }
            return validNeighbors;
        }
    // ================================================
        // Counts the number of intact walls around a tile
        //"Vector2ToCheck">The coordinates of the tile to check
        //Whether there are three intact walls (the tile has not been dug into earlier.
        private bool HasThreeWallsIntact(Vector2 Vector2ToCheck) {
     
            int intactWallCounter = 0;
            //Check all four directions around the tile
            foreach (var offset in offsets) {
         
                //find the neighbor's position
                Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
                //make sure it is inside the maze, and it hasn't been dug out yet
                if (IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x, (int)neighborToCheck.y] == 1) {
                    intactWallCounter++;
                }
            }
            //tell whether three walls are intact
            return intactWallCounter == 3;
        }
 
    // ================================================
        private bool IsInside(Vector2 p) {
            //return p.x >= 0  p.y >= 0  p.x < width  p.y < height;
           return p.x >= 0 && p.y >= 0 && p.x < width && p.y < height;
        }
        private void CreateFloor(int i, int j){
            GameObject floor = Instantiate(floorprefab,Vector3.zero,Quaternion.identity);
            floor.transform.localScale = floor.transform.localScale*0.5f;
            floor.transform.position = new Vector3(2f*cubeWidth*i*wall.transform.localScale.x, 0, 2f*cubeWidth*j*wall.transform.localScale.z);
            floor.transform.parent = transform;
        }
      private void CreateItem(int i, int j){
          int R = Random.Range(1,4);
          if(R ==1){
                box = Instantiate(light_cube,Vector3.zero, Quaternion.identity);
          }
          if(R ==2){
                box = Instantiate(drone_cube, Vector3.zero, Quaternion.identity);
          }
          if(R ==3){
                box = Instantiate(weapon_cube, Vector3.zero, Quaternion.identity);
          }
          if(R ==4){
                box = Instantiate(other_cube, Vector3.zero, Quaternion.identity);
          }
            box.transform.position = new Vector3(2f*cubeWidth*i*wall.transform.localScale.x, 0, 2f*cubeWidth*j*wall.transform.localScale.z);
            box.transform.parent = transform;
      }
        private void CreateEnemy(int i, int j){
            GameObject enemy = Instantiate(enemyprefab,Vector3.zero,Quaternion.identity);
            enemy.transform.position = new Vector3(2f*cubeWidth*i*wall.transform.localScale.x,enemyOffet , 2f*cubeWidth*j*wall.transform.localScale.z);
            enemy.transform.parent = transform;
        }
        private void CreateEnd(){
            end = Instantiate(endprefab,Vector3.zero,Quaternion.identity);
            end.transform.position = new Vector3(2f*cubeWidth*(Maze.GetUpperBound(0)-2)*wall.transform.localScale.x,enemyOffet , 2f*cubeWidth*(Maze.GetUpperBound(1)-2)*wall.transform.localScale.z);
        }
        public void Update(){
            Vector3 direction = end.transform.localPosition - player.transform.localPosition;
            float mag = 0.0001f*Mathf.Pow(direction.sqrMagnitude,0.5f);
            difficultyDistance = (1f + 1f/mag); 
        }
}