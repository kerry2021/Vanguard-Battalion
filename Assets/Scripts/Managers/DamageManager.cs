using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Apply weapons' damage to combatants and use LineRenderer to visualize the attack

public class DamageManager
{
    public List<GameObject> team1;
    public List<GameObject> team2;

    public DamageManager(List<GameObject> team1, List<GameObject> team2){
        this.team1 = team1;
        this.team2 = team2;
    }

    // Update is called once per frame
    public void Update()
    {
        for (int i = 0; i < team1.Count; i++)
        {            
            Weapon[] weapons = team1[i].GetComponents<Weapon>();
            for (int j = 0; j < weapons.Length; j++)
            {
                Weapon currentWeapon = weapons[j];
                if(currentWeapon.target != null){
                    //Apply damage to the target
                    CombatantStats targetStats = currentWeapon.target.GetComponent<CombatantStats>();
                    targetStats.health -= currentWeapon.attackDamage*(1-(targetStats.armor*(1-currentWeapon.armorPiercingRatio))/100);
                    Debug.Log("Target health: " + targetStats.health);
                    //Draw a line between the attacker and the target
                    DrawLine(team1[i].transform.position, currentWeapon.target.transform.position);
                }
            }
        }

        for (int i = 0; i < team2.Count; i++)
        {
            Weapon[] weapons = team2[i].GetComponents<Weapon>();
            for (int j = 0; j < weapons.Length; j++)
            {
                Weapon currentWeapon = weapons[j];
                if(currentWeapon.target != null){
                    //Apply damage to the target
                    CombatantStats targetStats = currentWeapon.target.GetComponent<CombatantStats>();
                    targetStats.health -= currentWeapon.attackDamage*(1-(targetStats.armor*(1-currentWeapon.armorPiercingRatio))/100);
                    //Draw a line between the attacker and the target
                    DrawLine(team2[i].transform.position, currentWeapon.target.transform.position);
                }
            }
        }
    }

    //Draws a line between two points
    public void DrawLine(Vector3 start, Vector3 end)
    {
        LineRenderer lineRenderer = new GameObject().AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
