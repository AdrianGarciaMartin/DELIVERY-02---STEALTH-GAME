using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScoreData _instance;

    public int _currentTimeScore;
    public int _currentHighScore;
    //int _totalTime;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
            
        }
Debug.Log(gameObject.name);
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //Debug.Log(_currentHighScore); //al inicio es 0

        //si al inicio el highscore es 0, el player no puede completar el nivel en un tiempo inferior a 0 con lo que no hay nuevo highscore
        //maybe no va muy bien un highscore tan alto
    }

    void Update() //funciona
    {
        if (_currentTimeScore == 0)
        {
            SetNewHighScore();
        }

        else
        {
            if (_currentHighScore > _currentTimeScore)
            {
                SetNewHighScore();
            }
        }
    }

    public void UpdateTime(int minutes, int seconds)
    {
        int minutesInSeconds = 0;

        if (minutes > 0)
        {
            minutesInSeconds = minutes * 60;
            seconds += minutesInSeconds;
        }

        _currentTimeScore = seconds;

        //Debug.Log("currenttime" + _currentTimeScore); //aqui el tiempo es el correcto pero por algún motivo al asignarse su valor como el highscore actual se pone en 0 y por eso no escribe nada
    }

    public void SetNewHighScore()
    {
        _currentHighScore = _currentTimeScore; //current highscore se iguala a 0
        Debug.Log(_currentHighScore);
    }
}
