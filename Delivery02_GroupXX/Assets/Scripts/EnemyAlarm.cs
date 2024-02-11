using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    SpriteRenderer _alarmRenderer;
    [SerializeField] PlayerMovement _PlayerMovement;
    [SerializeField] Transform _DetectionPoint;
    [SerializeField] float _VisionCone = 4f;
    [SerializeField] float _DistanceForLettingGo = 5f;

    Transform _Target;

    RaycastHit _RaycastHit = new RaycastHit();

    void FixedUpdate() /* José Luis Mayhua-Charalla Espinoza, initializing the AI loop */
    {
        if (!_Target)
        {
            PlayerDetected();
        }
        else
        {
            PlayerLeft();
        }
    }

    public void PlayerDetected() /* José Luis Mayhua-Charalla Espinoza, it launched a RaycastHit
                                  * to detect the player, and if not, the AI does not move */
    {
        ChangeColor(Color.red);

        if (Physics.Raycast(_DetectionPoint.position, _DetectionPoint.forward, out _RaycastHit, _VisionCone))
        {
            if (_RaycastHit.collider.CompareTag("Player"))
            {
                _Target = _RaycastHit.collider.transform;
            }
        }

        /* "_PlayerMovement == false" */
    }

    public void PlayerLeft() /* José Luis Mayhua-Charalla Espinoza, lead the AI movement */
    {
        ChangeColor(new Color(0,0,0,0));

        Vector2 direction = _Target.position - transform.position;
        float distance = direction.magnitude;
        if (distance > _DistanceForLettingGo)
        {
            _Target = null;
        }
        else
        {
            if (_Target.position.x < transform.position.x)
            {
                /* "_PlayerMovement == MoveLeft" */
            }
            else
            {
                /* "PlayerMovement == MoveRight" */
            }
        }
    }

    private void ChangeColor(Color color)
    {
        if (_alarmRenderer == null) _alarmRenderer = GetComponent<SpriteRenderer>();

        _alarmRenderer.color = color;
    }
}
