using UnityEngine;

public class MapLocation
{
    public int x, z;

    public MapLocation(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public MapLocation(MapLocation loc)
    {
        this.x = loc.x;
        this.z = loc.z;
    }
}

public class Maze : MonoBehaviour
{

    public int width = 30;
    public int depth = 30;
    public MazeMap map;
    public int scale = 6;

    void Start()
    {
        InitializeMap();
        SetEmptyCoordinates();
        DrawMap();
    }

    private void InitializeMap()
    {
        map = new MazeMap(width, depth);
        for (int x = 0; x < depth; x++)
        {
            for (int z = 0; z < width; z++)
            {
                map.setFilled(new MapLocation(x, z));
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
                    map.setEmpty(new MapLocation(x, z));
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
                if (!map.isLocationUsed(new MapLocation(x,z)))
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
    public int CountOthogonalNeighbours(MapLocation location)
    {
        int count = 0;
        if (location.x <= 0 || location.x >= width - 1 || location.z <= 0 || location.z >= depth - 1)
        {
            return 5;
        }
        if (map.isLocationEmpty(location.x - 1, location.z))
            count++;
        if (map.isLocationEmpty(location.x, location.z + 1))
            count++;
        if (map.isLocationEmpty(location.x + 1, location.z))
            count++;
        if (map.isLocationEmpty(location.x, location.z - 1))
            count++;

        return count;
    }

    public int CountDiagonalNeighbours(MapLocation location)
    {
        int count = 0;
        if (location.x <= 0 || location.x >= width - 1 || location.z <= 0 || location.z >= depth - 1)
        {
            return 5;
        }
        if (map.isLocationEmpty(location.x - 1, location.z - 1))
            count++;
        if (map.isLocationEmpty(location.x - 1, location.z + 1))
            count++;
        if (map.isLocationEmpty(location.x + 1, location.z - 1))
            count++;
        if (map.isLocationEmpty(location.x + 1, location.z + 1))
            count++;

        return count;
    }

    public int CountAllNeighbours(MapLocation location)
    {
        return CountOthogonalNeighbours(location) + CountDiagonalNeighbours(location);
    }
}
