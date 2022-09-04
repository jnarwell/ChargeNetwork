using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Connection_data : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public TMP_Text titleText;
    public TMP_Text dataText;
    public Connection_Mode_Change conmod;


    private void Update()
    {
        if (conmod.counter % 2 == 0)
        {
            titleText.enabled = false;
            dataText.enabled = false;
            spriteRenderer.enabled = false;
        }
        if (conmod.counter % 2 != 0)
        {
            titleText.enabled = true;
            dataText.enabled = true;
            spriteRenderer.enabled = true;
        }
    }
}
