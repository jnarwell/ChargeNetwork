using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Child_Info : MonoBehaviour
{

    public SpriteRenderer back;
    public TMP_Text text;

    void Start()
    {
        back = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TMP_Text>();
    }

}
