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
        LANE_SHIFT_RIGHT=8
    }
    public static Vector2[] moveForward = { new Vector2(1,0) };
    public static Vector2[] turnRight = { new Vector2(1, 0), new Vector2(0,-1) };
    public static Vector2[] turnLeft = { new Vector2(1, 0), new Vector2(0, 1) };
    public static Vector2[] hairpinRight = { new Vector2(1, 0), new Vector2(0, -1), new Vector3(-1, 0) };
    public static Vector2[] hairpinLeft = { new Vector2(1, 0), new Vector2(0, 1), new Vector3(-1, 0) };
    public static Vector2[] laneShiftRight = { new Vector2(0, -1) };
    public static Vector2[] laneShiftLeft = { new Vector2(0, 1) };
}
