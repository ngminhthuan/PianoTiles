using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoTilesManager : MonoBehaviour
{
    public static PianoTilesManager Instance;
    public Transform[] spawnPoints;
    public bool isPlaying;
    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void ScorePoint()
    {
        score += 1;
    }

    public void MissTile()
    {
        isPlaying = false;
        MusicManager.Instance.UpdateState(SongState.stop);
        ShowResult(false);
    }

    public void WinGame()
    {
        isPlaying = false;
        MusicManager.Instance.UpdateState(SongState.stop);
        ShowResult(true);
    }
    private void ShowResult(bool isWin)
    {
        UIManager.Instance.ShowPopup(UIName.ResultPopup);
        UIManager.Instance.GetPopup(UIName.ResultPopup).GetComponent<ResultPopup>().InitResult(isWin);
    }
    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }
}
