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
    public Transform text_child;
    public Image image_child;


    private void Start()
    {
        pathF = GameObject.FindGameObjectWithTag("path finder").GetComponent<PathFinding>();
        
        for (int i = 0; i<transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Text")
            {
                text_child = transform.GetChild(i);
            }
            else
            {
                image_child = transform.GetChild(i).GetComponent<Image>();
            }
        }

        counter = 0;

        childInfo = GetComponentInChildren<Child_Info>();

        toggleGroup = GetComponentInParent<ToggleGroup>();
        anim = gameObject.GetComponentInChildren<Animator>();
        onoff = GetComponent<Toggle>();
        onoff.onValueChanged.AddListener(delegate
        {
            if (pathF.singleClick == true)
                userToggle(onoff);
            else
                onoff.isOn = false;
        });
    }
    public void userToggle(bool tog)
    {
        childInfo.back.sortingOrder = 10;
        //childInfo.outline.sortingOrder = 9;
        childInfo.text.canvas.sortingOrder = 11;
        //text_child.transform.localPosition = new Vector3(text_child.transform.localPosition.x, text_child.transform.localPosition.y, -2);
        anim.SetTrigger("Active");

    }
    //private void Update()
    //{
    //    //if (onoff.isOn == true)
    //    //{
    //    //    Debug.Log(text_child.GetComponent<RectTransform>().localPosition);
    //    //}
    //    if (onoff.isOn == false && text_child.GetComponent<RectTransform>().localPosition == new Vector3(3.04999995f, 1, -2.00000048f))
    //    {
    //        StartCoroutine(userToggle());
    //        text_child.transform.localPosition = new Vector3(text_child.transform.localPosition.x, text_child.transform.localPosition.y, -3);
    //    }


    //}


}
