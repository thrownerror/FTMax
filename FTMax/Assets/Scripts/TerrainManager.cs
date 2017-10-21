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
    /// <param name="node"></param>
    /// <param name="isPlayer"></param>
    public void MoveAgentToNode(BattleAgent car, Vector2 node, bool isPlayer){
        int x = (int)node.x;
        int z = (int)node.y;

        if (!isValidMove(node))
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
        car.gridPos = terrain[x, z];
        if (isPlayer)
            playerNode = terrain[x, z];
    }

    public List<Node> MoveAgent(BattleAgent car, List<Vector2> moveList, bool isPlayer)
    {
        Node current = car.gridPos;
        List<Node> moves = new List<Node>();

        for(int i =0; i < moveList.Count; i++) { 
            int x = (int)(moveList[i].x * car.transform.forward.x);
            int z = (int)(moveList[i].y * -car.transform.right.z);

            if (!isValidMove(current.position + moveList[i]))
            {
                Debug.LogError("INVALID MOVE! Car: " + car.name);
                return new List<Node>();
            }

            moves.Add(terrain[(int)current.position.x + x, (int)current.position.y + z]);
            current = terrain[(int)current.position.x + x, (int)current.position.y + z];
        }
        return  moves;
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
