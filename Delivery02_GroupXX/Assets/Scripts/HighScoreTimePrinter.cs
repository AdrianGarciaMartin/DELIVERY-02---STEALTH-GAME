using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTimePrinter : MonoBehaviour
{
    public SceneData _sceneData;
    public Text _timeText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PrintHighScore();
        Debug.Log(_sceneData._currentPointsHighScore); 
    }

    void PrintHighScore()
    {
        _timeText.text = "HIGHSCORE: " + _sceneData._currentPointsHighScore; //esto falla pero npi de porque
    }
}
