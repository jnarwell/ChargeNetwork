using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class icon_match : MonoBehaviour
{
    public Image parent_image;
    public Image self_image;
    private void Start()
    {
        self_image = transform.GetComponent<Image>();
        parent_image = transform.parent.parent.GetComponent<Image>();
        self_image.sprite = parent_image.sprite;
    }
}
