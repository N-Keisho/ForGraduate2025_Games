using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

// アイテムの管理とシャッフルを行うだけのクラス
public class QuestionController : MonoBehaviour
{
    public List<Question> questions = new List<Question>();
    private void Awake()
    {
        // Shuffle items
        questions = questions.OrderBy(x => Guid.NewGuid()).ToList();
    }
}
