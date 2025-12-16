using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity: ScriptableObject
{
    [SerializeField] protected int entityId;
    [SerializeField] protected string entityName;
    [SerializeField] protected string description;

    public string Name { get => entityName; set => entityName = value; }
    public string Description { get => description; set => description = value; }
    public int Id { get => entityId; set => entityId = value; }

}
