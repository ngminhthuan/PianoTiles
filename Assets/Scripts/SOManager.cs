using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SOManager : MonoBehaviour
{
    public bool loadingSuccess = false;
    private static SOManager _instance;

    public static SOManager Instance {
        get
        {
            if (_instance == null)
            {
                // Try to find an existing instance in the scene
                _instance = FindObjectOfType<SOManager>();

                // If no instance is found, create a new one
                if (_instance == null)
                {
                    // Create a new GameObject to hold the SOManager
                    GameObject obj = new GameObject("SOManager");
                    _instance = obj.AddComponent<SOManager>();

                    // Optionally, you can set it to not be destroyed on load
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        } 
    }

    [SerializeField] private Dictionary<SongName, BeatSO> _BeatMapByNameDict = new Dictionary<SongName, BeatSO>();

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
           
        }
        LoadBeatmaps();
        loadingSuccess = true;
    }

    private void LoadBeatmaps()
    {
        BeatSO[] beatmaps = Resources.LoadAll<BeatSO>("SO/BeatSO");

        foreach (BeatSO beatmap in beatmaps)
        {
            _BeatMapByNameDict.TryAdd(beatmap.SongName, beatmap);
        }

        Debug.Log("Beatmaps loaded into the dictionary.");
    }

    public BeatSO GetBeatmap(SongName songName)
    {
        if (_BeatMapByNameDict.TryGetValue(songName, out BeatSO beatmap))
        {
            return beatmap;
        }
        else
        {
            Debug.LogError($"Beatmap for {songName} not found!");
            return null;
        }
    }

    public Dictionary<SongName, BeatSO> GetSongDiction()
    {
        return _BeatMapByNameDict;
    }

    public UIPopup[] LoadPopups()
    {
        UIPopup[] uiPopups = Resources.LoadAll<UIPopup>("Prefabs/UI");

        return uiPopups;
    }
}
