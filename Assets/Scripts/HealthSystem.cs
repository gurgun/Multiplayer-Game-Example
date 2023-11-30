using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    private int _health;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            OnHealthChanged?.Invoke();

        }
    }

    public Action OnHealthChanged;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject healthBarCanvas;
    private Camera _mainCam;

    private void Awake()
    {
        _mainCam = Camera.main;
        _health = maxHealth;
        
    }

    private void Start()
    {
        OnHealthChanged += HealthChanged;
    }

    private void HealthChanged()
    {
        Debug.Log("Health changed: " + Health);
        healthBar.fillAmount = Health / (float) maxHealth;
    }

    private void Update()
    {
        healthBarCanvas.transform.LookAt(_mainCam.transform);
    }
}
