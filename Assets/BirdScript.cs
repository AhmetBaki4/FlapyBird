using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class NewBehaviourScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float lowerBound = -20; //kusun ekran alt sınırı

    // Start is called before the first frame update
    void Start()
    {
        
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        
        //kusun ekran alt sınırını geçip geçmediğini kontrol ettiğimiz if yapısı
        
        if (transform.position.y < lowerBound && birdIsAlive)
        {
            GameOver();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
