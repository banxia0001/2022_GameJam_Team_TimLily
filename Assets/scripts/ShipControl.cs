using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameObject Ship0, Ship1,flame0,flame1,airwalls;
    public Camera cam;
    public Rigidbody2D Rb0, Rb1;
    public Vector2 Ship0MoveVector, Ship1MoveVector,Ship0Pos,Ship1Pos;
    public float Sp0, Sp1,CamOrigin,CamZoomed;
    public bool haveControl,isMoving,iMTemp;
    public GameObject SmallMeteor;
    public Transform meteorLeftMax, meteorRightMax;
    //public 
    // Start is called before the first frame update
    void Start()
    {
        SmTM1 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);

    }

    // Update is called once per frame
    void Update()
    {
        MakeMeteor();
        isMoving = false;
        Ship0MoveVector = Vector2.zero;
        Ship1MoveVector = Vector2.zero;
        if (haveControl)
        {
            Ship0MoveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Ship1MoveVector = new Vector2(Input.GetAxis("hori1"), Input.GetAxis("verti1"));
            if(Ship0MoveVector!=Vector2.zero|| Ship1MoveVector != Vector2.zero)
            {
                isMoving = true;
            }
        }
        
        Ship0Pos = new Vector2(Ship0.transform.position.x, Ship0.transform.position.y);
       
        Ship1Pos = new Vector2(Ship1.transform.position.x, Ship1.transform.position.y);
        if (isMoving)
        {
            if (iMTemp != isMoving)
            {
                Debug.Log("Changing to moving view");
                if (t1 < 1)
                {
                    t1 = 1 - t1;
                }
                else
                {
                    t1 = 0;
                }
                iMTemp = isMoving;
            }
            t1 += Time.deltaTime * ZoomSp;
            cam.orthographicSize = Mathf.Lerp(CamOrigin, CamZoomed, t1);
            airwalls.transform.localScale = Vector3.one * Mathf.Lerp(1, CamZoomed / CamOrigin, t1);
        }
        else
        {
            if (iMTemp != isMoving)
            {
                Debug.Log("Changing to stop view");
                if (t1 < 1)
                {
                    t1 = 1 - t1;
                }
                else
                {
                    t1 = 0;
                }
                iMTemp = isMoving;
            }
            t1 += Time.deltaTime * UnzoomSp;
            cam.orthographicSize = Mathf.Lerp(CamZoomed, CamOrigin, t1);
            airwalls.transform.localScale = Vector3.one * Mathf.Lerp( CamZoomed / CamOrigin,1, t1);
        }
    }
    public float Smt1, Smt2,SmTM1,SmTM2,SmallMeteorSpawnMin, SmallMeteorSpawnMax;
    void MakeMeteor()
    {
        Smt1 += Time.deltaTime;
        Smt2 += Time.deltaTime;
        if (Smt1 >= SmTM1)
        {
            GameObject temp = Instantiate(SmallMeteor, Vector3.Lerp(meteorLeftMax.position, meteorRightMax.position, Random.Range(0f, 1f)), Quaternion.identity);
            SmTM1 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
            temp.GetComponent<Meteor>().xmin = meteorLeftMax.position.x;
            temp.GetComponent<Meteor>().xmax = meteorRightMax.position.x;
        }
        if (Smt2 >= SmTM2)
        {
            GameObject temp = Instantiate(SmallMeteor, Vector3.Lerp(meteorLeftMax.position, meteorRightMax.position, Random.Range(0f, 1f)), Quaternion.identity);
            SmTM2 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
            temp.GetComponent<Meteor>().xmin = meteorLeftMax.position.x;
            temp.GetComponent<Meteor>().xmax = meteorRightMax.position.x;
        }
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
    public float t1, CamSizeSwitchMaxTime,ZoomSp,UnzoomSp;
}
