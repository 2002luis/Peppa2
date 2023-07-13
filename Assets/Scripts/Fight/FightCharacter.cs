using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCharacter : MonoBehaviour
{
    protected int curX, curY, xLimit, yLimit;
    protected Vector3 nextPos, xDist, yDist;
    protected SpriteRenderer spriteRend;
    protected new Transform transform;
    public MainFightScript mfs;
    public bool moving;
    public const float moveSpeed = 6f;

    public void Start()
    {
        moving = false;
        transform = this.GetComponent<Transform>();
        spriteRend = this.GetComponent<SpriteRenderer>();
        nextPos = transform.position;
    }

    public void init(int xLimit, int yLimit, Vector3 xDist, Vector3 yDist, MainFightScript mfs)
    {
        this.xLimit = xLimit;
        this.yLimit = yLimit;
        this.xDist = xDist;
        this.yDist = yDist;
        this.mfs = mfs;
    }

    public void move(int xMod, int yMod)
    {
        if (!moving)
        {
            if (xMod == 1 && xLimit > (curX + 1) && !mfs.getNode(1+curX,curY).occupied)
            {
                mfs.getNode(curX, curY).occupied = false;
                mfs.grid.grid[curX, curY].occupied = false; //isto é estúpido
                curX += 1;
                nextPos += xDist;
                StartCoroutine(moveLoop());
            }
            else if (yMod == 1 && yLimit > (curY + 1) && !mfs.getNode(curX, curY + 1).occupied)
            {
                mfs.getNode(curX, curY).occupied = false;
                mfs.grid.grid[curX, curY].occupied = false; //isto é estúpido
                curY += 1;
                nextPos += yDist;
                StartCoroutine(moveLoop());
            }
            else if (xMod == -1 && (curX - 1) >= 0 && !mfs.getNode(curX - 1, curY).occupied)
            {
                mfs.getNode(curX, curY).occupied = false;
                mfs.grid.grid[curX, curY].occupied = false; //isto é estúpido
                curX -= 1;
                nextPos -= xDist;
                StartCoroutine(moveLoop());
            }
            else if (yMod == -1 && (curY - 1) >= 0 && !mfs.getNode(curX, curY - 1).occupied)
            {
                mfs.getNode(curX, curY).occupied = false;
                mfs.grid.grid[curX, curY].occupied = false; //isto é estúpido
                curY -= 1;
                nextPos -= yDist;
                StartCoroutine(moveLoop());
            }
        }
    }

    public int testX, testY;

    public void testMove()
    {
        move(testX, testY);
    }

    IEnumerator moveLoop()
    {
        
        moving = true;
        while (Vector3.Distance(transform.position, nextPos) > 0.1)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        mfs.getNode(curX, curY).occupied = true;
        mfs.grid.grid[curX, curY].occupied = true; //isto é estúpido
        moving = false;
    }

    public virtual void getMove()
    {

    }
}
