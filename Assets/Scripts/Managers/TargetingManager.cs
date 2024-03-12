using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the targeting of weapons based on combatant stats and positions in the scene

public class TargetingManager
{
    public List<GameObject> team1;
    public List<GameObject> team2;

    public TargetingManager(List<GameObject> team1, List<GameObject> team2){
        this.team1 = team1;
        this.team2 = team2;
    }

    // Update is called once per frame
    public void Update()
    {
        //for each combatant in team1, get all of its weapons
        for (int i = 0; i < team1.Count; i++)
        {
            Weapon[] weapons = team1[i].GetComponents<Weapon>();
            //for each weapon, get the closest combatant in team2
            for (int j = 0; j < weapons.Length; j++)
            {                
                GameObject target = GetClosestCombatant(team2, team1[i].transform.position);
                weapons[j].target = target;
                Debug.Log("Targeting " + target.GetComponent<CombatantStats>().id);
            }
        }

        //for each combatant in team2, get all of its weapons
        for (int i = 0; i < team2.Count; i++)
        {
            Weapon[] weapons = team2[i].GetComponents<Weapon>();
            //for each weapon, get the closest combatant in team1
            for (int j = 0; j < weapons.Length; j++)
            {
                GameObject target = GetClosestCombatant(team1, team2[i].transform.position);
                weapons[j].target = target;
            }
        }


    }

    //returns the closest combatant to the given position
    public GameObject GetClosestCombatant(List<GameObject> combatants, Vector3 position)
    {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < combatants.Count; i++)
        {
            float distance = Vector3.Distance(combatants[i].transform.position, position);
            if (distance < closestDistance)
            {
                closest = combatants[i];
                closestDistance = distance;
            }
        }
        return closest;
    }
}
