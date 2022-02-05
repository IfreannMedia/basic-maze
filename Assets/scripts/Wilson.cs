using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilson : Maze
{
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
        // creat list for the random walk, creat c starting position
        // c is taken fromt he notUsed list, so that position will not create any rooms
        List<MapLocation> inWalk = new List<MapLocation>();
        int rsStartIndex = Random.Range(0, notUsed.Count);
        MapLocation c = new MapLocation(notUsed[rsStartIndex]);
        inWalk.Add(c);

        int loopCounter = 0;
        bool validPath = false;
        while (c.x > 0 && c.x < width - 1 && c.z > 0 && c.z < depth - 1 && loopCounter < 5000 && !validPath)
        {
            map.setEmpty(c);
            if (CountOthogonalMazeNeighbours(c) > 1)
                break;

            // get random direction and then the next location in that direction
            MapLocation nextLoc = GetRandomNextLocation(c);

            // if the neighbours (empty) is greater than 2, "move" to next location, add it to current walk list
            if (CountOthogonalNeighbours(nextLoc) < 2)
            {
                c = nextLoc;
                inWalk.Add(c);
            }
            // determin if path is valid, if the maze neighbours is greater than 1, then we are creating a room
            validPath = CountOthogonalMazeNeighbours(c) == 1;

            loopCounter++;
        }

        if (validPath)
        {
            map.setEmpty(c);
            inWalk.ForEach(loc => map.setPartOfMaze(loc));
            inWalk.Clear();
        }
        else
        {
            inWalk.ForEach(loc => map.setFilled(loc));
            inWalk.Clear();
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
