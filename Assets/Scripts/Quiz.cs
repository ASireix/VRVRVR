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
    public TMP_Text textBox;

    private 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("QuizStart");
        //Question 1
        List<string> l;
        l = new List<string>();
        l.Add("-Granite\n");l.Add("-Marbre du Nil\n");l.Add("-Granodiorite\n");l.Add("-Diorite\n");
        questions.Add(("De quel matériaux est faite la pierre de Rosette ?\n \n",l,2));

        //Question 2
        l = new List<string>();
        l.Add("-1695\n");l.Add("-1790\n");l.Add("-1797\n");l.Add("-1802\n");
        questions.Add(("Quand est né Champollion ?\n \n",l,1));

        //Question 3
        l = new List<string>();
        l.Add("-Hieroglyphes , Grec ancien , Hébreux\n");l.Add("-Hieroglyphes , Latin , démotique\n");l.Add("-Hieroglyphes , Grec ancien , Démotique\n");l.Add("-Hieroglyphes , Grec ancien , Anglais\n");
        questions.Add(("De quelles langues était constituées la pierre de Rosette ?<\n \n>",l,2));

        //Question 4
        l = new List<string>();
        l.Add("-Ptolémée V \n");l.Add("-Ramsès II\n");l.Add("-Néfertiti\n");l.Add("-Cléopâtre VI Tryphène\n");
        questions.Add(("Lors de quel règne a été bâtie la pierre de Rosette ?\n \n",l,2));

        //Question 5
        l = new List<string>();
        l.Add("-Ptolémée V \n");l.Add("-Ramsès II\n");l.Add("-Néfertiti\n");l.Add("-Cléopâtre VI Tryphène\n"); // ------------ carte
        questions.Add(("Où a été trouvée la stèle? ?<\n \n>",l,2));

        //Questiob 6
        l = new List<string>();
        l.Add("- l'année derniere\n");l.Add("- un peu plus tôt\n");l.Add("- 1799\n");
        questions.Add(("Quand la pierre de rosette a été trouvé ?\n \n", l, 2));



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