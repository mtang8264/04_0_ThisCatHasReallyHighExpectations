using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFaces : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Sprite first;
    public Sprite[] goodResponses;
    public Sprite[] badResponses;

    public static CatFaces me;

    // Start is called before the first frame update
    void Awake()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Good()
    {
        renderer.sprite = goodResponses[Random.Range(0, goodResponses.Length)];
    }
    public void Bad()
    {
        renderer.sprite = badResponses[Random.Range(0, badResponses.Length)];
    }
    public void Begin()
    {
        renderer.enabled = true;
    }
}
