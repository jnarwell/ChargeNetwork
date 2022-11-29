using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Connection_data : MonoBehaviour
{
    public List<TMP_Text> tmpList;
    public SpriteRenderer spriteRenderer;
    public TMP_Text titleText;
    public TMP_Text dataText;
    public Image close;
    public Image open;

    public Connection_Mode_Change conmod;
    public PathFinding pathFinding;

    public int counter;
    private float pathDistance;
    public Animator anim;
    private Toggle toggle;

    private TMP_Text distance;
    private TMP_Text time;
    private TMP_Text cost;
    private TMP_Text stops;

    public SpriteRenderer borderSpriteRenderer;

    private void Start()
    {
        titleText = GameObject.Find("Data Title").GetComponent<TMP_Text>();
        dataText = GameObject.Find("Data").GetComponent<TMP_Text>();
        borderSpriteRenderer = GameObject.Find("Border").GetComponent<SpriteRenderer>();
        close = GameObject.Find("Close").GetComponent<Image>();
        open = GameObject.Find("Data Open").GetComponent<Image>();

        distance = GameObject.Find("Distance").GetComponent<TMP_Text>();
        time = GameObject.Find("Time").GetComponent<TMP_Text>();
        cost = GameObject.Find("Cost").GetComponent<TMP_Text>();
        stops = GameObject.Find("Stops").GetComponent<TMP_Text>();

        pathFinding = GameObject.Find("PathFinding").GetComponent<PathFinding>();
        conmod = GameObject.Find("Connection Button").GetComponent<Connection_Mode_Change>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        toggle = GetComponent<Toggle>();

        tmpList.Add(titleText);
        tmpList.Add(dataText);

        tmpList.Add(distance);
        tmpList.Add(time);
        tmpList.Add(cost);
        tmpList.Add(stops);
    }


    private void Update()
    {
        if (conmod.counter % 2 == 0)
        {
            for (int i = 0; i < tmpList.Count; i++) tmpList[i].enabled = false;
            spriteRenderer.enabled = false;
            borderSpriteRenderer.enabled = false;
            close.enabled = false;
            open.enabled = false;

        }
        if (conmod.counter % 2 != 0)
        {
            for (int i = 0; i < tmpList.Count; i++) tmpList[i].enabled = true;
            spriteRenderer.enabled = true;
            borderSpriteRenderer.enabled = true;
            open.enabled = true;
            close.enabled = true;   
        }

        if (pathFinding.path != null)
        {
            for (int i = 0; i < pathFinding.path.Count-1; i++) pathDistance += pathFinding.CalculateDistanceCost(pathFinding.path[i+1], pathFinding.path[i]);
            distance.text = Mathf.Floor(pathDistance*157.23748f).ToString();
            time.text = Mathf.Floor((pathDistance * 157.23748f)/60f).ToString();
            cost.text = Mathf.Floor(pathDistance * 157.23748f* 0.28f).ToString();

            if (pathFinding.path.Count == 0) stops.text = (pathFinding.path.Count).ToString();
            if (pathFinding.path.Count != 0) stops.text = (pathFinding.path.Count - 2).ToString();

            pathDistance = 0;
        }

        toggle.onValueChanged.AddListener(delegate
        {
                userToggle(toggle);
        });
    }

    public void userToggle(bool tog)
    {
        anim.SetTrigger("Active");
        if (counter % 2 != 0) toggle.isOn = false;
        counter += 1;
    }
}
