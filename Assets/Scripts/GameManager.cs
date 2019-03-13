using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshPro question;
    public TextMeshPro answer1;
    public TextMeshPro answer2;
    public bool selection;

    private Color selected = new Color(0, 0, 0, 255);
    private Color unselected = new Color(0.5f, 0.5f, 0.5f, 1f);

    public string goodEnding, badEnding;
    public Sprite goodFace, badFace;

    public Question[] questions;

    public static GameManager me;

    public int index = -1;
    public int good, bad;
    public SpriteRenderer sprite;

    private void Awake()
    {
        me = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            selection = true;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selection = false;
        }

        if(selection)
        {
            answer2.color = selected;
            answer1.color = unselected;
        }
        else
        {
            answer2.color = unselected;
            answer1.color = selected;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Select();
        }

        if (index != -1 && index < 6)
        {
            question.text = questions[index].question;
            answer1.text = questions[index].answer1;
            answer2.text = questions[index].answer2;
        }
    }

    private void Select()
    {
        if(index == -1)
        {
            index = 1;
            CatFaces.me.Begin();
            if(selection)
            {
                bad++;
                sprite.sprite = CatFaces.me.badResponses[0];
            }
            else
            {
                good++;
                sprite.sprite = CatFaces.me.goodResponses[0];
            }
        }
        else if(index < 5)
        {
            if(selection == questions[index].goodAnswer)
            {
                good++;
                sprite.sprite = CatFaces.me.goodResponses[index];
            }
            else
            {
                bad++;
                sprite.sprite = CatFaces.me.badResponses[index];
            }
            index++;
        }
        else
        {
            if (selection == questions[index].goodAnswer)
            {
                good++;
                sprite.sprite = CatFaces.me.goodResponses[index];
            }
            else
            {
                bad++;
                sprite.sprite = CatFaces.me.badResponses[index];
            }
            index++;
            answer1.enabled = false;
            answer2.enabled = false;
            question.text = bad > 2 ? badEnding : goodEnding;
            CatFaces.me.renderer.sprite = bad > 2 ? badFace : goodFace;
        }
    }

    private void OnMouseDown()
    {
        answer1.color = unselected;
        answer2.color = unselected;
        Destroy(gameObject);
    }
}
