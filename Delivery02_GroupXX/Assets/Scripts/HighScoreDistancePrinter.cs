using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDistancePrinter : MonoBehaviour
{
    public SceneData _sceneData;
    public Text _distanceText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrintHighScore();
    }

    void PrintHighScore()
    {
        _distanceText.text = "DISTANCE HIGHSCORE: " + _sceneData._currentDistanceHighScore;
    }
}
