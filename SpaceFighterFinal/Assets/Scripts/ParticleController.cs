using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    private float[] channel = {-140, -70, 0, 70, 140};
    Transform[] storage;
    bool flag = true;
    int stor_index = -1;
    int channel_index;
    GameObject spaceFighter;

    readonly float R = 52.5f;
    readonly float r = 35.0f;

    void Start()
    {
        storage = Circles.storage;
        spaceFighter = GameObject.FindGameObjectsWithTag("spacefighter")[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Adjust the x position to make line up perfectly
        if (transform.localPosition.y - (-25) <= 0.0f)
        {
            channel_index = AdjustX();

            // Assign a position in storage area
            if (flag)
            {
                flag = false;

                for (int i = 20 + channel_index; i >= channel_index; i -= 5)
                {
                    if (storage[i] == null)
                    {
                        storage[i] = this.transform;
                        stor_index = i;
                        break;
                    }

                    if (i == channel_index) Control.Lose1();
                }
            }
        }

        // Balls below have been destroyed and change the positon
        if (channel_index != -1) AdjustY(channel_index);
        if (stor_index != -1)
        {
            if (transform.localPosition.y < Circles.circles[stor_index].localPosition.y) transform.localPosition = Circles.circles[stor_index].localPosition;
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2.0f * 50);
    }

    int AdjustX()
    {
        int channel_index = 0;
        float x = transform.localPosition.x;
        float diff = float.MaxValue;
        float x_pos = 0.0f;

        for (int i = 0; i < channel.Length; i++)
        {
            if (System.Math.Abs(x - channel[i]) < diff)
            {
                x_pos = channel[i];
                channel_index = i;

                diff = System.Math.Abs(x - channel[i]);
            }
        }

        transform.localPosition = new Vector3(x_pos, transform.localPosition.y, 0);
        return channel_index;
    }

    void AdjustY(int channel_index)
    {
        if (stor_index != -1 && stor_index < 20)
        {
            for (int i = 20 + channel_index; i > stor_index; i -= 5)
            {
                if (storage[i] == null)
                {
                    storage[stor_index] = null;
                    storage[i] = this.transform;
                    stor_index = i;
                    break;
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (this.transform.position.y > spaceFighter.transform.position.y && other.transform.position.y > this.transform.position.y)
        {
            if (this.transform.localPosition.y >= -95)
            {
                if (other.gameObject.CompareTag("red") || other.gameObject.CompareTag("green") || other.gameObject.CompareTag("blue") || other.gameObject.CompareTag("grey"))
                {
                    if (Vector3.Distance(spaceFighter.transform.position, this.transform.position) <= R + r) Control.Lose3();
                }
            }
        }
    }
}
