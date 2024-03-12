using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Apply weapons' damage to combatants and use LineRenderer to visualize the attack

public class DamageManager: IObserver<Weapon>
{
    public List<GameObject> team1;
    public List<GameObject> team2;

    public DamageManager(List<GameObject> team1, List<GameObject> team2){
        this.team1 = team1;
        this.team2 = team2;
    }

    
    public void AddObservers()
    {
        for (int i = 0; i < team1.Count; i++)
        {            
            Weapon[] weapons = team1[i].GetComponents<Weapon>();
            for (int j = 0; j < weapons.Length; j++)
            {
                Weapon currentWeapon = weapons[j];

                Debug.Log("Adding observer");
                currentWeapon.AddObserver(this);                
                
            }
        }

        for (int i = 0; i < team2.Count; i++)
        {
            Weapon[] weapons = team2[i].GetComponents<Weapon>();
            for (int j = 0; j < weapons.Length; j++)
            {
                Weapon currentWeapon = weapons[j];                
                //currentWeapon.observers.Add(this);
                
            }
        }
    }

    public void OnUpdated(Weapon weapon)
    {
        //check that the weapon has a target and it is in range
        if(weapon.target != null && Vector3.Distance(weapon.owner.transform.position, weapon.target.transform.position) <= weapon.attackRange){
            CombatantStats targetStats = weapon.target.GetComponent<CombatantStats>();
            if(targetStats != null){
                Debug.Log("Dealing damage to " + targetStats.id);
                targetStats.Health -= weapon.attackDamage;
                DrawLine(weapon.owner.transform.position, weapon.target.transform.position);
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
