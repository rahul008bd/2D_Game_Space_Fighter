using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public GameObject[] balls;
    public GameObject canvas;

    public float delay = 2.0f;
    private float countdown;
    private int pre_index = -1;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        Generate(pre_index);
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0) countdown -= Time.deltaTime;
        else
        {
            Generate(pre_index);
            countdown = delay;
        }
    }

    void Generate(int prev)
    {
        int i = Random.Range(0, 4);

        while (i == prev) i = Random.Range(0, 4);
        
        GameObject ballNew = Instantiate(balls[i]);

        ballNew.transform.SetParent(canvas.transform);
        ballNew.transform.localPosition = new Vector3(0, 395, 0);

        pre_index = i;
    }
}
