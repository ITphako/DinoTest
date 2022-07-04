using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _filling;
    [SerializeField] private Enemy _health;

    private Camera _camera;

    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float value)
    {
        _filling.fillAmount = value;
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
