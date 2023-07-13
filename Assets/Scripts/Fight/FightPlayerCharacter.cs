using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayerCharacter : FightCharacter
{
    public override void getMove()
    {
        if (Input.GetKey("d")) this.move(1, 0);
        else if (Input.GetKey("a")) this.move(-1, 0);
        else if (Input.GetKey("s")) this.move(0, -1);
        else if (Input.GetKey("w")) this.move(0, 1);
    }
}
