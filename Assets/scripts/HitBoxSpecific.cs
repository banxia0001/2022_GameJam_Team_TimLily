using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxSpecific : MonoBehaviour
{
    public GameObject S0, S1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(objs.Length);
        if (objs.Length != 0)
        {
            S0 = objs[0];
            S1 = objs[1];
            Debug.Log("Both Ship Found");
        }
        else
        {
            Debug.Log("[Error] No Ship Found from HitBoxSpecific");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Meteor")
        {
            c.GetComponent<Meteor>().GetHit(S0.transform,S1.transform);
        }
    }
}
