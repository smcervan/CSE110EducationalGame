using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Question
{

    private string answer;
    private string questionId;

    public Question(string answer, string questionID){
        this.answer = answer;
        this.questionId = questionID;
    }        

    public bool checkAnswer(string playerInput){
        if(playerInput == answer){
            return true;
        }
        return false;
    }

    public string getAnswer(){
        return answer;
    }

    public string getID(){
        return questionId;
    }
}
