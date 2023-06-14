using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public PathfindingNode[,] grid = new PathfindingNode[0, 0];
    int limX, limY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void readGrid(FightSquare[] lst, int maxX, int maxY)
    {
        this.limX = maxX;
        this.limY = maxY;
        this.grid = new PathfindingNode[maxX, maxY];
        for (int i = 0; i < lst.Length; i++)
        {
            PathfindingNode newNode = new PathfindingNode(lst[i].xPos, lst[i].yPos, lst[i].occupied);
            grid[lst[i].xPos, lst[i].yPos] = newNode;
        }
    }

    public List<PathfindingNode> InRange(int startX, int startY, int range)
    {
        this.ClearVisited();

        List<PathfindingNode> ans = new List<PathfindingNode>();
        Queue<PathfindingNode> q = new Queue<PathfindingNode>();

        q.Enqueue(grid[startX, startY]);
        grid[startX, startY].dist = 0;

        PathfindingNode cur;
        while (q.TryPeek(out cur))
        {
            cur = q.Dequeue();
            
            if(cur.dist <= range && !cur.visited)
            {
                cur.visited = true;
                ans.Add(cur);

                List<PathfindingNode> adj = getAdj(cur.x, cur.y);
                for(int i = 0; i < adj.Count; i++)
                {
                    if(!adj[i].visited && !adj[i].occupied && adj[i].dist > (cur.dist + 1))
                    {
                        adj[i].dist = cur.dist + 1;
                        if (!q.Contains(adj[i])) q.Enqueue(adj[i]);
                    }
                }
            }
        }

        return ans;
    }

    public List<PathfindingNode> FindPath(int startX, int startY, int endX, int endY)
    {
        this.ClearVisited();
        Queue<PathfindingNode> q = new Queue<PathfindingNode>();
        q.Enqueue(grid[startX, startY]);

        PathfindingNode cur;
        q.Peek().dist = 0;

        while(q.TryPeek(out cur))
        {
            cur = q.Dequeue();

            if (cur.x == endX && cur.y == endY) q.Clear();
            cur.visited = true;

            List<PathfindingNode> adj = this.getAdj(cur.x, cur.y);
            for(int i = 0; i < adj.Count; i++)
            {
                if (!adj[i].visited && !adj[i].occupied)
                {
                    if (adj[i].dist > (cur.dist + 1))
                    {
                        adj[i].dist = cur.dist + 1;
                        adj[i].prev = cur;
                    }
                    if (!q.Contains(adj[i])) q.Enqueue(adj[i]);
                }
            }
        }

        List<PathfindingNode> ans = new List<PathfindingNode>();
        cur = grid[endX, endY];
        while(cur != null)
        {
            ans.Add(cur);
            cur = cur.prev;
        }
        ans.Reverse();
        return ans;
    }

    private void ClearVisited()
    {
        for (int x = 0; x < limX; x++) for (int y = 0; y < limY; y++)
            {
                grid[x, y].visited = false;
                grid[x, y].prev = null;
                grid[x, y].dist = 9999;
            }
    }

    public void UpdateNode(int x, int y, bool occupied)
    {
        this.grid[x, y].occupied = occupied;
    }

    public void UpdateNodes(FightSquare[] lst)
    {
        for(int i = 0; i < lst.Length; i++)
        {
            UpdateNode(i % limX, i / limX, lst[i].occupied);
        }
    }

    public List<PathfindingNode> getAdj(int x, int y)
    {
        List<PathfindingNode> ans = new List<PathfindingNode>();
        int tempx, tempy;
        tempx = x - 1;
        tempy = y;
        if (tempx >= 0) ans.Add(grid[tempx, tempy]);
        tempx = x + 1;
        if (tempx < limX) ans.Add(grid[tempx, tempy]);
        tempx = x;
        tempy = y - 1;
        if (tempy >= 0) ans.Add(grid[tempx, tempy]);
        tempy = y + 1;
        if (tempy < limY) ans.Add(grid[tempx, tempy]);
        return ans;
    }
}