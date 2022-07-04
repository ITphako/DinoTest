using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveTransition : Transition
{
    [SerializeField] private float _range = 200f;
    [SerializeField] private float _radius;
    [SerializeField] private List<Enemy> _enemyWithUs;
    [SerializeField] private GameObject _ray;
    [SerializeField] private MoveState _moveState;

    public override void Enable()
    {
        _enemyWithUs =  new List<Enemy>();
    }

    private void Update()
    {
        IsInView();
    }

    private void Died(Enemy enemy)
    {
        enemy.OnDied -= Died;
        _enemyWithUs.Remove(enemy);
        if (_enemyWithUs.Count == 0)
        {
            NeedTransit = true;
            _moveState.speed = 80;
        }
    }

    private void IsInView()
    {
        Vector3 ray = _ray.transform.position;
        Vector3 forward = _ray.transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(ray, _radius, forward, out hit, _range ))
            {
            if(hit.transform.TryGetComponent(out Enemy enemy))
            {
                if (!_enemyWithUs.Contains(enemy))
                {
                    _enemyWithUs.Add(enemy);
                    enemy.OnDied += Died;
                }
            }
        }
    }
    
}
