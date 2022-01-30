using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilson : Maze
{

    public override void SetEmptyCoordinates()
    {
        MapLocation currentLocation = new MapLocation(
            Random.Range(1, width),
            Random.Range(1, depth));
        map.setEmpty(currentLocation);
    }
}
