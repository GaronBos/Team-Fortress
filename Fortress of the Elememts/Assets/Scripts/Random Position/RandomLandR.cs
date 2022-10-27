using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLandR : MonoBehaviour
{
    private Vector3 dir = Vector3.left;
    public int speed = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x <= -3)
        {
            dir = Vector3.right;
        }
        else if (transform.position.x >= 3)
        {
            dir = Vector3.left;
        }
    }
}
