using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    public static TilePool Instance; 
    public GameObject tilePrefab;
    public Transform tileTransform;
    public int poolSize = 10;            
    private Queue<GameObject> tilePool = new Queue<GameObject>();  
    private Queue<GameObject> tileActivePool = new Queue<GameObject>();  


    private void Awake()
    {
        Instance = this;           
    }
    public void TilePoolStart()
    {
        foreach (var tile in tileActivePool)
        {
           DestroyImmediate(tile.gameObject);
        }

        tilePool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject tile = Instantiate(tilePrefab,this.tileTransform);
            tile.SetActive(false);
            tilePool.Enqueue(tile);
        }
    }

    public GameObject GetTile()
    {

        if (tilePool.Count == 0)
        {
            GameObject newTile = Instantiate(tilePrefab, this.tileTransform);
            newTile.SetActive(false);
            return newTile;
        }

        GameObject tile = tilePool.Dequeue();
        tile.SetActive(true);
        tileActivePool.Enqueue(tile);
        return tile;
    }
    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        tilePool.Enqueue(tile);
    }
}
