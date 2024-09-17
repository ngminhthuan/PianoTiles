using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayView : UIPopup
{
    [SerializeField] TMP_Text point_Text;
    [SerializeField] BeatSO currentBeatSO;

    public void UpdateScore()
    {
        point_Text.text = PianoTilesManager.Instance.GetScore().ToString();
    }
    public void StartGame(BeatSO beatSO = null)
    {
        MusicManager.Instance.UpdateState(SongState.play);
        PianoTilesManager.Instance.SetScore(0);
        PianoTilesManager.Instance.isPlaying = true;
        if(beatSO != null)
        {
            TileSpawner.Instance.SetBeatmap(beatSO);
            currentBeatSO = beatSO;
        }
        TileSpawner.Instance.StartSpawning();
        UpdateScore();
    }

    public void PauseGame()
    {
        MusicManager.Instance.UpdateState(SongState.pause);
        PianoTilesManager.Instance.isPlaying = false;
    }
    public void UnpauseGame()
    {
        MusicManager.Instance.UpdateState(SongState.unpause);
        PianoTilesManager.Instance.isPlaying = true;
    }
}
