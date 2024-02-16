using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{   
    public List<GameObject> team1 = new List<GameObject>();
    public List<GameObject> team2 = new List<GameObject>();
    public Vector3 team1Spawn = new Vector3(0, 0, 0);
    public Vector3 team2Spawn = new Vector3(100, 0, 0);
     

    void Start(){           
        Debug.Log("Starting battle");
        for (int i = 0; i < team1.Count; i++)
        {            
            Instantiate(team1[i], team1Spawn, Quaternion.identity);
            CombatantStats combatantStats = team1[i].GetComponent<CombatantStats>();
            Weapon weapon = team1[i].GetComponent<Weapon>();
            
            //Add AttackCounter to observe the combatant
            //check that observers is not null
            if(combatantStats.observers == null){
                Debug.Log("Observers is null");
                combatantStats.observers = new List<IObserver<CombatantStats>>();
            }

        }
        Debug.Log("Team 1 added");
        for (int i = 0; i < team2.Count; i++)
        {
            Instantiate(team2[i], team2Spawn, Quaternion.identity);                       
        }
        Debug.Log("Team 2 added");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
