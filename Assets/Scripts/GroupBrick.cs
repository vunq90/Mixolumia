using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBrick : MonoBehaviour
{
    public Brick[] bricks;
    public Sprite[] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void randomColor()
    {
        for (var i = 0; i < 4; i++)
        {
            bricks[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
