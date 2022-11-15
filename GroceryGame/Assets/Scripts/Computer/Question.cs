using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Question
{

    private string answer;
    private string answer2;
    private string questionId;

    public Question(string answer, string questionID){
        this.answer = answer;
        this.questionId = questionID;
    }        

    public Question(string answer, string answer2, string questionID){
        this.answer = answer;
        this.answer2 = answer2;
        this.questionId = questionID;
    }

    public string getQuestionID(){
        return questionId;
    }

    public bool checkAnswer(string playerInput){
        if(playerInput == answer){
            return true;
        }
        return false;
    }
}
