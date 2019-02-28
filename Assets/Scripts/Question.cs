using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    public string question;
    public string answer1;
    public string answer2;
    public bool goodAnswer;
}
