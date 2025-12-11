using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFighterController : MonoBehaviour
{
    public static bool move_status = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public float speed = 1.2f;
    private float radius = 52.5f;

    void Update()
    {
        //Control
        if (move_status)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (transform.localPosition.y + speed + radius <= 105) transform.Translate(0, speed, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (transform.localPosition.y - speed - radius >= -105) transform.Translate(0, -speed, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.localPosition.x - speed - radius >= -175) transform.Translate(-speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.localPosition.x + speed + radius <= 175) transform.Translate(speed, 0, 0);
            }
        }
    }
}
