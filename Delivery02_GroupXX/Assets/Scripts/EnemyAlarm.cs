using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlarm : MonoBehaviour
{
    SpriteRenderer _alarmRenderer;
    [SerializeField] float _HorizontalSpeed;
    [SerializeField] Transform _DetectionPoint;
    [SerializeField] float _VisionCone = 4f;

    private bool _MoveLeft;
    private bool _MoveRight;

    Transform _Target;

    Rigidbody2D _Rigidbody2D;
    RaycastHit _RaycastHit = new RaycastHit();

    private void Awake()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() /* José Luis Mayhua-Charalla Espinpza, modifying the scale of the Rigidbody2D */
    {
        if (_Rigidbody2D.velocity.x < 0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = Vector2.one;
        }
    }
    public void PlayerDetected() /* José Luis Mayhua-Charalla Espinoza, it launched a RaycastHit
                                  * to detect the player*/
    {
        ChangeColor(Color.red);

        if (Physics.Raycast(_DetectionPoint.position, _DetectionPoint.forward, out _RaycastHit, _VisionCone))
        {
            if (_RaycastHit.collider.CompareTag("Player"))
            {
                _Target = _RaycastHit.collider.transform;
            }
        }
    }

    public void PlayerLeft(bool _MoveLeft) /* José Luis Mayhua-Charalla Espinoza, lead the AI movement in the left */
    {
        ChangeColor(new Color(0,0,0,0));
        Vector2 _NewVelocity = _Rigidbody2D.velocity;

        if (_MoveLeft)
        {
            _NewVelocity.x = -_HorizontalSpeed;
        }
    }

    public void PlayerRight(bool _MoveRight) /* José Luis Mayhua-Charalla Espinoza, lead the AI movement in the right */
    {
        Vector2 _NewVelocity = _Rigidbody2D.velocity;

        if (_MoveRight)
        {
            _NewVelocity.x = _HorizontalSpeed;
        }
    }

    private void ChangeColor(Color color)
    {
        if (_alarmRenderer == null) _alarmRenderer = GetComponent<SpriteRenderer>();

        _alarmRenderer.color = color;
    }
}
