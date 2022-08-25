using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Click : MonoBehaviour
{
    public Button aButton;

    public Image aImage;

    void Start()
    {
        Button btn = aButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Button Clicked");
        aImage.transform.position = aButton.transform.position;
    }
    
}
