using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNode
{
    public int x, y, dist;
    public bool visited;
    public bool occupied;
    public PathfindingNode prev;
    public PathfindingNode(int x, int y, bool occupied)
    {
        this.x = x;
        this.y = y;
        this.occupied = occupied;
    }
    public override string ToString()
    {
        return "x:" + x.ToString() + " y:" + y.ToString();
    }
}
