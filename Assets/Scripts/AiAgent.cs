using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _player;

    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private int _index;
    void Update()
    {
        MoveToPoint(_waypoints[_index].position);

        if (Vector2.Distance(transform.position, _waypoints[_index].position)<1)
        {
            _index = (_index+1)%(_waypoints.Length);
        }
        //MoveToPoint(_player.transform.position);
    }
    void MoveToPoint(Vector2 target)
    {
        Vector2 directionToPlayer = target - (Vector2)transform.position;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= _speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
}
