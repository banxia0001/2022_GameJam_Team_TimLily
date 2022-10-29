using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameObject Ship0, Ship1,flame0,flame1;
    public Rigidbody2D Rb0, Rb1;
    public Vector2 Ship0MoveVector, Ship1MoveVector,Ship0Pos,Ship1Pos;
    public float Sp0, Sp1,CamOrigin,CamZoomed;
    //public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ship0MoveVector = Vector2.zero;
        Ship1MoveVector = Vector2.zero;
        Ship0MoveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Ship0Pos = new Vector2(Ship0.transform.position.x, Ship0.transform.position.y);
        Ship1MoveVector = new Vector2(Input.GetAxis("hori1"), Input.GetAxis("verti1"));
        Ship1Pos = new Vector2(Ship1.transform.position.x, Ship1.transform.position.y);
    }
    private void FixedUpdate()
    {
       
        if (Ship0MoveVector != Vector2.zero)
        {
            Rb0.MovePosition(Ship0Pos + Ship0MoveVector * Time.deltaTime * Sp0);
            flame0.SetActive(true);
        }
        else
        {
            //Rb0.velocity = Vector2.zero;
            flame0.SetActive(false);
        }
        if (Ship1MoveVector != Vector2.zero)
        {
            Rb1.MovePosition(Ship1Pos + Ship1MoveVector * Time.deltaTime * Sp1);
            flame1.SetActive(true);
        }
        else
        {
            //Rb1.velocity = Vector2.zero;
            flame1.SetActive(false);
        }
    }
}
