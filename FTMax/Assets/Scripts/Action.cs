using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {

    public enum ACTIONS {MOVE_FORWARD = 0, RIGHT_TURN = 1, LEFT_TURN = 2}

    public static Vector2[] moveForward = { new Vector2(1,0) };
    public static Vector2[] turnRight = { new Vector2(1, 0), new Vector2(0,-1) };
    //public static Vector2[] turnLeft = { new Vector2(1, 0) };*/
}
