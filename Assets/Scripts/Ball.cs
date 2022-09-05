using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float BallSpeed = 4.0f;
    public float MaxBallSpeed = 10.0f;
    public float MinBallSpeed = 4.0f;
    [SerializeField] AudioClip LosePointSound;
    [SerializeField] AudioClip PaddleToBallSound;
    float RandomSpeedIncreaseChance;
    // Start is called before the first frame update
    void Start()
    {
        InitializeBall();
    }

    public void InitializeBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, BallSpeed);
        GetComponent<Rigidbody2D>().drag = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody2D>().velocity.magnitude > MaxBallSpeed || RandomSpeedIncreaseChance < 6.0f)
        {
            float MultiplyRatio =  MaxBallSpeed / GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y) * MultiplyRatio;
        }
        if (GetComponent<Rigidbody2D>().velocity.magnitude < MinBallSpeed)
        {
            float MultiplyRatio = BallSpeed / GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y) * MultiplyRatio;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RandomSpeedIncreaseChance = Random.Range(1.0f, 100.0f);
        if (collision.gameObject.tag == "player")
        {
            FindObjectOfType<AudioPlayer>().PlaySound(PaddleToBallSound);
        }
        if (collision.gameObject.tag == "losecollider")
        { 
            FindObjectOfType<AudioPlayer>().PlaySound(LosePointSound);
        }
    }
}
