using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MazeCreator
{
    bool _Done = false;

    public bool Done { get => _Done; set => _Done = value; }

    public override void GenerateMap()
    {
        int Htimes = 3;
        int Vtimes = 3;
        while (Htimes != 0)
        {
            CrawlH();
            Htimes--;
        }
        while (Vtimes != 0)
        {
            CrawlV();
            Vtimes--;
        }

    }

    void CrawlV()
    {
        Done = false;
        int z = 1;
        int x = Random.Range(0, Width - 1);

        while (!Done)
        {
            Map[x, z] = 0;
            if (Random.Range(0, 100) < 50) x += Random.Range(-1, 2);
            else z += Random.Range(0, 2);
            Done |= (x < 1 || z < 1 || x >= Width - 1 || z >= Depth - 1);
        }
    }
    void CrawlH()
    {
        Done = false;
        int x = 1;
        int z = Random.Range(0, Depth - 1);

        while (!Done)
        {
            Map[x, z] = 0;
            if (Random.Range(0, 100) < 50) x += Random.Range(0, 2);
            else z += Random.Range(-1, 2);
            Done |= (x < 1 || z < 1 || x >= Width - 1 || z >= Depth - 1);
        }
    }
}
