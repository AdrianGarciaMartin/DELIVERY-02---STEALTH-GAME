using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    int _totalTime;
    public int _currentPointsHighScore;
    int _totalDistance;
    public int _currentDistanceHighScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectHighScore();
    }

    public void UpdateTime(int minutes, int seconds)
    {
        //_totalTime = time;

        int minutesInSeconds = 0;

        if (minutes > 0)
        {
            minutesInSeconds = minutes * 60;

            seconds += minutesInSeconds;
        }

        _totalTime += seconds;
    }
    public void UpdateDistance(int distance)
    {
        _totalDistance = distance;
    }

    void SelectHighScore()
    {
        if (_currentDistanceHighScore > _totalDistance)
        {
            _currentDistanceHighScore = _totalDistance;
        }

        if (_currentPointsHighScore > _totalTime)
        {
            _currentPointsHighScore = _totalTime;
        }
    }

    
}
