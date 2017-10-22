using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour {
    public float moveSpeed;
    public GameObject target;
    public BattleAgent trackedPlayer;

    #region Local Player Camera Follow
    public float camMoveSpeed;

    //Control how tightly the camera follows the player
    private Vector3 camVelocity;
    private Vector3 camAcceleration;
    private Vector3 desiredCamVelocity;


    #endregion

    void Start() {

    }

    void Update() {
        MoveCamera();
    }

    void MoveCamera() {
        desiredCamVelocity = (target.transform.position - transform.position) * camMoveSpeed * ((target.transform.position - transform.position).magnitude);
        transform.position = new Vector3(desiredCamVelocity.x + transform.position.x, transform.position.y, transform.position.z);
    }
}
