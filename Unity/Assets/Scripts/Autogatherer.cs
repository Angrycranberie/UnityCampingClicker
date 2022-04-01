using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**public class Autogatherer : MonoBehaviour
{
    
    private float _time = 0.0f;
    public float _gathering = 5.0f;
    public int _autoGLvl = 0;
    private int _gain = 0;
    private int _cost = 20;
    public static Autogatherer _autoG;

    void start()
    {
        InvokeRepeating("Gathering", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGain()
    {
        if (_autoGLvl != 0) {
            _gain = ((int)Mathf.Round(Mathf.Pow(2, _autoGLvl))) / 2;
        }
    }
    public int Gathering()
    {
        return (_gain);
    }

    public void LevelUp()
    {
        _autoGLvl++;
    }

    public int getLevel()
    {
        return (_autoGLvl);
    }


}
**/