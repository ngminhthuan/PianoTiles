using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopup : UIPopup
{
    public void OnClickPlay()
    {
        UIManager.Instance.HidePopup(UIName.MenuPopup);
        UIManager.Instance.ShowPopup(UIName.SelectSongPopup);
    }

    public void OnClickSetting()
    {
        UIManager.Instance.ShowPopup(UIName.SettingPopup);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
