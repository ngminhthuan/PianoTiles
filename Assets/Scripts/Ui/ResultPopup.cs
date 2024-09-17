using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPopup : UIPopup
{

    [SerializeField] TMP_Text _titleTxt;
    [SerializeField] TMP_Text _ScoreTxt;

    public void InitResult(bool isWin)
    {
        string Result = isWin == true ? "Win" : "Lost";
        _titleTxt.text = Result;
        _ScoreTxt.text = PianoTilesManager.Instance.GetScore().ToString();
    }
    public void OnClickPlayAgain()
    {
        UIManager.Instance.HidePopup(UIName.ResultPopup);
        UIManager.Instance.GetPopup(UIName.GamePlayView).GetComponent<GamePlayView>().StartGame();
    }

    public void OnClickMenu()
    {
        UIManager.Instance.HideAllPopup();
        UIManager.Instance.ShowPopup(UIName.SelectSongPopup);
    }
    
}
