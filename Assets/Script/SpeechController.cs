using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

// 音声認識を行うクラス
// アイテムの名前をキーワードとして登録し、認識されたキーワードに対応するアイテムのフラグをtrueにする
public class SpeechController : MonoBehaviour
{
    [SerializeField] private QuestionController qc;
    [SerializeField] private GameManager gm;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    void Start()
    {
        foreach (Question question in qc.questions)
        {
            foreach (string answer in question.answer)
            {
                keywords.Add(answer, () =>
                {
                    Debug.Log("Keyword: " + answer);
                    try
                    {
                        gm.answerIndex = qc.questions.IndexOf(question);
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log(e);
                    }
                });
            }
        }

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
