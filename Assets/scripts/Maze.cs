using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{

    public GameObject cube;
    public int width = 30;
    public int depth = 30;

    void Start()
    {
        for (int width = 0; width < 30; width++)
        {
            for (int length = 0; length < 30; length++)
            {
                Vector3 pos = new Vector3(width, 0, length);
                Instantiate(cube, pos, Quaternion.identity);
            }
        }
    }

}
