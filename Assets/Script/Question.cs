using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// アイテムの情報を保持するクラス
[CreateAssetMenu(fileName = "Question", menuName = "Question", order = 0)]
public class Question : ScriptableObject
{
    public List<string> answer;
    public Sprite image;
}
