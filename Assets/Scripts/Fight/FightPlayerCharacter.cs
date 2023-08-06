using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class FightPlayerCharacter : FightCharacter
{


    public override void getMove()
    {
        if (!this.attacking && !this.moving)
        {
            if (curAttack == -1)
            {
                if (canMove.Count == 0)
                {
                    canMove = new List<FightSquare>();
                    List<PathfindingNode> tmp = mfs.grid.InRange(curX, curY, Mathf.CeilToInt(moveRange * rangeMod));
                    for (int i = 0; i < tmp.Count; i++)
                    {
                        canMove.Add(mfs.getNode(tmp[i].x, tmp[i].y));
                    }
                }
                if (Input.GetKey("d") && curX + 1 < mfs.xSize && canMove.Contains(mfs.getNode(curX + 1, curY))) this.oneMove(1, 0);
                else if (Input.GetKey("a") && curX - 1 >= 0 && canMove.Contains(mfs.getNode(curX - 1, curY))) this.oneMove(-1, 0);
                else if (Input.GetKey("s") && curY - 1 >= 0 && canMove.Contains(mfs.getNode(curX, curY - 1))) this.oneMove(0, -1);
                else if (Input.GetKey("w") && curY + 1 < mfs.ySize && canMove.Contains(mfs.getNode(curX, curY + 1))) this.oneMove(0, 1);
                else if (Input.GetKey("1")) curAttack = 1;
                else if (Input.GetKey("2")) curAttack = 2;
                else if (Input.GetKey("3")) curAttack = 3;
                else if (Input.GetKey("4")) curAttack = 4;
                if (Input.GetKey("c") && !this.moving)
                {
                    curAttack = -1;
                    canMove.Clear();
                    canAttack.Clear();
                    attacking = false;
                    done = true;
                }
            }
            else getAttack();
        }
    }

    public int curAttack = -1;
    

    public override void getAttack()
    {
        if (Input.GetKey("c") && !this.moving)
        {
            StartCoroutine(attackGeneric(1f));
            curAttack = -1;
            canMove.Clear();
            canAttack.Clear();
        }
    }

    public virtual void getAttack0()
    {

    }

    public virtual void getAttack1()
    {

    }

    public virtual void getAttack2()
    {

    }

    public virtual void getAttack3()
    {

    }

    public virtual bool canAttack0()
    {
        return false;
    }

    public virtual bool canAttack1()
    {
        return false;
    }

    public virtual bool canAttack2()
    {
        return false;
    }

    public virtual bool canAttack3()
    {
        return false;
    }
}
