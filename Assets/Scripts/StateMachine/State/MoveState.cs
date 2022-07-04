using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MoveState : State
{
    [SerializeField] private GameObject[] _moveSpots;
    private Animator _animator;
    private int _currentSpot = 0;
    private float _radius = 0.2f;
    public float speed;

    public event UnityAction OnPointChanged;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.CrossFade("Run", 0.1f);
    }

    private void OnDisable()
    {
        _animator.StartPlayback();
    }

    private void Update()
    {
        GetDistance();
        Move();
    }

    private void GetDistance()
    {
        if (Vector2.Distance(transform.position, _moveSpots[_currentSpot].transform.position) < _radius)
        {
            _currentSpot++;
            OnPointChanged.Invoke();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_currentSpot].transform.position, speed * Time.deltaTime);
    }
}