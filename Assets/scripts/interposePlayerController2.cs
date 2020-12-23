using UnityEngine;
using System.Collections;

public class interposePlayerController2 : MonoBehaviour {

    Rigidbody2D mrb;
    [SerializeField]
    float speed;

    // Use this for initialization
    void Start()
    {
        mrb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mrb.AddForce(new Vector2(0f, speed));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mrb.AddForce(new Vector2(-speed, 0f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mrb.AddForce(new Vector2(0f, -speed));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mrb.AddForce(new Vector2(speed, 0));
        }
    }
}
