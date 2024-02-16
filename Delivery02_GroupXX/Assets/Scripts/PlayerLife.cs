using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    
    public SceneLoader _sceneLoader;


    // Start is called before the first frame update
    void Start()
    {
        ScoreData._instance._playerIsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ScoreData._instance._playerIsDead = true;
            _sceneLoader.EnterExitScene();
        }
        if (collision.gameObject.tag == "EditorOnly")
        {
            _sceneLoader.EnterExitScene();
        }
    }
}
