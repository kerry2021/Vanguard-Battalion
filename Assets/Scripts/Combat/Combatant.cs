using UnityEngine;
using System.Collections.Generic;

public class Combatant : MonoBehaviour
{
    // Attributes
    public float health; // Health points (HP)
    public float armor; // Armor points
    public float attackDamage; // Attack damage
    public float attackCooldown;
    public float attackTimer;
    public bool attackEnable; //whether this unit started attacking, timer does not start until this is true
    public float armorPiercingRatio; // Armor piercing ratio (0 to 1, 0 = no armor piercing, 1 = full armor piercing)
    public float attackRange; // Attack range
    public float damageRadius; // Damage radius for area-of-effect attacks
    public float movementSpeed; // Movement speed

    public Vector3 position; // Position in the game world

    private List<ICombatantObserver> observers;

    // Constructor
    public Combatant(float initialHealth, float initialArmor, float initialAttackDamage, float initialAttackCooldown,
                     float initialArmorPiercingRatio, float initialAttackRange, float initialDamageRadius,
                     float initialMovementSpeed, Vector3 initialPosition)
    {
        health = initialHealth;
        armor = initialArmor;
        attackDamage = initialAttackDamage;
        attackCooldown = initialAttackCooldown;
        armorPiercingRatio = initialArmorPiercingRatio;
        attackRange = initialAttackRange;
        damageRadius = initialDamageRadius;
        movementSpeed = initialMovementSpeed;
        attackTimer = 0;
        attackEnable = false;
        position = initialPosition;
        observers = new List<ICombatantObserver>();
    }

    // Methods

    // Method to attach an observer
    public void AttachObserver(ICombatantObserver observer)
    {
        //check if oberservers and observer are null
        if(observers == null){
            observers = new List<ICombatantObserver>();            
        }
        observers.Add(observer);
        Debug.Log("Attaching observer");
    }

    // Method to detach an observer
    public void DetachObserver(ICombatantObserver observer)
    {
        observers.Remove(observer);
    }

    // Method to notify observers when an attack is ready
    private void NotifyAttackReady()
    {       
        if (observers != null){       
            Debug.Log("Notifying observers"); 
            foreach (var observer in observers)
            {
                observer.OnAttackReady(this);
            }
        }
    }
    public void TakeDamage(float damage, float armorPiercingRatio)
    {
        // Reduce health by accounting for armor and armor piercing
        float damageTaken = damage * (1 - armor*(1-armorPiercingRatio) / 100f);
        health -= damageTaken;
    }

    public void Update()
    {   
        if(attackEnable){
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                NotifyAttackReady();
                attackTimer = 0f;
            }
        }
    }

    public void Attack(Combatant target)
    {
        // Perform attack logic here
    }

    public void Move(Vector3 targetPosition)
    {
        Debug.Log("Moving to " + targetPosition);
        // move towards the target's x position with y and z remaining the same
        position = Vector3.MoveTowards(position, new Vector3(targetPosition.x, position.y, position.z), movementSpeed * Time.deltaTime);

        //if difference in y position is greater than range, move towards the target's y position
        if(Mathf.Abs(position.y - targetPosition.y) > attackRange){
            position = Vector3.MoveTowards(position, new Vector3(position.x, targetPosition.y, position.z), movementSpeed * Time.deltaTime);
        }

        Debug.Log("Moving to " + position);
    }
}