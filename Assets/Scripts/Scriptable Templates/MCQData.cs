using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/MCQs")]
public class MCQData : ScriptableObject
{
    public enum type { MCQ, TrueFalse };
    enum answer { wrong, correct };

    public type quizType;

    public int questionIndex;
    public string[] questions;

    public string[] Op1;
    public string[] Op2;
    public string[] Op3;

    public string[] answersIndex;



}
