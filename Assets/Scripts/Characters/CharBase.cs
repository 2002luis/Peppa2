using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBase : MonoBehaviour
{
    protected Transform pos;
    protected SpriteRenderer sprite;
    new protected PolygonCollider2D collider;
    new protected Rigidbody2D rigidbody;
    public bool canMove;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        this.pos = this.GetComponent<Transform>();
        this.sprite = this.GetComponent<SpriteRenderer>();
        this.collider = this.GetComponent<PolygonCollider2D>();
        this.rigidbody = this.GetComponent<Rigidbody2D>();
        canMove = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        return;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        return;
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        return;
    }

    protected virtual void OnTriggerEnter2D(Collision2D collision)
    {
        return;
    }

    protected virtual void OnTriggerExit2D(Collision2D collision)
    {
        return;
    }

    protected virtual void OnTriggerStay2D(Collision2D collision)
    {
        return;
    }
}
