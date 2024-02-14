using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIDistance : MonoBehaviour
{
    public SceneData _sceneData;
    Vector2 _startPos = Vector2.zero;
    Vector2 _positionAtFinishedMovement = Vector2.zero;
    int _currentMoveDistance = 0;
    public Text _moveDistanceText;
    public GameObject _player;
    float _distanceAccumulator; //esto lo que hace es lo que sobra lo va sumando hasta que llega a 1 y entonces lo suma
    //eso evita que vayas pulsando muy poco a poco y así evitar que cuente (porque la distancia es 0 coma algo y al aproximarse cuenta como que es 0)
    //no sé si es una buena solución pero no se me ocurre otra cosa
    void Awake()
    {
        _startPos = _player.transform.position;

        _moveDistanceText.text = "0 total distance";
    }

    void Start()
    {
        
    }

    void Update()
    {
        _sceneData.UpdateDistance(_currentMoveDistance);
    }

    void OnReleaseMovement() 
    {
        _positionAtFinishedMovement = _player.transform.position;
        TeakDistance();
    }

    int CalculateDistance() 
    {
        Vector2 distance = new Vector2(_startPos.x - _positionAtFinishedMovement.x, _startPos.y - _positionAtFinishedMovement.y);
        int distanceMoved = 0;

        //Debug.Log(distance);
        //Debug.Log((int)distance.magnitude); //me lo aproxima con lo que si me muevo poco a poco cuenta como 0 con lo que no se suma

        if (distance.magnitude >= 1f)
        {
            distanceMoved = (int)distance.magnitude;
        }

        else if (distance.magnitude <= 1f && distance.magnitude >= 0.5f)
        {
            distanceMoved = 1;
        }

        else
        {
            distanceMoved = 0;
            _distanceAccumulator += distance.magnitude;
        }

        if (_distanceAccumulator >= 1f)
        {
            distanceMoved += (int)_distanceAccumulator;
            _distanceAccumulator = 0;
        }

        return distanceMoved;
    }

    void TeakDistance()
    {
        _currentMoveDistance += CalculateDistance();
        _startPos = _positionAtFinishedMovement;
        UpdateUIMoveDistance();
    }

    void UpdateUIMoveDistance()
    {
        _moveDistanceText.text = _currentMoveDistance.ToString() + " total distance";
    }
}
