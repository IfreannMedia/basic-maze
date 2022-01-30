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
}
