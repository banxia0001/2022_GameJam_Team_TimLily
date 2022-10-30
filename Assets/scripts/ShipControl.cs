using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{
    public GameObject Ship0, Ship1,flame0,flame1,airwalls;
    public Camera cam;
    public Rigidbody2D Rb0, Rb1;
    public Vector2 Ship0MoveVector, Ship1MoveVector,Ship0Pos,Ship1Pos;
    public float LevelMaxTime, Sp0, Sp1,CamOrigin,CamZoomed, maxtime,altofallsp;
    public bool haveControl,isMoving,iMTemp;
    public GameObject SmallMeteor,Meteor2;
    public Transform meteorLeftMax, meteorRightMax;
    public int score;
    public TextMeshProUGUI scoredisplay, timerdisplay;
    //public float Speed0, Speed1;
    public float HoriTurnMin, HoriTurnMax,maxdistance;
    //public 
    // Start is called before the first frame update
    void Start()
    {
        SmTM1 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
        SmTM2 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);

        Ship0Pos = new Vector2(Ship0.transform.position.x, Ship0.transform.position.y);
        Ship1Pos = new Vector2(Ship1.transform.position.x, Ship1.transform.position.y);
        smtm3 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
        smtm4 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
        //cam size is dependent on distance between two ship
        //distance 4.8 = cam size 3.8, cam pos x max 4.3, y max 7.44
        //distance 17.6 = cam size 8, cam pos = 0 0 0
        //dx = d-4.8 / 17.6-4.8
        //cam size lerp 3.8, 8, dx
        //cam pos y lerp 4.3, 0, dx
        //cam pos x lerp 7.44, 0, dx
        maxdistance = 17.6f - 4.8f;
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion
        t1 += Time.deltaTime;
        if((LevelMaxTime - t1) <= 0)
        {

        }
        MakeMeteor();
        MakeMeteor_BackGround();
        setdisplay();
        camscaler();
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

        //Rb0.AddForce(Ship0MoveVector * Speed0);
        //Rb1.AddForce(Ship1MoveVector * Speed1);
        Ship0Pos = new Vector2(Ship0.transform.position.x, Ship0.transform.position.y);
        Ship1Pos = new Vector2(Ship1.transform.position.x, Ship1.transform.position.y);

        if (Ship0MoveVector.y<=0)
        {
            Ship0Pos += Vector2.down * altofallsp * Time.deltaTime;
        }
        if(Ship1MoveVector.y <= 0)
        {
            Ship1Pos += Vector2.down * altofallsp * Time.deltaTime;
        }

            //if (isMoving)
            //{
            //    if (iMTemp != isMoving)
            //    {
            //        Debug.Log("Changing to moving view");
            //        if (t1 < 1)
            //        {
            //            t1 = 1 - t1;
            //        }
            //        else
            //        {
            //            t1 = 0;
            //        }
            //        iMTemp = isMoving;
            //    }
            //t1 += Time.deltaTime * ZoomSp;

            //cam.orthographicSize = Mathf.Lerp(CamOrigin, CamZoomed, t1);
            //airwalls.transform.localScale = Vector3.one * Mathf.Lerp(1, CamZoomed / CamOrigin, t1);
            //Quaternion

            //}
            //else
            //{
            //    if (iMTemp != isMoving)
            //    {
            //        Debug.Log("Changing to stop view");
            //        if (t1 < 1)
            //        {
            //            t1 = 1 - t1;
            //        }
            //        else
            //        {
            //            t1 = 0;
            //        }
            //        iMTemp = isMoving;
            //    }
            //    t1 += Time.deltaTime * UnzoomSp;
            //    //cam.orthographicSize = Mathf.Lerp(CamZoomed, CamOrigin, t1);
            //    //airwalls.transform.localScale = Vector3.one * Mathf.Lerp( CamZoomed / CamOrigin,1, t1);
            //}
    }
    void setdisplay()
    {
        scoredisplay.text = score.ToString();
        timerdisplay.text = (LevelMaxTime- t1).ToString("0.00");
    }
    void camscaler()
    {
        float tempx = Vector3.Distance(Ship0.transform.position, Ship1.transform.position);
        if (tempx < 4.8f)
        {
            tempx = 4.8f;
        }
        else if (tempx > 17.6f)
        {
            tempx = 17.6f;
        }
        float dx = (tempx - 4.8f) / maxdistance;
        //cam size lerp 3.8, 8, dx
        //cam field lerp 38, 73, dx
        //cam pos y lerp 4.3, 0, dx
        //cam pos x lerp 7.44, 0, dx
        //cam.orthographicSize = Mathf.Lerp(3.8f, 8f, dx);
        cam.fieldOfView = Mathf.Lerp(38, 73, dx);
        float camposy = Mathf.Clamp(Mathf.Lerp(Ship0.transform.position.y,Ship1.transform.position.y, 0.5f), -Mathf.Lerp(4.3f, 0f, dx), Mathf.Lerp(4.3f, 0f, dx));
        float camposx = Mathf.Clamp(Mathf.Lerp(Ship0.transform.position.x, Ship1.transform.position.x, 0.5f), -Mathf.Lerp(7.48f, 0f, dx), Mathf.Lerp(7.44f, 0f, dx));
        cam.transform.position = new Vector3(camposx, camposy, cam.transform.position.z);
        airwalls.transform.position = cam.transform.position;
        airwalls.transform.localScale = Vector3.one*Mathf.Lerp(0.6878871f, 1.548818f, dx);
    }
    public float Smt1, Smt2,smt3,smt4,SmTM1,SmTM2,smtm3,smtm4,SmallMeteorSpawnMin, SmallMeteorSpawnMax;
    void MakeMeteor()
    {
        Smt1 += Time.deltaTime;
        Smt2 += Time.deltaTime;
        smt3 += Time.deltaTime;
        smt4 += Time.deltaTime;
        if (Smt1 >= SmTM1)
        {
            Smt1 = 0;
            GameObject temp = Instantiate(SmallMeteor, Vector3.Lerp(meteorLeftMax.position, meteorRightMax.position, Random.Range(0f, 1f)), Quaternion.identity);
            SmTM1 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
            temp.GetComponent<Meteor>().xmin = meteorLeftMax.position.x;
            temp.GetComponent<Meteor>().xmax = meteorRightMax.position.x;
        }
        if (Smt2 >= SmTM2)
        {
            Smt2 = 0;
            GameObject temp = Instantiate(SmallMeteor, Vector3.Lerp(meteorLeftMax.position, meteorRightMax.position, Random.Range(0f, 1f)), Quaternion.identity);
            SmTM2 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
            temp.GetComponent<Meteor>().xmin = meteorLeftMax.position.x;
            temp.GetComponent<Meteor>().xmax = meteorRightMax.position.x;
        }
        if (smt3 >= smtm3)
        {
            smt3 = 0;
            GameObject temp = Instantiate(Meteor2, Vector3.Lerp(meteorLeftMax.position, meteorRightMax.position, Random.Range(0f, 1f)), Quaternion.identity);
            smtm3 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
            temp.GetComponent<Meteor>().xmin = meteorLeftMax.position.x;
            temp.GetComponent<Meteor>().xmax = meteorRightMax.position.x;
        }
        if (smt4 >= smtm4)
        {
            smt4 = 0;
            GameObject temp = Instantiate(Meteor2, Vector3.Lerp(meteorLeftMax.position, meteorRightMax.position, Random.Range(0f, 1f)), Quaternion.identity);
            smtm4 = Random.Range(SmallMeteorSpawnMin, SmallMeteorSpawnMax);
            temp.GetComponent<Meteor>().xmin = meteorLeftMax.position.x;
            temp.GetComponent<Meteor>().xmax = meteorRightMax.position.x;
        }
    }

    private float geneTime;
    public GameObject[] backMeteors;
    
    void MakeMeteor_BackGround()
    {
        geneTime += Time.deltaTime;
        if (geneTime > .2f)
        {
            geneTime = 0;
            int geneNum = Random.Range(0, 3);

            for (int i = 0; i < geneNum; i++)
            {
                GameObject temp = Instantiate(backMeteors[Random.Range(0, backMeteors.Length)], Vector3.Lerp(meteorLeftMax.position, meteorRightMax.position, Random.Range(0f, 1f)) + new Vector3(0,3f,0), Quaternion.identity);
            }

        }
    }


    public Vector3 ship0turntemp,ship1turntemp;
    public float t2, t3, ship0recorded, ship1recorded;
    private void FixedUpdate()
    {

        if (Ship0MoveVector != Vector2.zero)
        {
            Rb0.MovePosition(Ship0Pos + Ship0MoveVector * Time.deltaTime * Sp0);
            //flame0.SetActive(true);
            t2 += Time.fixedDeltaTime;
            if (Ship0MoveVector.x > 0)
            {
                if (ship0recorded <= 0)
                {
                    t2 = 0;
                    ship0recorded = Ship0MoveVector.x;
                    ship0turntemp = Ship0.transform.rotation.eulerAngles;
                }
                Ship0.transform.rotation = Quaternion.Lerp(Quaternion.Euler(ship0turntemp), Quaternion.Euler(Vector3.forward * HoriTurnMax * Mathf.Abs( Ship0MoveVector.x)), t2/1.5f);
            } else if (Ship0MoveVector.x < 0)
            {
                if (ship0recorded >= 0)
                {
                    t2 = 0;
                    ship0recorded = Ship0MoveVector.x;
                    ship0turntemp = Ship0.transform.rotation.eulerAngles;
                }
                Ship0.transform.rotation = Quaternion.Lerp(Quaternion.Euler( ship0turntemp), Quaternion.Euler(Vector3.forward * HoriTurnMin * Mathf.Abs(Ship0MoveVector.x)), t2 / 1.5f);
            }
            else
            {
                if (ship0recorded != 0)
                {
                    t2 = 0;
                    ship0recorded = Ship0MoveVector.x;
                    ship0turntemp = Ship0.transform.rotation.eulerAngles;
                }
                Ship0.transform.rotation = Quaternion.Lerp(Quaternion.Euler(ship0turntemp), Quaternion.Euler(Vector3.zero), t2 / 1f);
                
            }
        }
        else
        {
            Rb0.velocity = Vector2.zero;
            //flame0.SetActive(false);
            Rb0.MovePosition(Ship0Pos);
            if (ship0recorded != 0)
            {
                t2 = 0;
                ship0recorded = Ship0MoveVector.x;
                ship0turntemp = Ship0.transform.rotation.eulerAngles;
            }
            Ship0.transform.rotation = Quaternion.Lerp(Quaternion.Euler(ship0turntemp), Quaternion.Euler(Vector3.zero), t2 / 1f);
            //transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        if (Ship1MoveVector != Vector2.zero)
        {
            Rb1.MovePosition(Ship1Pos + Ship1MoveVector * Time.deltaTime * Sp1);
            //flame1.SetActive(true);
            t3 += Time.fixedDeltaTime;
            if (Ship1MoveVector.x > 0)
            {
                if (ship1recorded <= 0)
                {
                    t3 = 0;
                    ship1recorded = Ship1MoveVector.x;
                    ship1turntemp = Ship1.transform.rotation.eulerAngles;
                }
                Ship1.transform.rotation = Quaternion.Lerp(Quaternion.Euler(ship1turntemp), Quaternion.Euler(Vector3.forward * HoriTurnMax * Mathf.Abs(Ship1MoveVector.x)), t3/ 1.5f);
            }
            else if (Ship1MoveVector.x < 0)
            {
                if (ship1recorded >= 0)
                {
                    t3 = 0;
                    ship1recorded = Ship1MoveVector.x;
                    ship1turntemp = Ship1.transform.rotation.eulerAngles;
                }
                Ship1.transform.rotation = Quaternion.Lerp(Quaternion.Euler(ship1turntemp), Quaternion.Euler(Vector3.forward * HoriTurnMin * Mathf.Abs(Ship1MoveVector.x)), t3 / 1.5f);
            }
            else
            {
                if (ship1recorded != 0)
                {
                    t3 = 0;
                    ship1recorded = Ship1MoveVector.x;
                    ship1turntemp = Ship1.transform.rotation.eulerAngles;
                }
                Ship1.transform.rotation = Quaternion.Lerp(Quaternion.Euler(ship1turntemp), Quaternion.Euler(Vector3.zero), t3 / 1f);
            }
        }
        else
        {
            Rb1.velocity = Vector2.zero;
            Rb1.MovePosition(Ship1Pos);
            //flame1.SetActive(false);
            if (ship1recorded != 0)
            {
                t3 = 0;
                ship1recorded = Ship1MoveVector.x;
                ship1turntemp = Ship1.transform.rotation.eulerAngles;
            }
            Ship1.transform.rotation = Quaternion.Lerp(Quaternion.Euler(ship1turntemp), Quaternion.Euler(Vector3.zero), t3 / 1f);
        }
       
        
    }
    public float t1, CamSizeSwitchMaxTime,ZoomSp,UnzoomSp;



}
