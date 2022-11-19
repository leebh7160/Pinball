using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gameManager;
    public GameManager GameManager
    {
        set
        {
            gameManager = value;
        }
        get => gameManager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Small":
                SendGameScore((int)BallScore.smallBall);
                return;
            case "Big":
                SendGameScore((int)BallScore.bigBall);
                return;
            case "Capsule":
                SendGameScore((int)BallScore.capsule);
                return;
            case "GameEnd":
                SendGameScore((int)BallScore.GameEnd);
                return;
        }
    }

    private void SendGameScore(int touchScore)
    {
        gameManager.SendGameScore(touchScore);
    }

    public void BallRefresh()
    {
        this.gameObject.transform.position = new Vector3(1.6f, 4, 0);
    }
}
