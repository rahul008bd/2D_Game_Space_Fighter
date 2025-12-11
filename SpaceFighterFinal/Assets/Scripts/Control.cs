using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public GameObject S;
    public GameObject T;

    public GameObject[] notification;
    public static GameObject PopUpWindow;
    public static GameObject PopUpPauseWindow;
    public static GameObject win;
    public static GameObject lose1;
    public static GameObject lose2;
    public static GameObject lose3;
    public GameObject GameViewer;
    public GameObject GameController;
    public GameObject manu;
    public static bool particleMove;

    private bool pause = false;
    private bool start = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Control.particleMove = false;
        Time.timeScale = 0;

        PopUpWindow = notification[0];
        win = notification[1];
        lose1 = notification[2];
        lose2 = notification[3];
        lose3 = notification[4];
        PopUpPauseWindow = notification[5];
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            Time.timeScale = 1;
            start = true;
            SpaceFighterController.move_status = true;
            Control.particleMove = true;
        }

        if (start && !pause)
        {
            timer += Time.deltaTime;

            if ((int)(timer) % 60 < 10 && (int)(timer) / 60 < 10) T.GetComponent<Text>().text = "0" + (int)(timer) / 60 + ":" + "0" + (int)(timer) % 60;
            else if ((int)(timer) / 60 < 10) T.GetComponent<Text>().text = "0" + (int)(timer) / 60 + ":" + (int)(timer) % 60;
            else if ((int)(timer) % 60 < 10) T.GetComponent<Text>().text = (int)(timer) / 60 + ":" + "0" + (int)(timer) % 60;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !PopUpWindow.activeSelf)
        {
            if (pause)
            {
                Time.timeScale = 1;
                SpaceFighterController.move_status = true;
                PopUpPauseWindow.SetActive(false);
                pause = false;
            }
            else
            {
                Time.timeScale = 0;
                SpaceFighterController.move_status = false;
                PopUpPauseWindow.SetActive(true);
                pause = true;
            }
        }

        if (int.Parse(S.GetComponent<Text>().text) >= 100) Win();
    }

    void Win()
    {
        PopUpWindow.SetActive(true);
        win.SetActive(true);
        Time.timeScale = 0;
        SpaceFighterController.move_status = false;
        particleMove = false;
        PopUpPauseWindow.SetActive(false);
    }

    public static void Lose1()
    {
        PopUpWindow.SetActive(true);
        lose1.SetActive(true);
        Time.timeScale = 0;
        SpaceFighterController.move_status = false;
        particleMove = false;
        PopUpPauseWindow.SetActive(false);
    }

    public static void Lose2()
    {
        PopUpWindow.SetActive(true);
        lose2.SetActive(true);
        Time.timeScale = 0;
        SpaceFighterController.move_status = false;
        particleMove = false;
        PopUpPauseWindow.SetActive(false);
    }

    public static void Lose3()
    {
        PopUpWindow.SetActive(true);
        lose3.SetActive(true);
        Time.timeScale = 0;
        SpaceFighterController.move_status = false;
        particleMove = false;
        PopUpPauseWindow.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scenes/SpaceFighter");
    }

    public void resume()
    {
        PopUpPauseWindow.SetActive(false);

        pause = false;

        Time.timeScale = 1;
        SpaceFighterController.move_status = true;
    }
}
