using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectSongPopup : UIPopup
{
    [SerializeField] GameObject SongPrefab;
    [SerializeField] Transform ListSongPanel;
    [SerializeField] List<GameObject> SongList;
    private void OnEnable()
    {
        InitSong();
    }
    public void InitSong()
    {
        if (SongList.Count > 0) return;
        List<BeatSO> beatmaps = SOManager.Instance.GetSongDiction().Values.ToList();
        foreach(BeatSO beatmap in beatmaps)
        {
            GameObject songObject = Instantiate(SongPrefab, ListSongPanel);
            SongList.Add(songObject);
            // Get the Song component from the instantiated prefab
            Song songComponent = songObject.GetComponent<Song>();

            // Initialize the data in the Song component
            if (songComponent != null)
            {
                songComponent.InitData(beatmap);
            }
        }
    }
    public void BackToMenu()
    {
        UIManager.Instance.HidePopup(UIName.SelectSongPopup);
        UIManager.Instance.ShowPopup(UIName.MenuPopup);
    }
}
