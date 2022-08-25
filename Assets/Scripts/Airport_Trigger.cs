using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airport_Trigger : MonoBehaviour
{

    public Toggle onoff;
    public Animator anim;
    public Connection_Mode_Change conmod;
    public ToggleGroup toggleGroup;
    public int counter;

    private void Start()
    {
        counter = 0;
        toggleGroup = GetComponentInParent<ToggleGroup>();
        anim = gameObject.GetComponentInChildren<Animator>();
        onoff = GetComponent<Toggle>();
        onoff.onValueChanged.AddListener(delegate
        {
            if (conmod.counter % 2 == 0)
                userToggle(onoff);
            else
                onoff.isOn = false;
        });

    }
    private void Update()
    {
        if (conmod.counter % 2 != 0 && counter % 2 != 0)
            userToggle(onoff);
    }

    public void userToggle (bool tog)
    {
        anim.SetTrigger("Active");
        if (conmod.counter % 2 != 0 && counter % 2 != 0)
            onoff.isOn = false;
        counter += 1;
    }

}
