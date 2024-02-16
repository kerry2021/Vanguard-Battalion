using UnityEngine;
using System.Collections.Generic;

//This class act as a single source of truth for the combatant stats

public class CombatantStats : MonoBehaviour
{
    // Attributes
    public float health; // Health points (HP)
    public float armor; // Armor points
    public float movementSpeed; // Movement speed    

    public bool isFriendly; // Is the combatant friendly to the player?

    public List<IObserver<CombatantStats>> observers;
    

    // Constructor
    CombatantStats (float initialHealth, float initialArmor, float initialMovementSpeed, bool isFriendly)
    {
        health = initialHealth;
        armor = initialArmor;
        movementSpeed = initialMovementSpeed;
        this.isFriendly = isFriendly;
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