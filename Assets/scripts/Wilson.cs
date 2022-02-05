using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilson : Maze
{
    List<MapLocation> directions = new List<MapLocation>() {
    new MapLocation(1,0),
    new MapLocation(-1,0),
    new MapLocation(0,1),
    new MapLocation(0,-1)
    };
    private List<MapLocation> notUsed = new List<MapLocation>();

    public override void SetEmptyCoordinates()
    {
        MapLocation currentLocation = new MapLocation(
            Random.Range(1, width),
            Random.Range(1, depth));
        map.setPartOfMaze(currentLocation);
        int loopCounter = 0;
        while (GetAvailableCells() > 1 && loopCounter < 100)
        {

            RandomWalk();
            loopCounter++;
        }
    }

    private void RandomWalk()
    {
        int startIndex = Random.Range(0, notUsed.Count);
        MapLocation curLoc = new MapLocation(notUsed[startIndex]);
        List<MapLocation> curWalk = new List<MapLocation>();
        curWalk.Add(curLoc);
        int loopCounter = 0;
        bool validPath = false;
        while (curLoc.x > 0 && curLoc.x < width - 1 && curLoc.z > 0 && curLoc.z < depth - 1 && loopCounter < 5000 && !validPath)
        {
            Debug.Log("CURLOC: " + curLoc.x + ", " + curLoc.z);
            map.setEmpty(curLoc);
            int dir = Random.Range(0, directions.Count);
            MapLocation nextLoc = new MapLocation(curLoc);
            nextLoc.x += directions[dir].x;
            nextLoc.z += directions[dir].z;
            if (CountOthogonalNeighbours(nextLoc) < 2)
            {
                curLoc = nextLoc;
                curWalk.Add(curLoc);
            }
            validPath = CountOthogonalMazeNeighbours(curLoc) == 1;

            loopCounter++;
        }

        if (validPath)
        {
            map.setEmpty(curLoc);
            Debug.Log("Path Found");
            curWalk.ForEach(loc => map.setPartOfMaze(loc));
            curWalk.Clear();
        }
        else
        {
            curWalk.ForEach(loc => map.setFilled(loc));
            curWalk.Clear();
        }

    }

    public int CountOthogonalMazeNeighbours(MapLocation location)
    {
        int count = 0;
        for (int i = 0; i < directions.Count; i++)
        {
            MapLocation next = new MapLocation(location.x + directions[i].x, location.z + directions[i].z);
            if (next.x > 0 && next.x < width - 1 && next.z > 0 && next.z < depth - 1 &&
                map.isLocationPartOfMaze(next))
            {
                count++;
            }
        }
        return count;
    }

    private int GetAvailableCells()
    {
        notUsed.Clear();
        for (int z = 1; z < depth - 1; z++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                MapLocation loc = new MapLocation(x, z);
                if (CountOthogonalMazeNeighbours(loc) == 0)
                {
                    notUsed.Add(loc);
                }
            }
        }
        return notUsed.Count;
    }

}
