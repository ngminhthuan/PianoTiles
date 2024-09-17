using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Song : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] BeatSO beatmap;
    // Start is called before the first frame update
    public void InitData(BeatSO songMap)
    {
        this.beatmap = songMap;
        nameText.text = songMap.SongName.ToString().Replace('_', ' ');
    }

    public void PlayThisSong()
    {
        
        UIManager.Instance.HidePopup(UIName.SelectSongPopup);
        UIManager.Instance.ShowPopup(UIName.GamePlayView);

        GamePlayView gamePlayView = UIManager.Instance.GetPopup(UIName.GamePlayView).GetComponent<GamePlayView>();
        if (gamePlayView != null)
        {
            MusicManager.Instance.ChangeSong(beatmap);
            gamePlayView.StartGame(beatmap);
        }
        
    }
}
