using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAgent : MonoBehaviour {

    public TerrainManager.TerrainNode gridPos;
    public Vector2 gridRot;

    public TerrainManager.TerrainNode[] neighbors;
    public TerrainManager.TerrainNode[] moveableNodes;
    public float health;
    public float maxHealth;

    public TerrainManager.TerrainNode desiredNode;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool CanMoveTo(TerrainManager.TerrainNode _moveToLoc) {
        return true;
    }
    public void SetDesiredNode(TerrainManager.TerrainNode _desiredNode) {
        desiredNode = _desiredNode;
    }
    public void SetPosition(TerrainManager.TerrainNode _pos) {
        gridPos = _pos;
        transform.position = _pos.position;
    }
    public void SetRotation(Vector2 _rot) {
        gridRot = _rot;
    }
    public void SetHealth(int _health) {
        health = _health;
    }
    public void TakeTurn() {
        SetPosition(desiredNode);
    }
    void Rotate(Vector2 _dir) {
        gridRot += _dir;
    }
    public void LeftTurn() {
        Rotate(new Vector2(0, -90));
    }
    public void RightTurn() {
        Rotate(new Vector2(0, 90));
    }
}
