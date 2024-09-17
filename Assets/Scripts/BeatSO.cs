using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBeatSO", menuName = "SO/BeatSO")]
[System.Serializable]
public class BeatSO : ScriptableObject
{
    public SongName SongName;
    public AudioClip MusicSong;
    public TileNote[] TileNotesSpawn;
}
