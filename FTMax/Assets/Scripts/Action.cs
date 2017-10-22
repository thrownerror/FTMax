using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action {

    public enum Actions
    {
        GO_FORWARD = 0,
        TURN_RIGHT=1,
        TURN_LEFT = 2,
        SLOW_DOWN =3,
        SPEED_UP=4,
        HAIRPIN_LEFT=5,
        HAIRPIN_RIGHT=6,
        LANE_SHIFT_LEFT=7,
        LANE_SHIFT_RIGHT=8,

        //Knockbacks
        KNOCKBACK_RIGHT = 9,
        KNOCKBACK_LEFT = 10,
        KNOCKBACK_FORWARD = 11,
        KNOCKBACK_BACKWARD = 12
    }
    

    public static Vector3[] moveForward = { new Vector3(1, 0, 0) };
    public static Vector3[] reverse = { new Vector3(-1, 0, 0) };
    public static Vector3[] turnRight = { new Vector3(1, 0, 0), new Vector3(0,-1, 90) };
    public static Vector3[] turnLeft = { new Vector3(1, 0, 0), new Vector3(0, 1, -90) };
    public static Vector3[] hairpinRight = { new Vector3(1, 0, 0), new Vector3(0, -1, 90), new Vector3(-1, 0, 90) };
    public static Vector3[] hairpinLeft = { new Vector3(1, 0 ,0), new Vector3(0, 1 , -90), new Vector3(-1, 0, -90) };
    public static Vector3[] laneShiftRight = { new Vector3(0, -1, 0) };
    public static Vector3[] laneShiftLeft = { new Vector3(0, 1 , 0) };

    public static Vector3[] knockbackLeft = { new Vector3(0, -1, 0) };
    public static Vector3[] knockbackRight = { new Vector3(0, 1, 0) };
    public static Vector3[] knockbackForward = { new Vector3(1, 0, 0) };
    public static Vector3[] knockbackBackward = { new Vector3(-1, 0, 0) };


}
