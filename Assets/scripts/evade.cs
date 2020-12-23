using UnityEngine;
using System.Collections;

public class evade : MonoBehaviour {

    GameObject player;
    Rigidbody2D mrb;

    [SerializeField]
    float speed;
    [SerializeField]
    float distance;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        mrb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 expectedPos = (Vector2)player.transform.position + ((player.GetComponent<Rigidbody2D>().velocity)*Time.deltaTime);

        if (Vector2.Distance(expectedPos, gameObject.transform.position) < distance)
        {
            Vector2 desiredVel = (((Vector2)gameObject.transform.position - expectedPos).normalized) * speed;
            Vector2 steering = desiredVel - mrb.velocity;

            mrb.AddForce(steering);
        }
    }
}
