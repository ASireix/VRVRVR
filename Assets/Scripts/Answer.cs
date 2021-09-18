using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public List<int> answers;
    private Quiz final_exam;

    // Start is called before the first frame update
    void Start()
    {
        answers = new List<int>();
        final_exam = GetComponent<Quiz>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GivenAnswer(int button) {
        answers.Add(button);
        final_exam.pressed = true;
    }
}
