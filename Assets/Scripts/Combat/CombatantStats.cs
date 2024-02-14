using UnityEngine;
using System.Collections.Generic;

//This class act as a single source of truth for the combatant stats

public class CombatantStats : MonoBehaviour
{
    // Attributes
    float health; // Health points (HP)
    float armor; // Armor points
    float attackDamage; // Attack damage
    float attackCooldown;
    float armorPiercingRatio; // Armor piercing ratio (0 to 1, 0 = no armor piercing, 1 = full armor piercing)
    float attackRange; // Attack range
    float damageRadius; // Damage radius for area-of-effect attacks
    float movementSpeed; // Movement speed    

    public List<IObserver<CombatantStats>> observers;
    

    // Constructor
    CombatantStats (float initialHealth, float initialArmor, float initialAttackDamage, float initialAttackCooldown,
                     float initialArmorPiercingRatio, float initialAttackRange, float initialDamageRadius,
                     float initialMovementSpeed)
    {
        health = initialHealth;
        armor = initialArmor;
        attackDamage = initialAttackDamage;
        attackCooldown = initialAttackCooldown;
        armorPiercingRatio = initialArmorPiercingRatio;
        attackRange = initialAttackRange;
        damageRadius = initialDamageRadius;
        movementSpeed = initialMovementSpeed;        
        observers = new List<IObserver<CombatantStats>>();
    }

    void Awake()
    {
        observers = new List<IObserver<CombatantStats>>();
    }

    //when the combatant is updated, notify the observers
    public void OnUpdated()
    {
        foreach (var observer in observers)
        {
            observer.OnUpdated(this);
        }
    }

    // Getters and setters
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            OnUpdated();
        }
    }

    public float Armor
    {
        get { return armor; }
        set
        {
            armor = value;
            OnUpdated();
        }
    }

    public float AttackDamage
    {
        get { return attackDamage; }
        set
        {
            attackDamage = value;
            OnUpdated();
        }
    }

    public float AttackCooldown
    {
        get { return attackCooldown; }
        set
        {
            attackCooldown = value;
            OnUpdated();
        }
    }

    public float ArmorPiercingRatio
    {
        get { return armorPiercingRatio; }
        set
        {
            armorPiercingRatio = value;
            OnUpdated();
        }
    }

    public float AttackRange
    {
        get { return attackRange; }
        set
        {
            attackRange = value;
            OnUpdated();
        }
    }

    public float DamageRadius
    {
        get { return damageRadius; }
        set
        {
            damageRadius = value;
            OnUpdated();
        }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set
        {
            movementSpeed = value;
            OnUpdated();
        }
    }



}