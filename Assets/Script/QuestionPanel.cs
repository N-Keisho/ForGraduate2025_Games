using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPanel : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameManager gm;
    public int index;
    private Color color = new Color(0.02f, 0.02f, 0.02f, 1f);
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "AnswerImage")
        {
            if(gm.answerIndex == index)
            {
                spriteRenderer.color = Color.white;
            }
            else
            {
                spriteRenderer.color += color;
                gm.NotCorrect();
            }
        }
    }
}
