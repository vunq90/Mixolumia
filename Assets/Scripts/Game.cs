using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Brick _brick;
    public Tile _tile;
    public GroupBrick _group;
    public GameObject _BG;

    private int _height = 7;
    private int _width = 9;
    private float _tileGap = 0.9f;

    float elapsedTime;
    float timeLimit = 2f;

    private List<Tile> _tiles;

    // Start is called before the first frame update
    void Start()
    {
        int[] _array = new int[_width];
        for (var i = 0; i< _array.Length; i++)
        {
            if (i < _width/2)
                _array[i] = _height + i - (_width - 1) / 2;
            else
                _array[i] = _height - i + (_width - 1) / 2;
        }

        for (var i = 0; i < _width; i++)
        {
            for(var j = 0; j < _array[i]; j++)
            {
                var t = Instantiate(_tile, _BG.transform);
                t.transform.position = new Vector2((i - _width * 0.5f + 0.5f) * _tileGap * 0.5f, j * _tileGap + _tileGap * 0.5f * (_height - _array[i]));

                t.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, (byte)(Random.Range(0, 6) * 5));
            }
           
            //_tiles.Add(t);
        }

        _BG.transform.position = new Vector2(0, -(_height - 1) * 0.5f * _tileGap);


    }

    // Update is called once per frame
    void Update()
    {
        /*
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeLimit)
        {
            elapsedTime = 0;
            var g = Instantiate<GroupBrick>(_group,_BG.transform);
            g.randomColor();
            g.transform.position = new Vector2(0, 5f);
        }
        */

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float spawnX = Mathf.Round(mousePos.x / 0.45f);
            var g = Instantiate<GroupBrick>(_group, _BG.transform);
            g.randomColor();
            g.transform.position = new Vector2(spawnX * 0.45f, 3f);
        }
    }
}
