using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCharacterCpu : FightCharacter
{
    public IEnumerator movePathCpu()
    {
        while (path.Count > 0)
        {
            oneMove(path[0].x - curX, path[0].y - curY);
            while (moving) yield return null;
            if (path.Count != 0) path.RemoveAt(0);
        }
        StartCoroutine(attackGeneric(0.5f));
    }
    public override void move(int xDest, int yDest)
    {
        if (xDest >= 0 && xDest < mfs.xSize && yDest >= 0 && yDest < mfs.ySize) path = mfs.grid.FindPath(curX, curY, xDest, yDest);
        StartCoroutine(movePathCpu());
        //getAttack();
    }
}
