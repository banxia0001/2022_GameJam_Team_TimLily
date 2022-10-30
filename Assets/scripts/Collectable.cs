using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Transform Target;
    public Vector3 StartPos;
    public float MaxTime,t1;
    public int scoreamount;
    // Start is called before the first frame update
    void Start()
    {
        //MoveVector = (Target.position - transform.position).normalized;
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        t1 += Time.deltaTime;
        transform.position = Vector3.Lerp(StartPos, Target.position, t1 / MaxTime);
        if (t1 >= MaxTime)
        {
            GameObject.FindGameObjectWithTag("GM").GetComponent<ShipControl>().ScoreImput(scoreamount);
            Debug.Log("collected");
            Destroy(gameObject);
        }
    }
}
