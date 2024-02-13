using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : ICombatantObserver
{
    private List<Combatant> team1;
    private List<Combatant> team2;

    public CombatManager(){
        team1 = new List<Combatant>();
        team2 = new List<Combatant>();
    }

    public void AddCombatant(Combatant combatant, int team){
        if(team == 1){
            team1.Add(combatant);
            Debug.Log("Adding combatant to team 1 at position " + combatant.position);
        }
        else if(team == 2){
            team2.Add(combatant);
            Debug.Log("Adding combatant to team 2 at position " + combatant.position);
        }
        //check if combatant is null
        Debug.Log(combatant.health);
        if(combatant == null || this == null){
            Debug.LogError("Combatant or this is null");
        }
        combatant.AttachObserver(this);
    }
    

    // Update is called once per frame
    public void Update()
    {             
        
        //check if any combatants are in range of an enemy, if so, enable attack, otherwise disable attack and move towards the closest enemy
        foreach(Combatant combatant in team1){
            Debug.Log("Checking team 1");
            if(enemyInRange(combatant, team2)){
                combatant.attackEnable = true;
                Debug.Log("Enemy in range");
            }
            else{
                combatant.attackEnable = false;
                Combatant closestEnemy = findClosestEnemy(combatant, team2);
                combatant.Move(closestEnemy.position);
            }
        }
        foreach(Combatant combatant in team2){
            if(enemyInRange(combatant, team1)){
                combatant.attackEnable = true;
            }
            else{
                combatant.attackEnable = false;
                Combatant closestEnemy = findClosestEnemy(combatant, team2);
                combatant.Move(closestEnemy.position);
            }
        }
    }

    //Combatant notifies the manager when it is ready to attack, then the manager will find the closest enemy and deal damage
    public void OnAttackReady(Combatant combatant){
        if(combatant.attackEnable){
            List<Combatant> enemyTeam = new List<Combatant>();
            if(team1.Contains(combatant)){
                enemyTeam = team2;
            }
            else{
                enemyTeam = team1;
            }
            Combatant closestEnemy = findClosestEnemy(combatant, enemyTeam);
            closestEnemy.TakeDamage(combatant.attackDamage, combatant.armorPiercingRatio);
        }

    }

    //helper function to see if any enemies are in range
    private bool enemyInRange(Combatant attacker, List<Combatant> team){
        foreach(Combatant combatant in team){
            if(Vector3.Distance(attacker.position, combatant.position) <= attacker.attackRange){
                return true;
            }
        }
        return false;
    }

    //helper function to find closest enemy
    private Combatant findClosestEnemy(Combatant attacker, List<Combatant> team){
        Combatant closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        foreach(Combatant combatant in team){
            float distance = Vector3.Distance(attacker.position, combatant.position);
            if(distance < closestDistance){
                closestDistance = distance;
                closestEnemy = combatant;
            }
        }
        return closestEnemy;
    }
}
