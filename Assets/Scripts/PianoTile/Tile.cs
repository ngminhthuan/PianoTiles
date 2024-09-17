using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public float baseFallSpeed = 100f;
    private bool isPressed = false;
    [SerializeField] Button _button;
    public void OnEnable()
    {
        _button.interactable = true;
        isPressed = false;
        baseFallSpeed = 100f;
     }
    void Update()
    {
        if (PianoTilesManager.Instance.isPlaying)
        {
            float currentFallSpeed = GetDynamicFallSpeed();
            transform.Translate(Vector3.down * currentFallSpeed * Time.deltaTime);


            if (transform.position.y < -0f && !isPressed)
            {
                PianoTilesManager.Instance.MissTile();
                ReturnToPool();
            }
        }
    }

    private float GetDynamicFallSpeed()
    {
        float songProgress = MusicManager.Instance.GetSongProgress();
        return Mathf.Lerp(baseFallSpeed, baseFallSpeed * 3f, songProgress);
    }

    public void OnTilePressed()
    {
        isPressed = true;
        _button.interactable = false;
        PianoTilesManager.Instance.ScorePoint();
        UIManager.Instance.GetPopup(UIName.GamePlayView).GetComponent<GamePlayView>().UpdateScore();
    }

    private void ReturnToPool()
    {
        TilePool.Instance.ReturnTile(gameObject);
    }
}
