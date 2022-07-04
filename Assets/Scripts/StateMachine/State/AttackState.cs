using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private  GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 15;
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.StopPlayback();
        _animator.CrossFade("Idle", 0.1f);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        }
    }
}
