using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHit : MonoBehaviour
{
    public GameObject HitResult;
    public ShipHit theOtherShip;
    public ShipControl sc;
    public Vector3 KnockBack;
    public float knockamount,knockmaxtime,t1;
    public bool isShip0;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        t1 += Time.deltaTime;
        if (KnockBack!=Vector3.zero)
        {
            transform.position += Vector3.Lerp(-KnockBack * knockamount, Vector2.zero,  t1 / knockmaxtime) * Time.deltaTime;
            sc.haveControl = false;
        }
        else
        {
            sc.haveControl = true;
        }
        if(t1>= knockmaxtime)
        {
            KnockBack = Vector3.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("ship hit hitted");
            if (isShip0)
            {
                Debug.Log("99");
                Instantiate(HitResult,Vector3.Lerp(transform.position,c.transform.position,0.5f), Quaternion.identity);
                Debug.Log("ship hit spawned");
            }
            //KnockBack = (new Vector2(c.collider.transform.position.x, c.collider.transform.position.y) - new Vector2(transform.position.x,transform.position.y)).normalized;
            KnockBack = (c.collider.transform.position-transform.position).normalized;
            //rb.AddForce(-KnockBack * knockamount, ForceMode2D.Impulse);
            t1 = 0;
            theOtherShip.CallKnock(transform);
            
        }
    }
    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            t1 = 0;
            Invoke("StopKnock", knockmaxtime);
        }
    }
    public void CallKnock(Transform cc)
    {
        if (isShip0)
        {
            Debug.Log("99");
            Instantiate(HitResult, Vector3.Lerp(transform.position, cc.transform.position, 0.5f), Quaternion.identity);
            Debug.Log("ship hit spawned");
        }
        //KnockBack = (new Vector2(cc.position.x, cc.position.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
        t1 = 0;
        KnockBack = (cc.position-transform.position).normalized;
       
        //rb.AddForce(-KnockBack * knockamount, ForceMode2D.Impulse);
       //Invoke("StopKnock", knockmaxtime);
    }
    void StopKnock()
    {
        KnockBack = Vector2.zero;
        rb.velocity = Vector2.zero;
        Debug.Log("stoped");
    }
}
