using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : BaseEntity
{
    [SerializeField] protected Sprite sprite;
    [SerializeField] protected float baseHealth;

    public float BaseHealth { get => baseHealth; set => baseHealth = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
}
