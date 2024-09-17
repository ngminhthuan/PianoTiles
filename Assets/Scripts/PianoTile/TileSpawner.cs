using System.Collections;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    private static TileSpawner _instance;
    public static TileSpawner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TileSpawner>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject("TileManager");
                    _instance = obj.AddComponent<TileSpawner>();

                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }
    public Transform[] spawnPoints; 
    private BeatSO currentBeatmap;
    private int nextTileIndex = 0;

    public void StartSpawning()
    {
        nextTileIndex = 0;
        TilePool.Instance.TilePoolStart();
        StopCoroutine(SpawnTilesWithMusic());
        StartCoroutine(SpawnTilesWithMusic());
    }

    // Set the current beatmap when changing songs
    public void SetBeatmap(BeatSO newBeatmap)
    {
        currentBeatmap = newBeatmap;
        nextTileIndex = 0; // Reset tile index for the new song
    }

    private IEnumerator SpawnTilesWithMusic()
    {
        while (nextTileIndex < currentBeatmap.TileNotesSpawn.Length && PianoTilesManager.Instance.isPlaying)
        {
            float currentTime = MusicManager.Instance.music.time;

            // Check if it's time to spawn the next tile
            if (currentTime >= currentBeatmap.TileNotesSpawn[nextTileIndex].tileSpawnTime)
            {
                int lane = (int) currentBeatmap.TileNotesSpawn[nextTileIndex].tileLane;

                GameObject tile = TilePool.Instance.GetTile();
                tile.transform.position = spawnPoints[lane].position;

                nextTileIndex++;
            }
            yield return null;
        }

        while (nextTileIndex >= currentBeatmap.TileNotesSpawn.Length)
        {
            PianoTilesManager.Instance.WinGame();
            yield return null;
        }
    }
}

