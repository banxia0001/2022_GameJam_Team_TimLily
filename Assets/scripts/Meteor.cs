using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject CollectableRocks,explodeeffect;
    public Vector3 MoveVector;
    public float Sp,xmin,xmax,turnmin,turnmax;
    public bool isType2;
    public int lootamount;
    // Start is called before the first frame update
    void Start()
    {
        if (lootamount < 1)
        {
            lootamount = 1;
        }
        //Quaternion
        //max for left, min for right
        if (!isType2)
        {
            Vector3 temp = Vector3.forward * Mathf.Lerp(turnmax, turnmin, transform.position.x / (xmax - xmin)) + Vector3.forward * Random.Range(turnmax, turnmin);
            if (transform.position.x > 0 && temp.z > 0)
            {
                temp.z *= -1;
            }
            else if (transform.position.x < 0 && temp.z < 0)
            {
                temp.z *= -1;
            }
            transform.rotation = Quaternion.Euler(temp);
            transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.forward*Random.Range(0f,360f));
            transform.localScale = Vector3.one * Random.Range(1.2f, 1.9f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isType2)
        {
            transform.position += -transform.up * Time.deltaTime * Sp;
        }
        else
        {
            transform.position += -Vector3.up * Time.deltaTime * Sp;
        }
        
    }
    public void GetHit(Transform sp0,Transform sp1)
    {
        for(int i=0;i< lootamount; i++)
        {
            GameObject temp = Instantiate(CollectableRocks, transform.position, Quaternion.identity);
            if (Vector3.Distance(transform.position, sp0.position) >= Vector3.Distance(transform.position, sp1.position))
            {
                temp.GetComponent<Collectable>().Target = sp1;
            }
            else
            {
                temp.GetComponent<Collectable>().Target = sp0;
            }

        }


        Debug.Log("Meteor Destroyed");
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            //GameObject.FindGameObjectWithTag("GM").GetComponent<ShipControl>().Cam.SetTrigger("T2");
            Instantiate(explodeeffect, c.contacts[0].point, Quaternion.identity);
        }
    }
}
