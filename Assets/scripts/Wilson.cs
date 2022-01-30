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
    public override void SetEmptyCoordinates()
    {
        MapLocation currentLocation = new MapLocation(
            Random.Range(1, width),
            Random.Range(1, depth));
        map.setPartOfMaze(currentLocation);
        Debug.Log("set initial empty: " + currentLocation.x + ", " + currentLocation.z );
        RandomWalk();
    }

    private void RandomWalk()
    {

        MapLocation curLoc = new MapLocation(
    Random.Range(2, width - 1),
    Random.Range(2, depth - 1));

        int loopCounter = 0;
        bool validPath = false;
        while (curLoc.x > 0 && curLoc.x < width - 1 && curLoc.z > 0 && curLoc.z < depth - 1 && loopCounter < 5000 && !validPath)
        {
            map.setEmpty(curLoc);
            int dir = Random.Range(0, directions.Count);
            MapLocation nextLoc = new MapLocation(curLoc);
            nextLoc.x += directions[dir].x;
            nextLoc.z += directions[dir].z;
            if (CountOthogonalNeighbours(nextLoc) <= 1)
            {
                curLoc = nextLoc;
            }
            validPath = CountOthogonalMazeNeighbours(curLoc) == 1;  

            loopCounter++;
        }

        if (validPath)
        {
            map.setEmpty(curLoc);
            Debug.Log("Path Found");
        }

    }

    public int CountOthogonalMazeNeighbours(MapLocation location)
    {
        int count = 0;
        for (int i = 0; i < directions.Count; i++)
        {
            MapLocation next = new MapLocation(location.x + directions[i].x, location.z + directions[i].z);
            if (map.isLocationPartOfMaze(next))
            {
                count++;
            }
        }
        return count;
    }
}
