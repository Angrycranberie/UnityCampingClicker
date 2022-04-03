using TMPro;
using System.Collections;
using UnityEngine;

namespace clicker
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreDisplay;
        [SerializeField] private TMP_Text _clickLevel;
        [SerializeField] private TMP_Text _upgradeError;
        [SerializeField] private TMP_Text _clickStatus;
        [SerializeField] private TMP_Text _autoGLevel;
        [SerializeField] private TMP_Text _autoGStatus;
        
        public GameObject _loadErrorText;
        
        public int _clickLvl = 0;
        public int _autoGLvl;
        public int _score;
        private int _clickGain;
        private int _autoGGAin = 0;
        private int _cost = 20;

        //Set up everthing
        private void OnEnable()
        {
            _scoreDisplay.SetText(_score.ToString());
            _clickLevel.SetText("lvl." + _clickLvl.ToString());
            _clickGain = (int)Mathf.Round(Mathf.Pow(2, _clickLvl));
            _clickStatus.SetText(_clickGain.ToString()+" per click");
            
            InvokeRepeating("Gathering", 5, 5); //Gather ressources every 5 seconds
        }

        //Increase the score by the actual gain per click
        public void IncreaseScore()
        {
            _score+= _clickGain;
            _scoreDisplay.SetText(_score.ToString());
        }

        //Level up the click
        public void LevelUp()
        {      
            //check ressources
            if (_score < 20)
            {
                _upgradeError.SetText("Missing ressources");
                return;
            }

            _score -= _cost;
            _clickLvl++;
            _clickGain = (int)Mathf.Round(Mathf.Pow(2, _clickLvl)); //update gain per click
            UpdateUI(); //update all the UI
        }

        //Update all the UI thus no outdated text
        private void UpdateUI()
        {
            _upgradeError.SetText("");
            _scoreDisplay.SetText(_score.ToString());
            _clickLevel.SetText("lvl." + _clickLvl.ToString());
            _clickStatus.SetText(_clickGain.ToString() + " per click");
            _autoGLevel.SetText("lvl." + _autoGLvl.ToString());
            _autoGStatus.SetText(_autoGGAin.ToString() + " per 5 sec");
        }

        //Level up auto-gathering
        public void AutoGLevelUp()
        {
            if (_score < 20)
            {
                _upgradeError.SetText("Missing ressources");
                return;
            }

            _score -= _cost;
            _autoGLvl++;
            _autoGGAin = ((int)Mathf.Round(Mathf.Pow(2, _autoGLvl))) / 2;
            UpdateUI();

        }

        //Gather ressources
        public void Gathering()
        {
            _score += _autoGGAin;
            UpdateUI();
        }

        //Take Input data and load it as it is the actual value for the game main variables. Used to load a game.
        public void Load(int score, int clvl, int aglvl){
            if(score == -1){
                StartCoroutine(LoadErrorDisplay());
                return;
            }
            _score = score;
            _clickLvl = clvl;
            _autoGLvl = aglvl;
            _clickGain = (int)Mathf.Round(Mathf.Pow(2, _clickLvl));
            _autoGGAin = ((int)Mathf.Round(Mathf.Pow(2, _autoGLvl))) / 2;
            UpdateUI();

        }

        //Display a message if no save was found. the message last 5 second
        IEnumerator LoadErrorDisplay(){
            _loadErrorText.SetActive(true);
            yield return new WaitForSeconds(5f);
            _loadErrorText.SetActive(false);            
        }
    }


    }
