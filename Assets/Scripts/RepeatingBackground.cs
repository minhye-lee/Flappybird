using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    BoxCollider2D groundCollider;

    private float groundHorizontalLength;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();

        groundHorizontalLength = groundCollider.size.x;

    }

    void Update()
    {
        if(transform.position.x < -groundHorizontalLength)
        {
            //오른쪽으로 보내기
            RepositionBackground();

        }
    }

    void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2, 0);

        transform.position = (Vector2)transform.position + groundOffset;
    }
}
