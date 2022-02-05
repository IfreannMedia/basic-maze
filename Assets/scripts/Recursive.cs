using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursive : Maze
{
    public override void SetEmptyCoordinates()
    {
        MapLocation randomStart = new MapLocation(Random.Range(1, width), Random.Range(1, depth));
        this.Generate(randomStart);
    }

    //generate "empty" block in maze
    void Generate(MapLocation location)
    {
        if (CountOthogonalNeighbours(location) >= 2) return;
        map.setEmpty(location);
       
        //MapLocation nextLoc = GetRandomNextLocation(location);
        //this.Generate(nextLoc);
        directions.Shuffle();
        this.Generate(new MapLocation(location.x + directions[0].x, location.z + directions[0].z));
        this.Generate(new MapLocation(location.x + directions[1].x, location.z + directions[1].z));
        this.Generate(new MapLocation(location.x + directions[2].x, location.z + directions[2].z));
        this.Generate(new MapLocation(location.x + directions[3].x, location.z + directions[3].z));
    }
}
