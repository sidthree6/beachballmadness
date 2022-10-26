using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float RotatingSpeed;

    private bool isJumping;
    [SerializeField]
    private float ForceValue;

    private Rigidbody2D MyRigidBody;

    [SerializeField]
    private GameObject PlayerShadow;

    private GamePlayScript gameplay;

    private GameObject Parent;

    // Use this for initialization
    void Start () {

        isJumping = false;

        MyRigidBody = GetComponent<Rigidbody2D>();

        gameplay = GameObject.FindGameObjectWithTag("gameplay").GetComponent<GamePlayScript>();

        gameplay.SetScoreText();

        Parent = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Rotate Ball Constantly
        ConstantRotation();

        // Jump
        Jump();

        // Update Shadow
        UpdateShadow();

        // Move Whole component with it
        Parent.transform.position = new Vector3(transform.position.x, Parent.transform.position.y, Parent.transform.position.z);
    }

    // Rotate Ball Constantly
    private void ConstantRotation()
    {
        float currentRotation = transform.localEulerAngles.z;
        currentRotation -= RotatingSpeed;

        transform.localEulerAngles = new Vector3(0, 0, currentRotation);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            Vector2 JumpForce = new Vector2(0,ForceValue);

            MyRigidBody.AddForce(JumpForce, ForceMode2D.Impulse);

            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "PlayerPlatform")
        {
            isJumping = false;
        }
    }

    private void UpdateShadow()
    {
        float DiffBetweenShadowAndPlayer = transform.position.y - PlayerShadow.transform.position.y;

        // Change Shadow Transparancy
        if(DiffBetweenShadowAndPlayer > 1)
        {
            float BaseAlpha = PlayerShadow.GetComponent<BeachBallShadow>().GetAlpha();
            float multiplierA = 0.08f;
            float multiplierS = 0.065f;
            float BaseSize = 1.0f;

            BaseAlpha -= (DiffBetweenShadowAndPlayer * multiplierA);

            BaseSize -= (DiffBetweenShadowAndPlayer * multiplierS);

            PlayerShadow.GetComponent<BeachBallShadow>().SetAlpha(BaseAlpha);
            PlayerShadow.GetComponent<BeachBallShadow>().SetSize(BaseSize);
        }
    }

    public void Dies()
    {
        // Dies

        gameplay.CurrentGameState = GameState.GameOver;
        gameplay.KillPlayer();
        gameplay.SpawnTitleScreen();
        gameplay.CurrentScoreAccess = 0;
    }

    public void CollectScore()
    {
        // Collect score
        gameplay.CurrentScoreAccess++;
        // Update Score Text
        gameplay.SetScoreText();
    }
}
