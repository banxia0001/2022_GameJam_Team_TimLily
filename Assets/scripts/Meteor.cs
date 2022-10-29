using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject CollectableRocks;
    public Vector3 MoveVector;
    public float Sp,xmin,xmax,turnmin,turnmax;
    // Start is called before the first frame update
    void Start()
    {
        //Quaternion
        //max for left, min for right
        Vector3 temp = Vector3.forward * Mathf.Lerp( turnmax, turnmin, transform.position.x / (xmax - xmin))+Vector3.forward*Random.Range(turnmax,turnmin);
        if (transform.position.x > 0 && temp.z > 0)
        {
            temp.z *= -1;
        }else if(transform.position.x < 0 && temp.z < 0)
        {
            temp.z *= -1;
        }
        transform.rotation = Quaternion.Euler(temp);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * Sp;
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
