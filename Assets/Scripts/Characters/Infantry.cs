using UnityEngine;

public class Infantry : MonoBehaviour
{
    public Combatant combatant;

    void Start()
    {
        combatant = new Combatant(100, 0, 20, 2, 0, 2, 0, 5, transform.position);
    }
}