using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncingairwall : MonoBehaviour
{
    public Vector3 knockdir;
    public float knocksp;
    public GameObject explodeeffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("air wall knocked player");
            Instantiate( explodeeffect,c.contacts[0].point,Quaternion.identity);
            c.gameObject.GetComponent<ShipHit>().airwallknock(knockdir, knocksp);
        }
    }
}
