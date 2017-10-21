using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : Singleton<TerrainManager> {
    //Attributes
    public Node[,] terrain;
    public Node playerNode;
    public BattleManager battleManager;
    public GameObject[] prefabs;
    public int width = 4; //z axis of grid
    public int length = 20; //x axis of grid
    
    //Hidden Singleton Constructor
    protected TerrainManager() {}

	public void Start () {
        GenerateGrid();
	}
	
	void Update () {
		
	}

    private void GenerateGrid()
    {
        
        terrain = new Node[length,width];
        for(int z = 0; z <width; z++)
        {
            for(int x = 0; x < length; x++)
            {
                Node gridNode = Instantiate(prefabs[0],new Vector3(x-10,0,z),Quaternion.identity, gameObject.transform).GetComponent<Node>();
                gridNode.position = new Vector2(x, z);
                terrain[x,z] = gridNode;
            }
        }

        //Generate Nieghbors
        //Special Cases for corners
        terrain[0, 0].neighbors.Add(terrain[0, 1]);
        terrain[0, 0].neighbors.Add(terrain[1, 0]);
        terrain[0, 0].isBorder = true;
        terrain[length-1, 0].neighbors.Add(terrain[length-1, 1]);
        terrain[length-1, 0].neighbors.Add(terrain[length-2, 0]);
        terrain[length-1, 0].isBorder = true;
        terrain[0, width-1].neighbors.Add(terrain[0, width-2]);
        terrain[0, width-1].neighbors.Add(terrain[1, width-1]);
        terrain[0, width-1].isBorder = true;
        terrain[length-1, width-1].neighbors.Add(terrain[length-1, width-2]);
        terrain[length-1, width-1].neighbors.Add(terrain[length - 2, width-1]);
        terrain[length - 1, width - 1].isBorder = true;

        //Top row
        int w = width - 1;
        for(int x = 1; x < length-2; x++)
        {
            terrain[x, w].neighbors.Add(terrain[x - 1, w]);
            terrain[x, w].neighbors.Add(terrain[x + 1, w]);
            terrain[x, w].neighbors.Add(terrain[x-1, w-1]);
            terrain[x, w].neighbors.Add(terrain[x, w-1]);
            terrain[x, w].neighbors.Add(terrain[x+1, w-1]);
            terrain[x, w].isBorder = true;
        }

        //Bottom Row
       for(int x =1; x<length-2; x++)
        {
            terrain[x, 0].neighbors.Add(terrain[x - 1, 0]);
            terrain[x, 0].neighbors.Add(terrain[x + 1, 0]);
            terrain[x, 0].neighbors.Add(terrain[x - 1, 1]);
            terrain[x, 0].neighbors.Add(terrain[x, 1]);
            terrain[x, 0].neighbors.Add(terrain[x + 1, 1]);
            terrain[x, 0].isBorder = true;
        }

        //Right Column
        int l = length - 1;
       for(int z = 1; z < width -2; z++)
        {
            terrain[l, z].neighbors.Add(terrain[l, z - 1]);
            terrain[l, z].neighbors.Add(terrain[l, z + 1]);
            terrain[l, z].neighbors.Add(terrain[l - 1, z - 1]);
            terrain[l, z].neighbors.Add(terrain[l - 1, z]);
            terrain[l, z].neighbors.Add(terrain[l - 1, z + 1]);
            terrain[l, z].isBorder = true;
        }

        //Left Column
        for (int z = 1; z < width - 2; z++)
        {
            terrain[l, z].neighbors.Add(terrain[0, z - 1]);
            terrain[l, z].neighbors.Add(terrain[0, z + 1]);
            terrain[l, z].neighbors.Add(terrain[1, z - 1]);
            terrain[l, z].neighbors.Add(terrain[1, z]);
            terrain[l, z].neighbors.Add(terrain[1, z + 1]);
            terrain[l, z].isBorder = true;
        }

        //Middle of Board
        for(int x = 1; x < length - 2; x++)
        {
            for(int z = 1; z < width-2; z++)
            {
                terrain[x, z].neighbors.Add(terrain[x - 1, z - 1]);
                terrain[x, z].neighbors.Add(terrain[x, z - 1]);
                terrain[x, z].neighbors.Add(terrain[x + 1, z - 1]);
                terrain[x, z].neighbors.Add(terrain[x - 1, z]);
                terrain[x, z].neighbors.Add(terrain[x + 1, z]);
                terrain[x, z].neighbors.Add(terrain[x - 1, z + 1]);
                terrain[x, z].neighbors.Add(terrain[x, z + 1]);
                terrain[x, z].neighbors.Add(terrain[x + 1, z + 1]);
            }
        }
    }

    /// <summary>
    /// Moves car Directly to desired node if node exists
    /// </summary>
    /// <param name="car"></param>
    /// <param name="move"></param>
    /// <param name="isPlayer"></param>
    public void MoveAgent(BattleAgent car, Vector2 move, bool isPlayer){
        int x = (int)move.x;
        int z = (int)move.y;

        if (!isValidMove(move))
        {
            Debug.LogError("INVALID MOVE! Car: " + car.name);
            return;
        }
        float journeyLength = Vector3.Distance(car.transform.position,terrain[x, z].transform.position);
        float journeySpeed = (Time.deltaTime * 1);
        while (car.transform.position != terrain[x, z].transform.position)
        {
            car.transform.position = Vector3.Lerp(car.transform.position, terrain[x, z].transform.position, journeySpeed);
        }
        terrain[x, z].Occupants.Add(car);
        if (isPlayer)
            playerNode = terrain[x, z];
    }

    public void MoveAgent(BattleAgent car, List<Vector2> moveList, bool isPlayer)
    {
        int x = (int)moveList[0].x;
        int z = (int)moveList[0].y;

        if (!isValidMove(moveList[0]))
        {
            Debug.LogError("INVALID MOVE! Car: " + car.name);
            return;
        }

        car.gameObject.transform.position = terrain[x, z].transform.position;
        terrain[x, z].Occupants.Add(car);
        if (isPlayer)
            playerNode = terrain[x, z];
    }

    public bool isValidMove(Vector2 location)
    {
        if (location.x < 0 || location.x > length - 1)
            return false;
        else if (location.y < 0 || location.y > width - 1)
            return false;
        else
            return true;
    }

    public bool CheckForCollision(Node desiredLocation)
    {
        if (desiredLocation.isTraversable)
            return false;
        else
            return true;
    }
}
