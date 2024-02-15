using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    public Text _timeText;

    public float _time;

    int _timeToPrint;

    bool _minuteReached = false;

    int _minuteCounter = 0;

    //public SceneData _sceneData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddTime();
        TeakTime();
        UpdateUI();

        //_sceneData.UpdateTime(_minuteCounter, _timeToPrint);

        //SceneData.UpdateTime(_minuteCounter, _timeToPrint);

        if (_timeToPrint > 0) //esto es una tontería, si da problemas quitadlo, lo puse por probar
        {
            ScoreData._instance.UpdateTime(_minuteCounter, _timeToPrint);
        }
    }

    void AddTime()
    {
        _time += Time.deltaTime;

        if (_time >= 60.0f)
        {
            _minuteReached = true;
            _minuteCounter++;
            _time = 0.0f;
        }
    }

    void TeakTime()
    {
        _timeToPrint = (int)_time;
    }

    void UpdateUI()
    {
        if (_minuteReached)
            _timeText.text = _minuteCounter.ToString() + " minute/s " + _timeToPrint.ToString() + " seconds";

        else
            _timeText.text = _timeToPrint.ToString() + " seconds";
    }
}
