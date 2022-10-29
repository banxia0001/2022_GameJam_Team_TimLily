using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float DTime,t1;
    // Start is called before the first frame update
    void Start()
    {
        t1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t1 += Time.deltaTime;
        if (t1 >= DTime)
        {
            Destroy(gameObject);
            Debug.Log("gameobject destroyed by self D");
        }
    }
}
