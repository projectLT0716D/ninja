using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    private bool OnAir;
    private Rigidbody2D ninja;
    private float jump;
    private float move = 30f;
    // Use this for initialization
    void Start()
    {
        ninja = GetComponent<Rigidbody2D>();
        OnAir = false;
        jump = 600f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            ninja.AddForce(new Vector2(move, 1.13f));
            gameObject.transform.localScale = new Vector3(
                Mathf.Abs(gameObject.transform.localScale.x),
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ninja.AddForce(new Vector2(-move, 1.13f));
            gameObject.transform.localScale = new Vector3(
                -Mathf.Abs(gameObject.transform.localScale.x),
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!OnAir)
            {
                ninja.velocity = Vector2.zero;
                ninja.AddForce(new Vector2(1.47f, jump));
                OnAir = true;
            }
        }
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        OnAir = false;
	}
}
