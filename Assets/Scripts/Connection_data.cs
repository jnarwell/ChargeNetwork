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
    public Image clear;

    //public Connection_Mode_Change conmod;
    public PathFinding pathFinding;

    public int counter;
    private float pathDistance;
    public Animator anim;

    private TMP_Text distance;
    private TMP_Text time;
    private TMP_Text cost;
    private TMP_Text carbon_alia;
    private TMP_Text carbon_cesna;

    public SpriteRenderer borderSpriteRenderer;

    private void Start()
    {
        titleText = GameObject.Find("Data Title").GetComponent<TMP_Text>();
        dataText = GameObject.Find("Data").GetComponent<TMP_Text>();
        borderSpriteRenderer = GameObject.Find("Border").GetComponent<SpriteRenderer>();
        clear = GameObject.Find("Clear").GetComponent<Image>();

        distance = GameObject.Find("Distance").GetComponent<TMP_Text>();
        carbon_alia = GameObject.Find("Alia Carbon").GetComponent<TMP_Text>();
        carbon_cesna = GameObject.Find("Cesna Carbon").GetComponent<TMP_Text>();
        cost = GameObject.Find("Cost").GetComponent<TMP_Text>();
        time = GameObject.Find("Time").GetComponent<TMP_Text>();

        pathFinding = GameObject.Find("PathFinding").GetComponent<PathFinding>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();

        tmpList.Add(titleText);
        tmpList.Add(dataText);

        tmpList.Add(distance);
        tmpList.Add(time);
        tmpList.Add(cost);
        tmpList.Add(carbon_alia);
        tmpList.Add(carbon_cesna);

    }


    private void Update()
    {

            for (int i = 0; i < pathFinding.path.Count - 1; i++) pathDistance += pathFinding.CalculateDistanceCost(pathFinding.path[i + 1], pathFinding.path[i]);
            distance.text = Mathf.Floor(pathDistance * 153.6f).ToString();
            time.text = Mathf.Floor((pathDistance * 153.6f) / 105f).ToString();
            cost.text = Mathf.Floor(((pathDistance * 153.6f)/105) * 110f*0.133f).ToString();
            carbon_alia.text = Mathf.Floor(((pathDistance * 153.6f) / 105) * 110f * 1.089f).ToString();
            carbon_cesna.text = Mathf.Floor(((pathDistance * 153.6f) / 180) * 60f * 21.1f).ToString();

        //if (pathFinding.path.Count == 0) carbon.text = (pathFinding.path.Count).ToString();
        //    if (pathFinding.path.Count != 0) carbon.text = (pathFinding.path.Count - 2).ToString();

            pathDistance = 0;
    }


}
