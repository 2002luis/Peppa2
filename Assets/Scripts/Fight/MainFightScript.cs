using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFightScript : MonoBehaviour
{
    public Transform start0, startX, startY;
    public GameObject copy;
    public int xSize, ySize, curChar;
    public Vector3 xDist, yDist;
    public FightSquare[] nodes;
    public Pathfinding grid;
    public List<FightCharacter> chars = new List<FightCharacter>();
    // Start is called before the first frame update
    void Start()
    {
        curChar = 0;
        xDist = startX.position - start0.position;
        yDist = startY.position - start0.position;
        nodes = new FightSquare[xSize * ySize];
        nodes[0] = start0.gameObject.GetComponent<FightSquare>();
        nodes[1] = startX.gameObject.GetComponent<FightSquare>();
        nodes[xSize] = startY.gameObject.GetComponent<FightSquare>();
        copy = start0.gameObject;
        for(int i = 2; i < (xSize * ySize); i++)
        {
            if (i != xSize)
            {
                GameObject tmp = GameObject.Instantiate(copy);
                FightSquare tmpScript = tmp.GetComponent<FightSquare>();
                Transform tmpTransform = tmp.GetComponent<Transform>();
                tmpScript.xPos = i % xSize;
                tmpScript.yPos = i / xSize;
                tmpTransform.position = start0.position + (xDist * tmpScript.xPos) + (yDist * tmpScript.yPos);
                tmpTransform.SetParent(start0.parent);
                nodes[i] = tmpScript;
            }
        }
        grid.readGrid(nodes,xSize,ySize);
        for (int i = 0; i < chars.Count; i++) chars[i].init(xSize, ySize, xDist, yDist, this);
    }

    // Update is called once per frame
    void Update()
    {
        if (curChar >= chars.Count) curChar = 0;
        chars[curChar].getMove();
        if (!chars[curChar].moving) chars[curChar].getAttack();
        if (chars[curChar].done)
        {
            chars[curChar].done = false;
            curChar++;
            ResetGrid();
        }
    }

    public void Test()
    {
        grid.UpdateNodes(nodes);
        clearSelected();
        List<PathfindingNode> inRange = grid.FindPath(0,0,4,4);
        for (int i = 0; i < inRange.Count; i++)
        {
            getNode(inRange[i].x, inRange[i].y).selected = true;
        }
    }

    public void ResetGrid()
    {
        for(int i = 0; i < nodes.Length; i++)
        {
            nodes[i].ResetColour();
        }
    }

    public FightSquare getNode(int x, int y)
    {
        return (nodes[y * xSize + x]);
    }
    public void clearSelected()
    {
        for (int i = 0; i < nodes.Length; i++) nodes[i].selected = false;
    }
}
