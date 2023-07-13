using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightSquare : MonoBehaviour
{
    public int xPos, yPos;
    public bool occupied, selected, highlighted, wall;
    public new Transform transform;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    public void Start()
    {
        selected = false;
        occupied = false;
        this.transform = this.GetComponent<Transform>();
        this.sprite = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (this.selected) this.sprite.color = new Color(0, 1, 0);
        else if (this.occupied) this.sprite.color = new Color(1, 0, 0);
        else this.sprite.color = new Color(1, 1, 1);
    }
}
