using UnityEngine;
using System.Collections;

public class interposePlayerController1 : MonoBehaviour {

    Rigidbody2D mrb;
    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
        mrb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.W))
        {
            mrb.AddForce(new Vector2(0f, speed));
        }
        if(Input.GetKey(KeyCode.A))
        {
            mrb.AddForce(new Vector2(-speed, 0f));
        }
        if(Input.GetKey(KeyCode.S))
        {
            mrb.AddForce(new Vector2(0f, -speed));
        }
        if(Input.GetKey(KeyCode.D))
        {
            mrb.AddForce(new Vector2(speed, 0));
        }
	}
}
