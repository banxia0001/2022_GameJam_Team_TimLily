using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject CollectableRocks;
    public Vector3 MoveVector;
    public float Sp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += MoveVector * Time.deltaTime * Sp;
    }
    public void GetHit(Transform sp0,Transform sp1)
    {
        GameObject temp = Instantiate(CollectableRocks, transform.position, Quaternion.identity);
        if (Vector3.Distance(transform.position,sp0.position)>= Vector3.Distance(transform.position, sp1.position))
        {
            temp.GetComponent<Collectable>().Target = sp1;
        }
        else
        {
            temp.GetComponent<Collectable>().Target = sp0;
        }
        
        Debug.Log("Meteor Destroyed");
        Destroy(gameObject);
    }
}
