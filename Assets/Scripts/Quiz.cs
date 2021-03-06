using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Quiz : MonoBehaviour
{
    private Image img;
    private List<(string,List<string>,int)> questions = new List<(string,List<string>,int)>();
    public TMP_Text Question, Rep1, Rep2, Rep3, Rep4;
    public GameObject displayAnswers;
    private int current;

    private bool isRunning = false;
    public bool pressed = false; // modifié quand un bouton de réponse est appuyé

    public GameObject quiz, carte, surprise;
    public Answer reponses;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("QuizStart");
        //Question 1
        List<string> l;
        l = new List<string>();
        l.Add("-Granite");l.Add("-Marbre du Nil");l.Add("-Granodiorite");l.Add("-Diorite");
        questions.Add(("De quel matériaux est faite la pierre de Rosette ?",l,2));

        //Question 2
        l = new List<string>();
        l.Add("-1695");l.Add("-1790");l.Add("-1797");l.Add("-1802");
        questions.Add(("Quand est né Champollion ?",l,1));

        //Question 3
        l = new List<string>();
        l.Add("-Hieroglyphes , Grec ancien , Hébreux");l.Add("-Hieroglyphes , Latin , démotique");l.Add("-Hieroglyphes , Grec ancien , Démotique");l.Add("-Hieroglyphes , Grec ancien , Anglais");
        questions.Add(("De quelles langues était constituées la pierre de Rosette ?",l,2));

        //Question 4
        l = new List<string>();
        l.Add("-Ptolémée V ");l.Add("-Ramsès II");l.Add("-Néfertiti");l.Add("-Cléopâtre VI Tryphène");
        questions.Add(("Lors de quel règne a été bâtie la pierre de Rosette ?",l,0));

        //Question 5
        l = new List<string>();
        l.Add("-Rosette");l.Add("-Le Caire");l.Add("-Karnak");l.Add("-Gizeh");
        questions.Add(("Où a été trouvée la stèle ?",l,0));

        //Question 6
        l = new List<string>();
        l.Add("-1803");l.Add("-1795");l.Add("-1799"); l.Add("-1802");
        questions.Add(("Quand la pierre de rosette a été trouvée ?", l, 2));

        //Question 7
        l = new List<string>();
        l.Add("-Attaquer les lignes commerciales anglaises"); l.Add("-Coloniser l'Egypte"); l.Add("-Il s'est perdu"); l.Add("-La réponse D");
        questions.Add(("Que faisait Napoléon en Egypte en 1799 ?", l, 0));

        //Question 8
        l = new List<string>();
        l.Add("-1821"); l.Add("-1823"); l.Add("-1820"); l.Add("-1822");
        questions.Add(("En quelle année les hiéroglyphes ont été déchiffrés ?", l, 3));

        //Question 9
        l = new List<string>();
        l.Add("-Analyse Quantitative"); l.Add("-Analyse Qualitative"); l.Add("-Analyse Spéculative"); l.Add("-Cryptographie");
        questions.Add(("Quelle méthode Jean-François Champollion a utilisé pour déchiffrer les hiéroglyphes ?", l, 0));

        //Question 10
        l = new List<string>();
        l.Add("-4"); l.Add("-8"); l.Add("-10"); l.Add("-6");
        questions.Add(("Combien de langues connaissait Champollion lorsqu'il était jeune ?", l, 1));


        quiz.SetActive(false);
        displayAnswers.SetActive(false);
        img = carte.GetComponent<Image>();
        carte.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuiz() {
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine("QuizStart");
        }
    }

    IEnumerator QuizStart(){
        quiz.SetActive(true);
        foreach ((string quest, List<string> rep, int bonne) in questions)
        {
            Question.text = quest;
            
            Rep1.text = rep[0];
            Rep2.text = rep[1];
            Rep3.text = rep[2];
            Rep4.text = rep[3];

            while (!pressed) {
                yield return null; // ça en reste là tant qu'un bouton de réponse n'est pas appuyé
            }
            pressed = false;
        }
        quiz.SetActive(false);
        displayAnswers.SetActive(true);
        DisplayAnswers();
        isRunning = false;
    }
    IEnumerator FadeIn(){
        yield return new WaitForSeconds(8f);
        carte.SetActive(true);
        displayAnswers.SetActive(false);
        for (float ft = 0f; ft<=1f; ft +=.1f){
            Color c = img.color;
            c.a = ft;
            img.color = c;
            Debug.Log(ft);
            yield return new WaitForSeconds(.1f);
        }
    }

    public void Nice()
    {
        surprise.SetActive(true);
        carte.SetActive(false);
    }

    private void DisplayAnswers() {
        int c = 0;
        for(int i = 0; i < questions.Count; i++) {
            (string x1, List<string> x2, int x3) = questions[i];
            if (reponses.answers[i] == x3) {
                c++;           
            }
        }

        if (c == questions.Count)
        {
            displayAnswers.GetComponent<TMP_Text>().text = "Félicitations! Vous voilà presque incollable sur l'histoire de la pierre de Rosette et son utilisation par Jean-François Champollion!Il ne vous reste plus qu'une question :Placez Rosette sur la carte de l'Egypte!";
            // trigger la map
            StartCoroutine("FadeIn");
        }
        else {
            displayAnswers.GetComponent<TMP_Text>().text = "Vos connaissances laissent à désirer; vous n'avez répondu qu'à " +c+" questions sur "+questions.Count+". N'hésitez pas à visiter à nouveau le musée et à retenter votre chance!";
        }
        reponses.answers.Clear();
    }

} /*
          New line
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