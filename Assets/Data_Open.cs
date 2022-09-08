using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data_Open : MonoBehaviour
{

    private Toggle toggle;
    public Connection_data condat;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        condat = GameObject.Find("Connection Data").GetComponent<Connection_data>();
    }

    void Update()
    {
        toggle.onValueChanged.AddListener(delegate
        {
            userToggle(toggle);
        });
    }

    public void userToggle(bool tog)
    {
        condat.anim.SetTrigger("Active");
        //if (counter % 2 != 0)
        //    toggle.isOn = false;
        //counter += 1;
    }
}
