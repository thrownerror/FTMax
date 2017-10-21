using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {

    protected Vector2[] moveNodes;
    public enum ACTIONS {MOVE_FORWARD, RIGHT_TURN, LEFT_TURN}

    public class MoveForward : Action{
        //moveNodes = {new Vector2(1,0)};
    }
}
