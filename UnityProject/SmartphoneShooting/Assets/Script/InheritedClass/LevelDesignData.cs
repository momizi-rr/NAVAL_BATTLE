using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignData
{
    public int Level { get; set; }
    public int Pattern { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int PosZ { get; set; }
    public int RateX { get; set; }
    public int RateY { get; set; }
    public int RateZ { get; set; }
    public int ScaleX { get; set; }
    public int ScaleY { get; set; }
    public int ScaleZ { get; set; }

    public LevelDesignData()
    {
        Level = 0;
        Pattern = 0;
        PosX = 0;
        PosY = 0;
        PosZ = 0;
        RateX = 0;
        RateY = 0;
        RateZ = 0;
        ScaleX = 0;
        ScaleY = 0;
        ScaleZ = 0;
    }
}
