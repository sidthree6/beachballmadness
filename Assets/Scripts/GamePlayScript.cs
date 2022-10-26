using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { StartMenu, Playing, GameOver };

public class GamePlayScript : MonoBehaviour {
    public GameObject Player;
    public GameObject PlayerDeathCollider;
    private UIScript CanvasScript;
    public GameObject PlayerDied;

    public GameObject TitleScreen;
    private GameObject InstancedTitleScreen;

    private GameObject InstancedPlayer;

    private int CurrentScore;

    Vector3 PlayerSpawnPlace = new Vector3(-2.68f, -3.15f, 0.0f);
    Vector3 DeathColliderPlace = new Vector3(-8.47f, -1.947f,0.0f);

    public GameState CurrentGameState { get; set; }

    // Use this for initialization
    void Start () {

        CurrentGameState = GameState.StartMenu;
        CurrentScore = 0;

        CanvasScript = GameObject.Find("Canvas").GetComponent<UIScript>();

        CanvasScript.HideShowText(false);

        SpawnTitleScreen();

    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Return) && CurrentGameState != GameState.Playing)
        {
            CurrentGameState = GameState.Playing;

            SpawnPlayer();

            SpawnPlayerDeathCollider();

            CanvasScript.HideShowText(true);

            KillTitleScreen();
        }

	}

    public void SpawnTitleScreen()
    {
        InstancedTitleScreen = Instantiate(TitleScreen, Vector3.zero, Quaternion.identity);
    }

    public void KillTitleScreen()
    {
        Object.Destroy(InstancedTitleScreen);
    }

    void SpawnPlayer()
    {
        InstancedPlayer = Instantiate(Player, PlayerSpawnPlace, Quaternion.identity);
    }

    public void KillPlayer()
    {
        GameObject BallDead = Instantiate(PlayerDied, InstancedPlayer.transform.position, Quaternion.identity);

        Object.Destroy(BallDead, 1.0f);

        Object.Destroy(InstancedPlayer);
    }

    void SpawnPlayerDeathCollider()
    {
        Instantiate(PlayerDeathCollider, DeathColliderPlace, Quaternion.identity);
    }    

    // Change Current Score
    public int CurrentScoreAccess
    {
        get { return CurrentScore; } // Get Score
        set { CurrentScore = value; } // Set Score
    }

    public void SetScoreText()
    {
        CanvasScript.SetScoreText(CurrentScore);
    }
}
