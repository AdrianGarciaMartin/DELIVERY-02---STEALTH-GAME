using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePrinter : MonoBehaviour
{
    public Text _timeText;
    public Text _titleText;

    // Start is called before the first frame update
    void Start()
    {
        Print();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Print() //el metodo como tal funciona
    {
        _timeText.text = "HIGHSCORE: " + ScoreData._instance._currentTimeScore;
        
        if(ScoreData._instance._playerIsDead == true)
        {
            _titleText.color = Color.red;
            _titleText.text = "GAME OVER";
        }
        else
        {
            _titleText.color = Color.green;
            _titleText.text = "YOU WIN";
        }
    }
}
