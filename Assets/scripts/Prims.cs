using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prims : Maze
{
    public override void SetEmptyCoordinates()
    {
        MapLocation posiiton = new MapLocation(2, 2);
        // set start position empty
        map[posiiton.x, posiiton.z] = 0;

        // add orthagonal the walls around our position
        List<MapLocation> walls = new List<MapLocation>();
        walls.Add(new MapLocation(posiiton.x + 1, posiiton.z));
        walls.Add(new MapLocation(posiiton.x - 1, posiiton.z));
        walls.Add(new MapLocation(posiiton.x, posiiton.z + 1));
        walls.Add(new MapLocation(posiiton.x, posiiton.z - 1));

        int loopCounter = 0;
        while (walls.Count > 0 && loopCounter < 5000)
        {
            // get random wall
            int wallIndex = Random.Range(0, walls.Count);
            // set our current position to it
            posiiton.x = walls[wallIndex].x;
            posiiton.z = walls[wallIndex].z;
            //remove it from array
            walls.RemoveAt(wallIndex);
            if (CountOthogonalNeighbours(posiiton.x, posiiton.z) == 1)
            {
                // if it has more than 1 orthogonal neighbout, then set it to "empty" (ie another block in a path
                map[posiiton.x, posiiton.z] = 0;
                // then add it's neighboiuts
                walls.Add(new MapLocation(posiiton.x + 1, posiiton.z));
                walls.Add(new MapLocation(posiiton.x - 1, posiiton.z));
                walls.Add(new MapLocation(posiiton.x, posiiton.z + 1));
                walls.Add(new MapLocation(posiiton.x, posiiton.z - 1));
            }
            loopCounter++;
            // keep looping until no "walls" left or we reach max loop count
        }
    }
}
