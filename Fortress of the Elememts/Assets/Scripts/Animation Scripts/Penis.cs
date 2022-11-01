using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penis : MonoBehaviour

{
    private Animator animator;
    public float oldPosition;
    public bool movingRight = false;
    public bool movingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        oldPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > oldPosition)
        {
            movingRight = true;
            movingLeft = false;
        }

        if (transform.position.x < oldPosition)
        {
            movingRight = false;
            movingLeft = true;
        }

        if(movingRight)
        {
            animator.SetTrigger("Run Right");
        }
        if (movingLeft)
        {
            animator.SetTrigger("Run Left");
        }
    }
}
