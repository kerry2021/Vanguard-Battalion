using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regiment : MonoBehaviour
{
    public int morale;
    public float speed;
    public Dictionary<string, int> companies;

    void Start()
    {
        companies = new Dictionary<string, int>();
    }

    void Update()
    {
        // Update regiment behavior
    }
}