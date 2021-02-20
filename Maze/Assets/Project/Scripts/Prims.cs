using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prims : MazeCreator
{
    bool _Done = false;

    public bool Done { get => _Done; set => _Done = value; }

    public override void GenerateMap()
    {
        Done = false;
        int x = 2;
        int z = 2;
        Map[x, z] = 0;
        List<MazePos> PosList = new List<MazePos>();
        PosList.Add(new MazePos(x + 1, z));
        PosList.Add(new MazePos(x - 1, z));
        PosList.Add(new MazePos(x, z + 1));
        PosList.Add(new MazePos(x, z - 1));
        int countloops = 0;
        while (PosList.Count > 0 && countloops < 100000000)
        {
            int random = Random.Range(0, PosList.Count);
            int newx = PosList[random].X;
            int newz = PosList[random].Z;
            if (CountSquareNeighbours(newx, newz) == 1)
            {
                PosList.RemoveAt(random);
                x = newx;
                z = newz;
                Map[x, z] = 0;
                PosList.Add(new MazePos(x + 1, z));
                PosList.Add(new MazePos(x - 1, z));
                PosList.Add(new MazePos(x, z + 1));
                PosList.Add(new MazePos(x, z - 1));
            }
            countloops++;
        }
    }
}
