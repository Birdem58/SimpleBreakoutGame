using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;

    public float maxVel = 14;

    public GameObject[] livesImage;

    public GameObject GameoverPanel;

    public GameObject YouWinpanel;
    int brickCount;

    public TextMeshProUGUI scoreTxt;
    int score = 0;

    int lives = 5;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
        rb.velocity = Vector2.down * 9f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            if (lives <= 0)
            {
                Gameover();

            }
            else
            {


                transform.position = new Vector3(0, 1, 0);
                rb.velocity = Vector2.down * 9f;

                lives -= 1;
                livesImage[lives].SetActive(false);
            }

        }
        if (rb.velocity.magnitude > maxVel)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel);
        }





    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);

            score += 10;
            scoreTxt.text = score.ToString("00000");

            brickCount -= 1;
            if (brickCount <= 0)
            {
                YouWinpanel.SetActive(true);
                Time.timeScale = 0;
            }
        }


    }

    void Gameover()
    {
        GameoverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
