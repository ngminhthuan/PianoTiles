using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    [SerializeField] UIName _UIName;
    
    public UIName GetUIName()
    {
        return _UIName;
    }
}

public enum UIName
{
    MenuPopup,
    SettingPopup,
    SelectSongPopup,
    GamePlayView,
    ResultPopup,
}
