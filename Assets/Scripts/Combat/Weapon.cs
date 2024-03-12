using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class keeps track of damage and attack cooldown, notifies the observer when weapon is ready to attack
public class Weapon: MonoBehaviour
{
    public float attackDamage; // Attack damage   
    public float armorPiercingRatio; // Armor piercing ratio (0 to 1, 0 = no armor piercing, 1 = full armor piercing)
    public float attackRange; // Attack range
    public float damageRadius; // Damage radius for area-of-effect attacks

    public float attackCounter; // Attack cooldown counter
    public float attackCooldown; // Attack cooldown
    public bool isAttacking; // Is the weapon currently attacking?

    public bool active; // Is the weapon active?

    public GameObject target; // Target to attack

    public GameObject owner; // Owner of the weapon

    private List<IObserver<Weapon>> observers;
    
    void Awake()
    {
        Debug.Log("Weapon initialized");
        //Debug.Log("Object hash in Weapon" + this.GetHashCode());
        attackCounter = 0;
        isAttacking = false;
        //observers = new List<IObserver<Weapon>>();
    }

    void UpdateObservers(){
        Debug.Log("Object hash in UpdateObservers" + this.GetHashCode());
        Debug.Log("Observers count: " + observers.Count);
        foreach(IObserver<Weapon> observer in observers){
            observer.OnUpdated(this);
        }
    }
    
    public void Update()
    {
        //enable attacking if the weapon is in range and has a target, disable otherwise
        if(active && target != null && Vector3.Distance(owner.transform.position, target.transform.position) <= attackRange){
            isAttacking = true;
        }else{
            isAttacking = false;
        }   
        
        if(isAttacking){
            if(attackCounter > 0){
                attackCounter -= Time.deltaTime;
            }
            if(attackCounter <= 0){
                Debug.Log("Weapon is ready to attack");
                attackCounter = attackCooldown;
                UpdateObservers();
            }
        }
    }

    public void AddObserver(IObserver<Weapon> observer){
        if (observers == null)
        {
            observers = new List<IObserver<Weapon>>();
        }
        observers.Add(observer);
        Debug.Log("Object hash in AddObserver" + this.GetHashCode());
        Debug.Log("Observer added, count: " + observers.Count);
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
