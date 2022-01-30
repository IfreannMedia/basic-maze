using UnityEngine;

public class Crawler : Maze
{
    public int horizontalCorridors = 3;
    public int verticalCorridors = 2;

    public override void SetEmptyCoordinates()
    {
        for (int i = 0; i < horizontalCorridors; i++)
        {
            CrawlHorizontal();
        }
        for (int i = 0; i < verticalCorridors; i++)
        {
            CrawlVertical();
        }
    }

    public void CrawlVertical()
    {
        bool done = false;
        int x = width / 2;
        int z = 1;
        MapLocation location = new MapLocation(x, z);
        while (!done)
        {
            map.setEmpty(location);
            if (Random.Range(0, 101) < 50)
            {
                location.x += Random.Range(-1, 2);
            }
            else
            {
                location.z += Random.Range(1, 2);
            }
            done |= (location.x < 1 || location.x >= width - 1 || location.z < 0 || location.z >= depth - 1);
        }
    }

    public void CrawlHorizontal()
    {
        bool done = false;
        int x = 1;
        int z = depth / 2;
        MapLocation location = new MapLocation(x, z);
        while (!done)
        {
            map.setEmpty(location);
            if (Random.Range(0, 101) < 50)
            {
                location.x += Random.Range(1, 2);
            }
            else
            {
                location.z += Random.Range(-1, 2);
            }
            done |= (location.x < 1 || location.x >= width - 1 || location.z < 0 || location.z >= depth - 1);
        }
    }
}
