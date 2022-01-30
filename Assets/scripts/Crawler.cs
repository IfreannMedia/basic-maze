using System.Collections;
using System.Collections.Generic;
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
        while (!done)
        {
            map[x, z] = 0;
            if (Random.Range(0, 101) < 50)
            {
                x += Random.Range(-1, 2);
            }
            else
            {
                z += Random.Range(1, 2);
            }
            done |= (x < 1 || x >= width-1 || z < 0 || z >= depth-1);
        }
    }

    public void CrawlHorizontal()
    {
        bool done = false;
        int x = 1;
        int z = depth / 2;
        while (!done)
        {
            map[x, z] = 0;
            if (Random.Range(0, 101) < 50)
            {
                x += Random.Range(1, 2);
            }
            else
            {
                z += Random.Range(-1, 2);
            }
            done |= (x < 1 || x >= width-1 || z < 0 || z >= depth-1);
        }
    }
}
