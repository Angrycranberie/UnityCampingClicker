using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

    
    public GameObject _menu;
    public GameObject _openButton;
    public GameObject _closeButton;
    
    //Open (set visible) the menu with animation
    public void OpenMenu()
    {
      if(_menu != null && _openButton != null && _closeButton != null) //verify that GameObject is not null
        {
           Animator animator = _menu.GetComponent<Animator>();
           if(animator != null){
               bool isOpen = animator.GetBool("open");
               animator.SetBool("open",!isOpen);
           }
          
            _closeButton.SetActive(true);
        }
    }

    //Close (set invisible) the menu with animation
    public void CloseMenu()
    {
        if(_menu !=null && _openButton !=null && _closeButton != null)
        {
            Animator animator = _menu.GetComponent<Animator>();
           if(animator != null){
               bool isOpen = animator.GetBool("open");
               animator.SetBool("open",!isOpen);
           };
            _closeButton.SetActive(false);
        }
    }
}
