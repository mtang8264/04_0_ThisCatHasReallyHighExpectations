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

    private int index = -1;
    public int good, bad;

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

        question.text = questions[index].question;
        answer1.text = questions[index].answer1;
        answer2.text = questions[index].answer2;
    }

    private void Select()
    {
        if(index == -1)
        {
            index = 1;
            CatFaces.me.Begin();
        }
        else if(index < 6)
        {
            if(selection == questions[index].goodAnswer)
            {
                good++;
                CatFaces.me.Good();
            }
            else
            {
                bad++;
                CatFaces.me.Bad();
            }
            index++;
        }
        else
        {
            answer1.enabled = false;
            answer2.enabled = false;
            question.text = good > bad ? goodEnding : badEnding;
            CatFaces.me.renderer.sprite = good > bad ? goodFace : badFace;
        }
    }
}
