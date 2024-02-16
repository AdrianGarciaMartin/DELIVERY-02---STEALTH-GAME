using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePrinter : MonoBehaviour
{
    public Text _timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Print();
    }

    void Print() //el metodo como tal funciona
    {
        _timeText.text = "HIGHSCORE: " + ScoreData._instance._currentTimeScore;
    }
}
