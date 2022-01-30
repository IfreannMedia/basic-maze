using UnityEngine;

public class MapLocation
{
    public int x, z;

    public MapLocation(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
}


public class Maze : MonoBehaviour
{

    public int width = 30;
    public int depth = 30;
    public byte[,] map;
    public int scale = 6;

    void Start()
    {
        InitializeMap();
        SetEmptyCoordinates();
        DrawMap();
    }

    private void InitializeMap()
    {
        map = new byte[width, depth];
        for (int x = 0; x < depth; x++)
        {
            for (int z = 0; z < width; z++)
            {
                map[x, z] = 1; //1 = wall, 0 = corridor
            }
        }
    }

    public virtual void SetEmptyCoordinates()
    {
        for (int x = 0; x < depth; x++)
        {
            for (int z = 0; z < width; z++)
            {
                if (Random.Range(0, 101) < 50)
                {
                    map[x, z] = 0;
                }
            }
        }
    }

    private void DrawMap()
    {
        for (int x = 0; x < depth; x++)
        {
            for (int z = 0; z < width; z++)
            {
                if (map[x, z] == 1)
                {
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    wall.transform.position = pos;
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                }

            }
        }
    }

    // neighbours as in neighbouring "empty" blocks
    public int CountOthogonalNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1)
        {
            return 5;
        }
        if (map[x - 1, z] == 0)
            count++;
        if (map[x, z + 1] == 0)
            count++;
        if (map[x + 1, z] == 0)
            count++;
        if (map[x, z - 1] == 0)
            count++;

        return count;
    }

    public int CountDiagonalNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1)
        {
            return 5;
        }
        if (map[x - 1, z - 1] == 0)
            count++;
        if (map[x - 1, z + 1] == 0)
            count++;
        if (map[x + 1, z - 1] == 0)
            count++;
        if (map[x + 1, z + 1] == 0)
            count++;

        return count;
    }

    public int CountAllNeighbours(int x, int z)
    {
        return CountOthogonalNeighbours(x, z) + CountDiagonalNeighbours(x, z);
    }
}
