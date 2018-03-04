using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Flap");
                rb2d.velocity = Vector2.zero; //속도를 점프직전에 날림
                rb2d.AddForce(new Vector2(0, upForce)); //upForce만큼 위로 힘줌
            }

        }
		
	}

    void OnCollisionEnter2D(Collision2D other) 
    {
        GameControl.instance.BirdDied();
        anim.SetTrigger("Die");
        isDead = true;
    }
}
