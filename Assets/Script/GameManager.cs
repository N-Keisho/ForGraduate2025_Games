using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const float PANEL_DISTANCE = 25f;
    [SerializeField] private QuestionController qc;
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private SpriteRenderer answerImage;
    [SerializeField] private Rigidbody QuestionsRoad;
    private int currentQuestionIndex = 0;
    public int answerIndex = -1;
    private int preAnserIndex = -1;

    void Start()
    {
        Vector3 panelPosition = new Vector3(0, 0, PANEL_DISTANCE);
        foreach (Question question in qc.questions)
        {
            GameObject qp = Instantiate(questionPanel, panelPosition, Quaternion.identity);
            qp.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = question.image;
            qp.transform.parent = QuestionsRoad.transform;
            QuestionPanel qpScript = qp.GetComponent<QuestionPanel>();
            qpScript.gm = this;
            qpScript.index = qc.questions.IndexOf(question);

            panelPosition.z += PANEL_DISTANCE;
        }
        QuestionsRoad.AddForce(Vector3.back * 10, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // 常に答えの画像を更新
        if (preAnserIndex != answerIndex)
        {
            answerImage.sprite = qc.questions[answerIndex].image;
            preAnserIndex = answerIndex;
        }

        if(answerIndex == currentQuestionIndex)
        {
            NextQuestion();
        }
    }

    private void NextQuestion()
    {
        if (currentQuestionIndex < qc.questions.Count - 1)
        {
            currentQuestionIndex++;
        }
        else
        {
            currentQuestionIndex = 0;
        }
    }

    private Question GetCurrentQuestion()
    {
        return qc.questions[currentQuestionIndex];
    }

    public void NotCorrect(){
        StartCoroutine(BoundRoad());
    }

    private IEnumerator BoundRoad()
    {
        QuestionsRoad.AddForce(Vector3.forward * 20, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        QuestionsRoad.AddForce(Vector3.back * 20, ForceMode.Impulse);
    }
}
