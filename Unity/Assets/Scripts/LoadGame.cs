using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

namespace clicker{

    public class LoadGame : MonoBehaviour
    {

        public string _url = "http://localhost/unity/load.php"; //url for the php script, change it with your path

        public string[] _loadvalue;
        public GameObject _loadMenu;
        public TMP_InputField _loadCode;
        
        //Open the pop-up menu
        public void OpenLoadMenu(){
            _loadMenu.SetActive(true);
        }
        
        //trigger when we click on the load button
        public void clickOnLoad(){
            StartCoroutine(Load());
            _loadMenu.SetActive(false);
        }
        
        //Get all the data frome the database and send it to the game
        IEnumerator Load(){
            WWWForm code = new WWWForm();
            code.AddField("code",_loadCode.text);
            using(UnityWebRequest www = UnityWebRequest.Post(_url,code) ){
                www.downloadHandler = new DownloadHandlerBuffer();
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log("error" + www.error);
                }
                else
                {
                    string responseText = www.downloadHandler.text;
                    Debug.Log(responseText);
                    _loadvalue = responseText.Split('|');
                    
                }
            }
            GameObject _data = GameObject.Find("Player");
            PlayerScore _player = _data.GetComponent<PlayerScore>();

            if(int.Parse(_loadvalue[0]) == -1){
                _player.Load(-1,0,0);
            }else{
                _player.Load(int.Parse(_loadvalue[0]),int.Parse(_loadvalue[1]),int.Parse(_loadvalue[2]));
            }
        }
    }
}
