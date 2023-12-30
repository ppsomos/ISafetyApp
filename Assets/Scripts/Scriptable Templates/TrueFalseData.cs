using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/TrueFalse")]
public class TrueFalseData : ScriptableObject
{
    public enum type { MCQ, TrueFalse };
    enum answer { wrong, correct };

    public type quizType;

    public int roomIndex;
    public string[] questions;

    public string[] Op1;
    public string[] Op2;

    public int[] answersIndex;

}
