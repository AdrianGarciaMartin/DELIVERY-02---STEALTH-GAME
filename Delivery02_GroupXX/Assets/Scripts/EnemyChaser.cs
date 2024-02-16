using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyChaser : MonoBehaviour
{
    EnemyAlarm _EnemyAlarm;
    [SerializeField] float _DistanceForLettingGo = 5f;

    Transform _Target;

    private bool _MoveLeft;
    private bool _MoveRight;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    void FixedUpdate()
    {
        if (!_Target)/* José Luis Mayhua-Charalla Espinoza, initializing the AI loop */
        {
            _EnemyAlarm.PlayerDetected();

            _EnemyAlarm.PlayerLeft(false);
            _EnemyAlarm.PlayerRight(false);
        }
        else
        {
            Vector2 _Direction = _Target.position - transform.position;
            float _Distance = _Direction.magnitude;

            if (_Distance > _DistanceForLettingGo)
            {
                _Target = null;
            }
            else
            {
                if (_Target.position.x < transform.position.x)
                {
                    _EnemyAlarm.PlayerLeft(true);
                    _EnemyAlarm.PlayerRight(false);
                }
                else
                {
                    _EnemyAlarm.PlayerLeft(false);
                    _EnemyAlarm.PlayerRight(true);
                }
            }
        }
    }
}
