using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be used to keep track of the attack cooldown of a combatant
public class AttackCounter : MonoBehaviour, IObserver<CombatantStats>
{
    public float attackCounter;
    public float attackCooldown;
    //The scripts handling attacking will observe this script
    public List<IObserver<int>> observers;    

    AttackCounter(){
        observers = new List<IObserver<int>>();
        attackCounter = 0;
    }

    //if some other scripts make changes to the attack cooldown, this method will be called
    public void OnUpdated(CombatantStats combatantStats){
        attackCooldown = combatantStats.AttackCooldown;
    }

    void UpdateObservers(){
        foreach(IObserver<int> observer in observers){
            observer.OnUpdated(0);
        }
    }

    void Awake(){
        observers = new List<IObserver<int>>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCounter > 0){
            attackCounter -= Time.deltaTime;
        }
        if(attackCounter <= 0){
            attackCounter = attackCooldown;
            UpdateObservers();
        }        
    }
}
