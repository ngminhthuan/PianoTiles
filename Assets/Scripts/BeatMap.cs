using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SongName
{
    We_dont_talk_anymore,
    Lac_troi,
    Chill_song
}

[System.Serializable]
public class TileNote
{
    public float tileSpawnTime;
    public TileLane tileLane;
}

public enum TileLane
{
    lane1 = 0,
    lane2 = 1,
    lane3 = 2,
    lane4 = 3,
        
}