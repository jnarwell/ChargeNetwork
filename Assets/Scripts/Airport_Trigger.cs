using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Airport_Trigger : MonoBehaviour
{

    public Toggle onoff;
    public Animator anim;
    public Connection_Mode_Change conmod;
    public ToggleGroup toggleGroup;
    public int counter;
    public PathFinding pathF;

    public Child_Info childInfo;


    private void Start()
    {
        pathF = GameObject.FindGameObjectWithTag("path finder").GetComponent<PathFinding>();
        
        counter = 0;

        childInfo = GetComponentInChildren<Child_Info>();

        toggleGroup = GetComponentInParent<ToggleGroup>();
        anim = gameObject.GetComponentInChildren<Animator>();
        onoff = GetComponent<Toggle>();
        //onoff.onValueChanged.AddListener(delegate
        //{
        //    if (pathF.doubleClick==false)
        //        userToggle(onoff);
        //    else
        //        onoff.isOn = false;
        //});

    }
    private void Update()
    {

        if (onoff.isOn==false && anim.GetCurrentAnimatorStateInfo(0).IsName("KBVT Text") && !anim.IsInTransition(0))
        {
            anim.SetTrigger("Active");
        }

    }

    public void userToggle (bool tog)
    {
        childInfo.back.sortingOrder = 10;
        //childInfo.outline.sortingOrder = 9;
        childInfo.text.canvas.sortingOrder = 11;
        anim.SetTrigger("Active");
        //if (conmod.counter % 2 != 0 && counter % 2 != 0)
        //{
        //    onoff.isOn = false;
        //    childInfo.back.sortingOrder = 2;
        //    childInfo.text.canvas.sortingOrder = 3;
        //}
        //counter += 1;

        //if (onoff.isOn == false)
        //{
        //    childInfo.back.sortingOrder = 2;
        //    childInfo.text.canvas.sortingOrder = 3;
        //}
    }

}
