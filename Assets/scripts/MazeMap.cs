public class MazeMap
{
    private byte[,] map;

    public MazeMap(int width, int depth)
    {
        map = new byte[width, depth];
    }
    public void setEmpty(MapLocation location)
    {
        map[location.x, location.z] = 0;
    }

    public void setFilled(MapLocation location)
    {
        map[location.x, location.z] = 1;
    }

    public void setPartOfMaze(MapLocation location)
    {
        map[location.x, location.z] = 2;
    }

    public bool isLocationEmpty(MapLocation location)
    {
        return map[location.x, location.z] == 0;
    }

    public bool isLocationEmpty(int x, int z)
    {
        return this.isLocationEmpty(new MapLocation(x, z));
    }

    public bool isLocationPartOfMaze(MapLocation location)
    {
        return map[location.x, location.z] == 2;
    }

    public bool isLocationPartOfMaze(int x, int z)
    {
        return this.isLocationPartOfMaze(new MapLocation(x, z));
    }

    internal bool isLocationUsed(MapLocation location)
    {
        return this.isLocationEmpty(location) || this.isLocationPartOfMaze(location);
    }
}

