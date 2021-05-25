using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LoadControl;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool Pause { get; set; }
    public static int TimeInit { get; set; }
    public static GameObject playerChoice { get; set; }
    //
    [SerializeField] GameObject playerDefault;
    //
    [SerializeField]
    GameObject optionCanvas;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("KeyUp"))
        {
            PlayerPrefs.SetInt("KeyUp", (int)KeyCode.W);
            PlayerPrefs.SetInt("KeyDown", (int)KeyCode.S);
            PlayerPrefs.SetInt("KeyLeft", (int)KeyCode.A);
            PlayerPrefs.SetInt("KeyRight", (int)KeyCode.D);
            PlayerPrefs.SetInt("KeyPause", (int)KeyCode.Escape);
            PlayerPrefs.SetInt("KeyResume", (int)KeyCode.Space);
            PlayerPrefs.SetFloat("Volume", 1);
        }
        KeyUp = (KeyCode)PlayerPrefs.GetInt("KeyUp");
        KeyDown = (KeyCode)PlayerPrefs.GetInt("KeyDown");
        KeyLeft = (KeyCode)PlayerPrefs.GetInt("KeyLeft");
        KeyRight = (KeyCode)PlayerPrefs.GetInt("KeyRight");
        KeyPause = (KeyCode)PlayerPrefs.GetInt("KeyPause");
        KeyResume = (KeyCode)PlayerPrefs.GetInt("KeyResume");
        Volume = PlayerPrefs.GetFloat("Volume");
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Fase2-level3" || SceneManager.GetActiveScene().name == "Egito1")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (playerChoice == null)
            {
                Instantiate(playerDefault, player.transform.position, player.transform.rotation);
            }
            else
            {
                Instantiate(playerChoice, player.transform.position, player.transform.rotation);
            }
            Destroy(player);
        }
        else
        {
            if (playerChoice == null)
                Instantiate(playerDefault);
            else
                Instantiate(playerChoice);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerChoice);
        if (Input.GetKeyDown(KeyPause) && !Pause)
        {
            Pause = true;
            Time.timeScale = 0;
            optionCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyPause) && Pause)
        {
            Pause = false;
            Time.timeScale = 1;
            optionCanvas.SetActive(false);
        }
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("KeyUp", (int)KeyUp);
        PlayerPrefs.SetInt("KeyDown", (int)KeyDown);
        PlayerPrefs.SetInt("KeyLeft", (int)KeyLeft);
        PlayerPrefs.SetInt("KeyRight", (int)KeyRight);
        PlayerPrefs.SetInt("KeyPause", (int)KeyPause);
        PlayerPrefs.SetInt("KeyResume", (int)KeyResume);
        PlayerPrefs.SetFloat("Volume", Volume);
    }

    public static KeyCode KeyUp { get; set; }
    public static KeyCode KeyDown { get; set; }
    public static KeyCode KeyLeft { get; set; }
    public static KeyCode KeyRight { get; set; }
    public static KeyCode KeyPause { get; set; }
    public static KeyCode KeyResume { get; set; }
    public static float Volume { get; set; }

    public static KeyCode getKeyCode(Control control)
    {
        switch (control)
        {
            case Control.upKey:
                return KeyUp;
            case Control.downKey:
                return KeyDown;
            case Control.rightKey:
                return KeyRight;
            case Control.leftKey:
                return KeyLeft;
            case Control.pauseKey:
                return KeyPause;
            case Control.resumeKey:
                return KeyResume;
            default:
                return KeyCode.Percent;
        }
    }
}
