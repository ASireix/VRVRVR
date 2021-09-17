using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Quiz : MonoBehaviour
{

    public Image img;
    private List<(string,List<string>,int)> questions = new List<(string,List<string>,int)>();
    private List<string> l;
    public TMP_Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("QuizStart");
        //Question 1
        l = new List<string>();
        l.Add("-granite\\n");l.Add("-meteorite\\n");l.Add("-granoDIOrite\\n");l.Add("-DIOrite\\n");
        questions.Add(("De quel materiaux est faite la pierre de Rosette ?\\n \\n",l,2));

        //Question 2
        l = new List<string>();
        l.Add("-2021\\n");l.Add("-1790\\n");l.Add("-1797\\n");l.Add("-1802\\n");
        questions.Add(("Quand est né Champollion ?\\n \\n",l,1));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText(string s){
        textBox.text=s;
        StartCoroutine("QuizStart");
    }
    public void PressFade(){
        StartCoroutine("FadeOut");
    }
    IEnumerator QuizStart(){

        foreach ((string quest, List<string> rep, int bonne) in questions)
        {
            textBox.text = quest;
            yield return new WaitForSeconds(2);
        }
            
        

    }
    IEnumerator FadeOut(){
        for (float ft = 1f; ft>=0.00000f; ft -=.1f){
            Color c = img.color;
            c.a = ft;
            img.color = c;
            Debug.Log(ft);
            yield return null; 
        }
    }
} /*
      \n    New line
      \t    Tab
      \v    Vertical Tab
      \b    Backspace
      \r    Carriage return
      \f    Formfeed
      \\    Backslash
      \'    Single quotation mark
      \"    Double quotation mark
      \d    Octal
      \xd    Hexadecimal
      \ud    Unicode character
      */