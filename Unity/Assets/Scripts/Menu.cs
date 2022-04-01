using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {
    public GameObject _menu;
    public GameObject _openButton;
    public GameObject _closeButton;
    
    public void OpenMenu()
    {
      if(_menu != null && _openButton != null && _closeButton != null)
        {
            _menu.SetActive(true);
            _openButton.SetActive(false);
        }
    }

    public void CloseMenu()
    {
        if(_menu !=null && _openButton !=null && _closeButton != null)
        {
            _menu.SetActive(false);
            _openButton.SetActive(true);
        }
    }
}
