using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public float PaddleSpeed = 8.0f;
    public bool IsGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameOver)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player1.GetComponent<Rigidbody2D>().velocity = new Vector2(-PaddleSpeed, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Player1.GetComponent<Rigidbody2D>().velocity = new Vector2(PaddleSpeed, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player2.GetComponent<Rigidbody2D>().velocity = new Vector2(-PaddleSpeed, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Player2.GetComponent<Rigidbody2D>().velocity = new Vector2(PaddleSpeed, 0);
            }
        }
        if(IsGameOver)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("GameScene");
                IsGameOver = false;
            }
        }
    }
}
