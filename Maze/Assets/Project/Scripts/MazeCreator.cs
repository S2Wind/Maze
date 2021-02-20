using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePos
{
    int x;
    int z;
    public MazePos(int x, int z)
    {
        this.X = x;
        this.Z = z;
    }

    public int X { get => x; set => x = value; }
    public int Z { get => z; set => z = value; }
}
public class MazeCreator : MonoBehaviour
{
    [SerializeField]
    GameObject _Prefabs = null;
    [SerializeField] int _Width = 0;
    [SerializeField] int _Depth = 0;
    [SerializeField] byte[,] _Map = null;
    [SerializeField] int _LocalScale = 1;

    public GameObject Prefabs { get => _Prefabs; set => _Prefabs = value; }
    public int Width { get => _Width; set => _Width = value; }
    public int Depth { get => _Depth; set => _Depth = value; }
    public byte[,] Map { get => _Map; set => _Map = value; }

    void Start()
    {
        InitializeMap();
        GenerateMap();
        DrawMap();
    }

    void InitializeMap()
    {
        Map = new byte[Width, Depth];
        for (int z = 0; z < Depth; z++)
        {
            for (int x = 0; x < Width; x++)
            {
                Map[x, z] = 1;
            }
        }
    }

    public virtual void GenerateMap()
    {
        for (int z = 0; z < Depth; z++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (Random.Range(0, 100) < 50) Map[x, z] = 0;
            }
        }
    }

    void DrawMap()
    {
        GameObject m_TempObject = null;
        for (int z = 0; z < Depth; z++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (Map[x, z] == 1)
                {
                    m_TempObject = GameObject.Instantiate(Prefabs, new Vector3(x, 0, z) * _LocalScale, Quaternion.identity);
                    m_TempObject.transform.localScale *= _LocalScale;
                    m_TempObject.name = string.Format("Cube{0}-{1}", x, z);
                }
            }
        }
    }

    public int CountSquareNeighbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= Width - 1 || z <= 0 || z >= Depth - 1) return 5;
        if (Map[x - 1, z] == 0) count++;
        if (Map[x + 1, z] == 0) count++;
        if (Map[x, z - 1] == 0) count++;
        if (Map[x, z + 1] == 0) count++;
        return count;
    }
    public int CountDiagonaNeigbours(int x, int z)
    {
        int count = 0;
        if (x <= 0 || x >= Width - 1 || z <= 0 || z >= Depth - 1) return 5;
        if (Map[x - 1, z - 1] == 0) count++;
        if (Map[x + 1, z - 1] == 0) count++;
        if (Map[x - 1, z + 1] == 0) count++;
        if (Map[x + 1, z + 1] == 0) count++;
        return count;
    }
    public int CountAllNeighbours(int x, int z)
    {
        if (x <= 0 || x >= Width - 1 || z <= 0 || z >= Depth - 1) return 9;
        return CountSquareNeighbours(x, z) + CountDiagonaNeigbours(x, z);
    }

}
