using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;
    private float _startTime = 0;

    private void Update()
    {
        DestroyBullet();
         _startTime += Time.deltaTime;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

    private void DestroyBullet()
    {
        if (_startTime > _timeLife)
        {
            Destroy(gameObject);
        }
    }
}
