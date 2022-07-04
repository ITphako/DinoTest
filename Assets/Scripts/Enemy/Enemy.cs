using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public event UnityAction<Enemy> OnDied;
    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0f)
        {
            Die();
        }
        else
        {
            float currentHelth = _currentHealth / _maxHealth;
            HealthChanged.Invoke(currentHelth);
        }
    }

   public void Die()
    {
        Destroy(gameObject);
        OnDied.Invoke(this);
    }
}
