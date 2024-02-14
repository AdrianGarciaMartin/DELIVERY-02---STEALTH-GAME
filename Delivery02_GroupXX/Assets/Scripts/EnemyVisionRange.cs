using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyVisionRange : MonoBehaviour //revisar nomenclaturas
{
    public float _radius = 5f;
    [Range(1, 360)]
    public float _angle = 45f;

    //public LayerMask _targetLayer;
    //public LayerMask _obstructionLayer;

    public GameObject _player;
    public bool CanSeePlayer {  get; private set; } //maybe no cuadra con los parametros

    public LayerMask WhatIsPlayer;
    public LayerMask WhatIsVisible;
    //public float DetectionRange;
    //public float VisionAngle;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, _radius);

        Vector3 angle01 = DirectionFromAngle(-transform.eulerAngles.z, -_angle / 2);
        Vector3 angle02 = DirectionFromAngle(-transform.eulerAngles.z, _angle / 2);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * _radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * _radius);

        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _player.transform.position);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectPlayers().Length > 0) Debug.Log("Player detected");
    }

    private Transform[] DetectPlayers()
    {
        List<Transform> players = new List<Transform>();

        if (PlayerInRange(ref players))
        {
            if (PlayerInAngle(ref players))
            {
                PlayerIsVisible(ref players);
            }
        }

        return players.ToArray();
    }


    private bool PlayerInRange(ref List<Transform> players)
    {
        Collider2D[] playerColliders = Physics2D.OverlapCircleAll(transform.position, _radius, WhatIsPlayer);

        if (playerColliders.Length == 0)
        {
            return false;
        }

        foreach (var item in playerColliders)
        {
            players.Add(item.transform);
        }

        return true;
    }


    private bool PlayerInAngle(ref List<Transform> players)
    {
        for (int i = players.Count - 1; i >= 0; i--)
        {
            var angle = GetAngle(players[i]);

            if (angle > _angle / 2)
            {
                players.Remove(players[i]);
            }
        }

        return players.Count > 0;
    }

    private float GetAngle(Transform target)
    {
        Vector2 targetDir = target.position - transform.position;
        float angle = Vector2.Angle(targetDir, transform.right);

        return angle;
    }

    private bool PlayerIsVisible(ref List<Transform> players)
    {
        for (int i = players.Count - 1; i >= 0; i--)
        {
            var isVisible = IsVisible(players[i]);

            if (!isVisible)
            {
                players.Remove(players[i]);
            }
        }

        return (players.Count > 0);
    }

    private bool IsVisible(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(
           transform.position,
           dir,
           _radius,
           WhatIsVisible
        );

        return (hit.collider.transform == target);
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
