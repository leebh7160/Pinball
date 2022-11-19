using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D LPanel_rigid;
    [SerializeField]
    private Rigidbody2D RPanel_rigid;
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private Button ReplayButton;

    private int scoreResult;
    private bool gameEnd = false;

    private void Start()
    {
        ball.GameManager = this.GetComponent<GameManager>();
        scoreResult = 0;
    }

    void Update()
    {
        if (gameEnd == false)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                LPanel_rigid.AddTorque(30f, ForceMode2D.Force);
            }
            else
                LPanel_rigid.AddTorque(-15f);

            if (Input.GetKey(KeyCode.X))
                RPanel_rigid.AddTorque(-30f, ForceMode2D.Force);
            else
                RPanel_rigid.AddTorque(15f);
        }
    }

    public void SendGameScore(int score)
    {
        if (score == 0)
        {
            GameEnd();
        }
        else
        {
            scoreResult += score;
            scoreText.text = "Score" + scoreResult;
        }
    }

    private void GameEnd()
    {
        gameEnd = true;
        ReplayButton.gameObject.SetActive(true);
    }

    public void EventReplayButtonClick()
    {
        gameEnd = false;
        scoreResult = 0;
        scoreText.text = "Score" + scoreResult;
        ReplayButton.gameObject.SetActive(false);

        ball.BallRefresh();
    }

}
