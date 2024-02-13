using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{   
    public List<GameObject> team1 = new List<GameObject>();
    public List<GameObject> team2 = new List<GameObject>();
    public Vector3 team1Spawn = new Vector3(0, 0, 0);
    public Vector3 team2Spawn = new Vector3(100, 0, 0);

    CombatManager combatManager;    

    void Start(){
        // add the combatants to the combat manager and spawn them in the world
        combatManager = new CombatManager();
        Debug.Log("Starting battle");
        for (int i = 0; i < team1.Count; i++)
        {
            Debug.Log("Adding combatant to team 1");
            Instantiate(team1[i], team1Spawn, Quaternion.identity);
            Combatant combatant = team1[i].GetComponent<Combatant>();
            //check if combatant is null
            if(combatant == null){
                Debug.LogError("Combatant is null");
            }
            
            combatant.position = team1Spawn;
            combatManager.AddCombatant(combatant, 1);
            //Debug.Log("Combatant added at position " + team1Spawn);
            
        }
        Debug.Log("Team 1 added");
        for (int i = 0; i < team2.Count; i++)
        {
            Instantiate(team2[i], team2Spawn, Quaternion.identity);
            Combatant combatant = team2[i].GetComponent<Combatant>();
            combatant.position = team2Spawn;
            combatManager.AddCombatant(combatant, 2);
            //Debug.Log("Combatant added at position " + team2Spawn);
            
        }
        Debug.Log("Team 2 added");
    }

    // Update is called once per frame
    void Update()
    {
        combatManager.Update();   
    }


}
