using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minusscoreobj : MonoBehaviour
{
    public int minusamount;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("GM").GetComponent<ShipControl>().score -= minusamount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
