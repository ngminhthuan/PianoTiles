using System.Data;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource music;
    public AudioClip backgroundClip;
    public BeatSO currentBeatmap;             
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeSong(BeatSO newBeatmap)
    {
        music.Stop();
        music.clip = newBeatmap.MusicSong;
        currentBeatmap = newBeatmap;
        
    }
    // Get the current progress of the song (0 = start, 1 = end)
    public float GetSongProgress()
    {
        if (music.clip != null && music.clip.length > 0)
        {
            return music.time / music.clip.length;
        }
        return 0f;  // Default if there's no song loaded
    }

    public void UpdateState(SongState songState)
    {
        switch (songState)
        {
            case SongState.play:
                music.Play();
                break;
            case SongState.stop:
                music.Stop();
                break;
            case SongState.pause:
                music.Pause();
                break;
            case SongState.unpause:
                music.Pause();
                break;
        }
        
    }

    
}

public enum SongState
{
    play, pause, unpause, stop
}
