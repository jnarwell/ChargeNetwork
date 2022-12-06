using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connection_Mode_Change : MonoBehaviour
{
    public SpriteRenderer circleRenderer;
    public Image randomConnect;

    private Color oldColor;

    [SerializeField] private Color newColor;

    public int counter = 0;

    private void Start()
    {
        oldColor = circleRenderer.color;
        if (GameObject.Find("Random Connection Button"))
        {
            randomConnect = GameObject.Find("Random Connection Button").GetComponent<Image>();
            randomConnect.enabled = false;
        }

        }

        public void ChangeMaterial()
    {
        if (counter % 2 == 0)
        {
            circleRenderer.color = newColor;
            //Debug.Log("Test");
            if (GameObject.Find("Random Connection Button")) randomConnect.enabled = true;
        }
        else if (GameObject.Find("Random Connection Button")) randomConnect.enabled = false;
        if (counter % 2 != 0)
            circleRenderer.color = oldColor;
        counter++;
    } 
}
