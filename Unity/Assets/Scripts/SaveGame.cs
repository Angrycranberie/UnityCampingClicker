using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace clicker{

    public class SaveGame : MonoBehaviour
    {
        
        public string _url = "http://localhost/unity/save.php"; //url for the php script, change it with your path
        private string _characters= "0123456789abcdefghijklmnopqrstuvwxABCDEFGHIJKLMNOPQRSTUVWXYZ"; //tool for create the code
        
        [SerializeField] private TMP_Text _codeDisplay;
        public GameObject _saveMenu;
        
        private string _code;
        private int _score;
        private int _clickLvl;
        private int _autoGLvl;
        
        //Used when we click on the save button
        public void ClickOnSave(){
            
            //generate a random 6-char code
            for(int i = 0; i<6; i++) {
                int a = Random.Range(0,_characters.Length);
                _code = _code + _characters[a];
            }

            //get the data to save
            GameObject _data = GameObject.Find("Player");
            PlayerScore _player = _data.GetComponent<PlayerScore>();
            
            _score = _player._score;
            _clickLvl = _player._clickLvl;
            _autoGLvl = _player._autoGLvl;
            
            DisplaySaveMenu();
            StartCoroutine(saving());
        }
        
        //Open the pop-up window with the save code
        private void DisplaySaveMenu(){
            if(_saveMenu != null){
                _saveMenu.SetActive(true);
                _codeDisplay.SetText(_code);
            }
        }

        //Close the pop-up window with the save code
        public void CloseSaveMenu(){
            _saveMenu.SetActive(false);
            _codeDisplay.SetText("");
        }
        
        //Communicate all the data to the database
        IEnumerator saving(){
            WWWForm save = new WWWForm();
            save.AddField("code", _code);
            save.AddField("score", _score);
            save.AddField("clickLvl", _clickLvl);
            save.AddField("autoGLvl", _autoGLvl);
            
            using(UnityWebRequest www = UnityWebRequest.Post(_url,save)){

                yield return www.SendWebRequest() ;

                if(www.isNetworkError) {
                    Debug.Log(www.error);
                }
                else {
                    Debug.Log("Form upload complete!");
                }
            }
            Debug.Log("saved");
        }

    }

}