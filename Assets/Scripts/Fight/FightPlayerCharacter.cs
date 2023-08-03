using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayerCharacter : FightCharacter
{
    public override void getMove()
    {
        if (Input.GetKey("d")) this.oneMove(1, 0);
        else if (Input.GetKey("a")) this.oneMove(-1, 0);
        else if (Input.GetKey("s")) this.oneMove(0, -1);
        else if (Input.GetKey("w")) this.oneMove(0, 1);
        else if (Input.GetKey("c") && !this.moving) this.done = true;
    }
}
