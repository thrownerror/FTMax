﻿using System.Collections;
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
    public int numRocks = 3;

    //Hidden Singleton Constructor
    protected TerrainManager() {}


    public void Start () {
        GenerateGrid();
        GenerateObstacles();
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

    public void GenerateObstacles()
    {
        //Rocks
        for(int i = 0; i < numRocks; i++)
        {
            bool rockPlaced = false;
            while (!rockPlaced)
            {
                int x = Random.Range(0, length - 1);
                int z = Random.Range(0, width - 1);

                if (terrain[x, z].Occupants.Count == 0)
                {
                    GameObject rock = Instantiate(prefabs[2], terrain[x, z].transform.position,Quaternion.identity);

                    terrain[x, z].isTraversable = false;
                    terrain[x, z].Occupants.Add(rock.GetComponent<BattleAgent>());
                    rock.GetComponent<BattleAgent>().gridPos = terrain[x, z];
                    rockPlaced = true;
                }
            }
        }
    }

    public List<EnemyAgent> GenerateEnemy(int numEnemies)
    {
        List<EnemyAgent> enemies = new List<EnemyAgent>();

        for (int i = 0; i < numEnemies; i++)
        {
            bool enemyPlaced = false;
            while (!enemyPlaced)
            {
                int x = Random.Range(0, length - 1);
                int z = Random.Range(0, width - 1);

                if (terrain[x, z].Occupants.Count == 0)
                {
                    GameObject enemy = Instantiate(prefabs[3], terrain[x, z].transform.position, Quaternion.identity);

                    terrain[x, z].isTraversable = false;
                    terrain[x, z].Occupants.Add(enemy.GetComponent<BattleAgent>());
                    enemy.GetComponent<BattleAgent>().gridPos = terrain[x, z];
                    enemies.Add(enemy.GetComponent<EnemyAgent>());
                    enemyPlaced = true;
                }
            }
        }

        return enemies;
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

    public List<MoveInstruct> MoveAgent(BattleAgent car, List<Vector3> moveList, bool isPlayer)
    {
        Node current = car.gridPos;

        //Check for collision
        

        List<MoveInstruct> moves = new List<MoveInstruct>();

        for(int i =0; i < moveList.Count; i++) { 
            int x = (int)(moveList[i].x);
            int z = (int)(moveList[i].y);

            Vector3 localFwd = car.transform.forward;
            Vector3 worldFwd = Vector3.forward; //Points right
            Vector3 worldRight = Vector3.right; //Points up

            if (localFwd.x < 0)
            {
                z *= -1;
                x *= -1;
            }
            if (localFwd.normalized.x == 0)
            {
                //We are moving vertically
                int xCopy = x;
                x = z;
                z = xCopy;

               if (localFwd.normalized.z < 0)
                {
                    //x *= -1;
                    z *= -1;
                }
               else if(localFwd.normalized.z > 0)
                {
                    x *= -1;
                }

            }

            if (!isValidMove(current.position + new Vector2(x, z)))
            {
                Debug.Log("INVALID MOVE! Car: " + car.name);
                return new List<MoveInstruct>();
            }

            moves.Add(new MoveInstruct(terrain[(int)current.position.x + x, (int)current.position.y + z], moveList[i].z));
            current = terrain[(int)current.position.x + x, (int)current.position.y + z];

            //Checks for collisions on the node the car is trying to move onto
            //If there is a collision, it resolves the collision for the collided upon object 
            //then resolves the collision for the car attempting to move into the space and sends a move order
            //that that car for the knockback (calculated in BattleAgent)

            if (current.Occupants.Count > 0) {
                if (current.Occupants[0] != car) {
                    print("Node occupants: " + current.Occupants.Count);
                    if (CheckCollsion(current, car)) {
                        print("Found collision");
                        //Do not tell obstacles that they've been hit
                        //if(!(current.Occupants[0] is Obstacle)) { ResolveCollision(current.Occupants[0], car); }

                        //Tell the car how to knockback
                        moves.Add(ResolveCollision(car, current.Occupants[0]));
                        //print("Resolving collision: " + );
                        current = terrain[Mathf.Abs((int)current.position.x + (int)(current.position.x - moves[0].node.position.x)), Mathf.Abs((int)(current.position.y - moves[0].node.position.y))];

                        //Skip the rest of the movement
                        return moves;
                    }
                }
            }
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

    public bool CheckCollsion(Node _node, BattleAgent _agent) {
        if(_node.Occupants.Count > 0) {
            

            return true;
        }

        return false;
    }

    public MoveInstruct ResolveCollision(BattleAgent _agent1, BattleAgent _agent2) {
        return _agent1.RegisterCollision(_agent2);
    }

}
