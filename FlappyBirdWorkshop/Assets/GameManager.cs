using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Transform SpawnPoint;
    public GameObject Player;
    public GameObject PipeContainer;
    public GameObject PipeSet;

    public GameObject MainMenu;
    public GameObject Score;
    public GameObject ScoreScreen;
    public GameObject CreditsScreen;
    public GameObject FastModeButton;
    public Text FastModeText;
    private Color FastModeTextColor;

    public GameObject Background;
    public GameObject BackgroundContainer;
    public GameObject CurrentEdge;

    private CameraMovement GameCamera;
    private bool fastMode;

    //Pipe and Background Spawn Time Settings
    public float PipeSpawnTime = 1f;
    public float BackgroundSpawnTime = 5f;
    public int BackgroundInitialSpawnAmount = 5;

    //Camera Speed Settings
    public float initialSpeed = 0.08f;
    private float fastModeSpeed = 2f;

    private bool GameOn = false;
	// Use this for initialization
	void Start () {
        //Spawn the first background
        SpawnBackground(1);
        GameCamera = Camera.main.GetComponent<CameraMovement>();
        FastModeTextColor = FastModeText.color;
        FastModeText.color = Color.clear;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void StartGame()
    {
        Score.SetActive(true);
        MainMenu.SetActive(false);
        FastModeButton.SetActive(false);
        GameOn = true;
        if(fastMode)
        {
            GameCamera.SpeedAmount = fastModeSpeed;
            Player.GetComponent<AudioSource>().Play();
        }
        else
        {
            GameCamera.SpeedAmount = initialSpeed;
        }
        GameCamera.Move();
        StartCoroutine(SpawnPipes());
        SpawnBackground(BackgroundInitialSpawnAmount);
        StartCoroutine(SpawnBackgrounds(BackgroundSpawnTime));
        Player.GetComponent<Player>().Reset();
        Player.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        Player.GetComponent<ScoreManager>().Reset();
    }


    public void EndGame()
    {
        Player.GetComponent<Player>().Kill();
        Player.GetComponent<AudioSource>().Stop();
        GameCamera.Halt();
        StopAllCoroutines();
        StartCoroutine(EndGameSequence(1f));
    }

    public void OnCredits()
    {
        CreditsScreen.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void OnBack()
    {
        CreditsScreen.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnRetry()
    {
        ScoreScreen.SetActive(false);
        //Kill all pipes
        foreach (Transform child in PipeContainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in BackgroundContainer.transform)
        {
            Destroy(child.gameObject);
        }
        Destroy(CurrentEdge);
        CurrentEdge = null;
        StartGame();
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    IEnumerator EndGameSequence(float sec)
    {
        yield return new WaitForSeconds(sec);
        ScoreScreen.SetActive(true);
        FastModeButton.SetActive(true);
        Score.SetActive(false);
        Player.GetComponent<ScoreManager>().UpdateFinalScore();
    }


    IEnumerator SpawnPipes()
    {
        while(GameOn)
        {
            GameObject new_pipes = GameObject.Instantiate(PipeSet, SpawnPoint.position, PipeSet.transform.rotation);
            new_pipes.transform.parent = PipeContainer.transform;
            yield return new WaitForSeconds(PipeSpawnTime);
        }
    }

    IEnumerator SpawnBackgrounds(float time)
    {
        while (GameOn)
        {
            yield return new WaitForSeconds(time);
            SpawnBackground(5);
        }
    }

    public void SpawnBackground(int amount)
    {
        if(!CurrentEdge)
        {
            CurrentEdge = new GameObject("Initial Edge");
            CurrentEdge.transform.position = new Vector3(0, 0, 1); // NOTE: The Z is set to one because we want all backgrounds to be behind the bird. It's to keep sprites in the game layered correctly.
            CurrentEdge.transform.parent = BackgroundContainer.transform;
        }
        for(int i = 0; i < amount; i++)
        {
            GameObject new_background = GameObject.Instantiate(Background, CurrentEdge.transform.position, CurrentEdge.transform.rotation);
            new_background.transform.parent = BackgroundContainer.transform;
            CurrentEdge = new_background.GetComponent<Background>().Edge;
        }

    }

    public void ToggleFastMode()
    {
        fastMode = fastMode ? false : true; //If true, make false. If not true (false), make true
        if(!fastMode)
        {
            FastModeButton.GetComponent<Image>().color = Color.clear;
            FastModeText.color = Color.clear;
        }
        else
        {
            FastModeButton.GetComponent<Image>().color = Color.white;
            FastModeText.color = FastModeTextColor;
        }
    }
}
