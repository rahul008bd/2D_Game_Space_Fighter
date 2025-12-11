using UnityEngine;

public class Circles : MonoBehaviour
{
    public static Transform[] circles;
    public static Transform[] storage;
    public GameObject destroyer;

    bool flag = false;

    void Awake()
    {
        circles = new Transform[transform.childCount];
        storage = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++) circles[i] = transform.GetChild(i);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int debris_num = 0;

        for (int i = 0; i < storage.Length; i++)
        {
            if (storage[i] != null)
            {
                if (storage[i].tag.Equals("grey")) debris_num++;
            }
        }

        if (debris_num > 5) Control.Lose2();

        HorizontalDetect();
        HorizontalDetectRed();
        HorizontalDetectGreen();
        HorizontalDetectBlue();

        if (flag)
        {
            VerticleDectect();
            flag = false;
        }
    }

    // Detect verticle 3 same color balls
    void VerticleDectect()
    {
        for (int i = 0; i < 5; i++)
        {
            int count = 0;
            string tag = "";

            for (int j = i; j < transform.childCount; j += 5)
            {
                if (storage[j] == null || storage[j].CompareTag("grey"))
                {
                    count = 0;
                    tag = "";
                    continue;
                }
                else
                {
                    if (storage[j].tag.Equals(tag)) count++;
                    else
                    {
                        count = 1;
                        tag = storage[j].tag;
                    }

                    if (count == 3)
                    {
                        Transform[] temp = { storage[j], storage[j - 5], storage[j - 10] };
                        GameObject newDes = Instantiate(destroyer);

                        newDes.GetComponent<Destroying>().ballsToDestroy = temp;
                        newDes.GetComponent<Destroying>().index = 2;
                        newDes.GetComponent<Destroying>().circle_index = j - 10;
                        newDes.GetComponent<Destroying>().whether_destroy = true;
                    }
                }
            }
        }
    }

    // Detect horizontal 3 diff color balls
    void HorizontalDetect()
    {
        for (int i = 0; i <= 20; i += 5)
        {
            for (int j = i; j < i + 3; j++)
            {
                if (storage[j] != null && storage[j + 1] != null && storage[j + 2] != null)
                {
                    if (storage[j].tag.Equals("red") && storage[j + 1].tag.Equals("green") && storage[j + 2].tag.Equals("blue"))
                    {
                        Transform[] temp = { storage[j], storage[j + 1], storage[j + 2] };

                        float max_distance = 0;
                        int max_index = 0;

                        for (int k = 0; k < 3; k++)
                        {
                            float distance = Vector3.Distance(temp[k].position, circles[j + k].position);
                            if (distance > max_distance)
                            {
                                max_distance = distance;
                                max_index = k;
                            }
                        }

                        // Detect: same color 3 balls at the same time
                        if (j <= 12)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (storage[j + k + 5].CompareTag(storage[j + k + 10].tag) && storage[j + k + 5].CompareTag(temp[k].tag))
                                {
                                    Transform[] newTemp = new Transform[5];

                                    for (int m = 0; m < 3; m++) newTemp[m] = temp[m];

                                    newTemp[3] = storage[j + k + 5];
                                    newTemp[4] = storage[j + k + 10];
                                    temp = newTemp;
                                    break;
                                }
                            }
                        }
                        GameObject newDes = Instantiate(destroyer);

                        newDes.GetComponent<Destroying>().ballsToDestroy = temp;
                        newDes.GetComponent<Destroying>().index = max_index;
                        newDes.GetComponent<Destroying>().circle_index = j + max_index;
                        newDes.GetComponent<Destroying>().whether_destroy = true;
                    }
                }
            }
            if (i == 20) flag = true;
        }
    }

    // detect 3 same red horizontal balls
    void HorizontalDetectRed()
    {
        for (int i = 0; i <= 20; i += 5)
        {
            for (int j = i; j < i + 3; j++)
            {
                if (storage[j] != null && storage[j + 1] != null && storage[j + 2] != null)
                {
                    if (storage[j].tag.Equals("red") && storage[j + 1].tag.Equals("red") && storage[j + 2].tag.Equals("red"))
                    {
                        Transform[] temp = { storage[j], storage[j + 1], storage[j + 2] };

                        float max_distance = 0;
                        int max_index = 0;

                        for (int k = 0; k < 3; k++)
                        {
                            float distance = Vector3.Distance(temp[k].position, circles[j + k].position);
                            if (distance > max_distance)
                            {
                                max_distance = distance;
                                max_index = k;
                            }
                        }

                        // Detect: same color 3 balls at the same time
                        if (j <= 12)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (storage[j + k + 5].CompareTag(storage[j + k + 10].tag) && storage[j + k + 5].CompareTag(temp[k].tag))
                                {
                                    Transform[] newTemp = new Transform[5];

                                    for (int m = 0; m < 3; m++) newTemp[m] = temp[m];

                                    newTemp[3] = storage[j + k + 5];
                                    newTemp[4] = storage[j + k + 10];
                                    temp = newTemp;
                                    break;
                                }
                            }
                        }
                        GameObject newDes = Instantiate(destroyer);

                        newDes.GetComponent<Destroying>().ballsToDestroy = temp;
                        newDes.GetComponent<Destroying>().index = max_index;
                        newDes.GetComponent<Destroying>().circle_index = j + max_index;
                        newDes.GetComponent<Destroying>().whether_destroy = true;
                    }
                }
            }
            if (i == 20) flag = true;
        }
    }

    // detect 3 same green color balls horizontal
    void HorizontalDetectGreen()
    {
        for (int i = 0; i <= 20; i += 5)
        {
            for (int j = i; j < i + 3; j++)
            {
                if (storage[j] != null && storage[j + 1] != null && storage[j + 2] != null)
                {
                    if (storage[j].tag.Equals("green") && storage[j + 1].tag.Equals("green") && storage[j + 2].tag.Equals("green"))
                    {
                        Transform[] temp = { storage[j], storage[j + 1], storage[j + 2] };

                        float max_distance = 0;
                        int max_index = 0;

                        for (int k = 0; k < 3; k++)
                        {
                            float distance = Vector3.Distance(temp[k].position, circles[j + k].position);
                            if (distance > max_distance)
                            {
                                max_distance = distance;
                                max_index = k;
                            }
                        }

                        // Detect: same color 3 balls at the same time
                        if (j <= 12)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (storage[j + k + 5].CompareTag(storage[j + k + 10].tag) && storage[j + k + 5].CompareTag(temp[k].tag))
                                {
                                    Transform[] newTemp = new Transform[5];

                                    for (int m = 0; m < 3; m++) newTemp[m] = temp[m];

                                    newTemp[3] = storage[j + k + 5];
                                    newTemp[4] = storage[j + k + 10];
                                    temp = newTemp;
                                    break;
                                }
                            }
                        }
                        GameObject newDes = Instantiate(destroyer);

                        newDes.GetComponent<Destroying>().ballsToDestroy = temp;
                        newDes.GetComponent<Destroying>().index = max_index;
                        newDes.GetComponent<Destroying>().circle_index = j + max_index;
                        newDes.GetComponent<Destroying>().whether_destroy = true;
                    }
                }
            }
            if (i == 20) flag = true;
        }
    }

    // detect 3 same blue color balls horizontal
    void HorizontalDetectBlue()
    {
        for (int i = 0; i <= 20; i += 5)
        {
            for (int j = i; j < i + 3; j++)
            {
                if (storage[j] != null && storage[j + 1] != null && storage[j + 2] != null)
                {
                    if (storage[j].tag.Equals("blue") && storage[j + 1].tag.Equals("blue") && storage[j + 2].tag.Equals("blue"))
                    {
                        Transform[] temp = { storage[j], storage[j + 1], storage[j + 2] };

                        float max_distance = 0;
                        int max_index = 0;

                        for (int k = 0; k < 3; k++)
                        {
                            float distance = Vector3.Distance(temp[k].position, circles[j + k].position);
                            if (distance > max_distance)
                            {
                                max_distance = distance;
                                max_index = k;
                            }
                        }

                        // Detect: same color 3 balls at the same time
                        if (j <= 12)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (storage[j + k + 5].CompareTag(storage[j + k + 10].tag) && storage[j + k + 5].CompareTag(temp[k].tag))
                                {
                                    Transform[] newTemp = new Transform[5];

                                    for (int m = 0; m < 3; m++) newTemp[m] = temp[m];

                                    newTemp[3] = storage[j + k + 5];
                                    newTemp[4] = storage[j + k + 10];
                                    temp = newTemp;
                                    break;
                                }
                            }
                        }
                        GameObject newDes = Instantiate(destroyer);

                        newDes.GetComponent<Destroying>().ballsToDestroy = temp;
                        newDes.GetComponent<Destroying>().index = max_index;
                        newDes.GetComponent<Destroying>().circle_index = j + max_index;
                        newDes.GetComponent<Destroying>().whether_destroy = true;
                    }
                }
            }
            if (i == 20) flag = true;
        }
    }
}
