using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyVisionRange : MonoBehaviour
{
    public float _radius = 5f;
    [Range(1, 360)]
    public float _angle = 45f;

    public LayerMask _targetLayer;
    public LayerMask _obstructionLayer;

    public GameObject _playerRef;
    public bool CanSeePlayer {  get; private set; } //maybe no cuadra con los parametros


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, _radius);

        Vector3 angle01 = DirectionFromAngle(-transform.eulerAngles.z, -_angle / 2);
        Vector3 angle02 = DirectionFromAngle(-transform.eulerAngles.z, _angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * _radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * _radius);

        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _playerRef.transform.position);
        }
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
