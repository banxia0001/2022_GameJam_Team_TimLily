using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MovingDown : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        speed = 10f;
        //Random.Range(-2f,2f);
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        this.transform.localScale = new Vector3(Random.Range(4.8f, 10.2f), Random.Range(4.8f, 10.2f), Random.Range(4.8f, 7.2f));
        this.transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(5f, 30f));
    }
    void FixedUpdate()
    {
        if (this.gameObject.transform.position.y < -50f) Destroy(this.gameObject);

        transform.position = transform.position + new Vector3(0, -1 * speed * Time.fixedDeltaTime, 0);

    }
}
