using TMPro;
using UnityEngine;
//using static Autogatherer;

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
        private int _clickLvl = 0;
        private int _autoGLvl;
        private int _score;
        private int _clickGain;
        private int _autoGGAin = 0;
        private int _cost = 20;
        private float _gathering = 5.0f;
        private float _time = 0.0f;

        private void OnEnable()
        {
            _scoreDisplay.SetText(_score.ToString());
            _clickLevel.SetText("lvl." + _clickLvl.ToString());
            _clickGain = (int)Mathf.Round(Mathf.Pow(2, _clickLvl));
            _clickStatus.SetText(_clickGain.ToString()+" per click");
            InvokeRepeating("Gathering", 5, 5);
            InvokeRepeating("Test", 5, 5);
        }

        void start()
        {

        }

        public void IncreaseScore()
        {
            _score+= _clickGain;
            _scoreDisplay.SetText(_score.ToString());
        }

        public void LevelUp()
        {
            if (_score < 20)
            {
                _upgradeError.SetText("Missing ressources");
                return;
            }

            _score -= _cost;
            _clickLvl++;
            _clickGain = (int)Mathf.Round(Mathf.Pow(2, _clickLvl));
            UpdateUI();
        }

        private void UpdateUI()
        {
            _upgradeError.SetText("");
            _scoreDisplay.SetText(_score.ToString());
            _clickLevel.SetText("lvl." + _clickLvl.ToString());
            _clickStatus.SetText(_clickGain.ToString() + " per click");
            _autoGLevel.SetText("lvl." + _autoGLvl.ToString());
            _autoGStatus.SetText(_autoGGAin.ToString() + " per 5 sec");
        }

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

        public void Test()
        {
            Debug.Log("coucou");
        }

        public void Gathering()
        {
            _score += _autoGGAin;
            UpdateUI();
        }

       /* void update()
        {
            _time = Time.deltaTime;

            if(_time > _gathering)
            {
                gathering();
            }
        }*/
    
    
    }


    }
