using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection_Mode_Change : MonoBehaviour
{
    public SpriteRenderer circleRenderer;

    private Color oldColor;

    [SerializeField] private Color newColor;

    public int counter = 0;

    private void Start()
    {
        oldColor = circleRenderer.color;
    }

    public void ChangeMaterial()
    {
        if (counter%2==0)
            circleRenderer.color = newColor;
        if (counter % 2 != 0)
            circleRenderer.color = oldColor;
        counter++;
    } 
}
