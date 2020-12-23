using UnityEngine;
using System.Collections;

public class waypoint : MonoBehaviour {

    GameObject[] waypoints;
    Rigidbody2D mrb;

    [SerializeField]
    int current;
    [SerializeField]
    float speed;
    [SerializeField]
    float stoppingDistance;
    [SerializeField]
    bool breaking;

    bool moving = false;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        mrb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.Space))
        {
            moving = true;
        }
        if(moving)
        {
            if (Vector2.Distance(gameObject.transform.position, waypoints[current].transform.position) > stoppingDistance)
            {
                Vector2 force =  (Vector2)waypoints[current].transform.position - (Vector2)gameObject.transform.position;
                force *= speed;
                mrb.AddForce(force);
            }
            else
            {
                if(breaking)
                {
                    mrb.AddForce(-mrb.velocity, ForceMode2D.Impulse);
                }
                moving = false;
                if ((current + 1) == waypoints.Length)
                {
                    current = 0;
                }
                else
                {
                    current++;
                }
            }
        }
	}
}
