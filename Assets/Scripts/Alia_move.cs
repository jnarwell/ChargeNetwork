using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alia_move : MonoBehaviour
{
    private float speed = 5f;
    public Vector3 target;
    public Quaternion rotation;
    public float ydist;
    public float xdist;
    void Start()
    {
        target = transform.position;
        rotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            ydist = Mathf.Abs((Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y));
            xdist = Mathf.Abs((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x));


            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = mousePosition - transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction) - 90;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }

}
