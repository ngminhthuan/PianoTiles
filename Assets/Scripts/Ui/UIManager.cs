using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] Dictionary<UIName,UIPopup> _popupList = new Dictionary<UIName, UIPopup>();
    [SerializeField] List<GameObject> popupList = new List<GameObject>();
    [SerializeField] GameObject _currentPopup;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }
    private void OnEnable()
    {
        LoadPopup();
        ShowPopup(UIName.MenuPopup);
    }
    public void ShowPopup(UIName UINameShow)
    {
        if (_popupList.ContainsKey(UINameShow))
        {
            GameObject PopupGameObj = _popupList[UINameShow].gameObject;
            if (!popupList.Contains(PopupGameObj))
            {
                GameObject PopupObj = Instantiate(PopupGameObj, this.transform);
                UIPopup popup = PopupObj.GetComponent<UIPopup>();
                _popupList[popup.GetUIName()] = popup;
                popupList.Add(PopupObj);
                _currentPopup = PopupObj;
            }
            else
            {
                PopupGameObj.SetActive(true);
                _currentPopup = PopupGameObj;
            }
        }
    }

    public void HidePopup(UIName UIName)
    {
        if (_popupList.ContainsKey(UIName))
        {
            _popupList[UIName].gameObject.SetActive(false);
        }
    }

    public void HideAllPopup()
    {
        foreach(GameObject popup in popupList) { 
            popup.gameObject.SetActive(false);
        }
    }
    public void LoadPopup()
    {
        UIPopup[] uIPopups = SOManager.Instance.LoadPopups();

        foreach(UIPopup uIPopup in uIPopups)
        {
            if (!_popupList.ContainsKey(uIPopup.GetUIName()))
            {
                _popupList.Add(uIPopup.GetUIName(), uIPopup);
            }
        }
        
    }

    public GameObject GetPopup(UIName uiName)
    {
        if (_popupList.ContainsKey(uiName))
        {
            return _popupList[uiName].gameObject;
        }
        return null;
    }

}
