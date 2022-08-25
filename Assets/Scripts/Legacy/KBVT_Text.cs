using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBVT_Text : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    public bool yes = false;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //Debug.Log("Started");

    }


    void Update()
    {
        //clicked = GetComponentInParent<KBVTTrigger>();
        //Debug.Log(yes);

        if (Input.GetMouseButtonDown(0))
        {
            //clicked = true;
            //Debug.Log("Clicked");
        }

        if (yes == true)
        {
            anim.SetTrigger("Active");
            //Debug.Log("Click recieved");
            //Debug.Log(yes);
            yes = false;
            //Debug.Log(yes);
        }
    }

}
