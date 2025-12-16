using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript: MonoBehaviour
{
    [SerializeField] private float baseHealth;
    [SerializeField] private float currentHealth;

    [SerializeField] private Image fill;

    private IDamagable entity;


    private void Awake()
    {
        entity = GetComponentInParent<IDamagable>();
    }

    private void Update()
    {
        baseHealth = entity.GetBaseHealth();
        currentHealth = entity.GetCurrentHealth();

        fill.fillAmount = currentHealth / baseHealth;
    }
}
