using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFromEnemy : MonoBehaviour
{
    public GameObject hitScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hitScreen != null)
        {
            if(hitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = hitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                hitScreen.GetComponent<Image>().color = color;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ESpell")
        {
            hit();
        }
    }

    void hit()
    {
        var color = hitScreen.GetComponent<Image>().color;
        color.a = 0.8f;

        hitScreen.GetComponent<Image>().color = color;
    }
}
