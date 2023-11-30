using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
      
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private ParticleSystemManager particleSystemManager;
    public void Damage(int damageAmount)
    {
        healthSystem.Health -= damageAmount;
        particleSystemManager.Play();
    }
}
