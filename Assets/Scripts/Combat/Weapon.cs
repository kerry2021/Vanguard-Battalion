using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class keeps track of damage and attack cooldown, notifies the observer when weapon is ready to attack
public class Weapon : MonoBehaviour
{
    public float attackDamage; // Attack damage   
    public float armorPiercingRatio; // Armor piercing ratio (0 to 1, 0 = no armor piercing, 1 = full armor piercing)
    public float attackRange; // Attack range
    public float damageRadius; // Damage radius for area-of-effect attacks

    float attackCounter; // Attack cooldown counter
    public float attackCooldown; // Attack cooldown
    bool isAttacking; // Is the weapon currently attacking?

    public GameObject target; // Target to attack

    public List<IObserver<Weapon>> observers;
    
    void Awake()
    {
        attackCounter = 0;
        isAttacking = false;
        observers = new List<IObserver<Weapon>>();
    }

    void UpdateObservers(){
        foreach(IObserver<Weapon> observer in observers){
            observer.OnUpdated(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking){
            if(attackCounter > 0){
                attackCounter -= Time.deltaTime;
            }
            if(attackCounter <= 0){
                attackCounter = attackCooldown;
                UpdateObservers();
            }
        }
    }

    //Getters and setters
    public float AttackDamage
    {
        get { return attackDamage; }
        set
        {
            attackDamage = value;            
        }
    }

    public float AttackCooldown
    {
        get { return attackCooldown; }
        set
        {
            attackCooldown = value;            
        }
    }

    public float ArmorPiercingRatio
    {
        get { return armorPiercingRatio; }
        set
        {
            armorPiercingRatio = value;            
        }
    }

    public float AttackRange
    {
        get { return attackRange; }
        set
        {
            attackRange = value;            
        }
    }

    public float DamageRadius
    {
        get { return damageRadius; }
        set
        {
            damageRadius = value;            
        }
    }

    public bool IsAttacking
    {
        get { return isAttacking; }
        set
        {
            isAttacking = value;            
        }
    }

    public GameObject Target
    {
        get { return target; }
        set
        {
            target = value;            
        }
    }



}
