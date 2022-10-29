using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MovingDown : MonoBehaviour
{
    public float speed;
    
    void FixedUpdate()
    {
        if (this.gameObject.transform.position.y < -100) Destroy(this.gameObject);

        transform.position = transform.position + new Vector3(0, -1 * speed * Time.fixedDeltaTime, 0);

    }
}
