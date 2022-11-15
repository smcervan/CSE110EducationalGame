using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCodeQuestion
{
    private ArrayList availableQuestions = new ArrayList();
    private Question[] questionsForRound;
    private int amountOfCustomers;

    public CustomerCodeQuestion(int amountOfQuestions){
        questionsForRound = new Question[amountOfQuestions]; //Sets the new array size according to the list of customers
        this.amountOfCustomers = amountOfQuestions;

        addAvailableQuestions();
        createQuestionList();
    }

    private void addAvailableQuestions(){
        //Level 1
        Question A1 = new Question("0", "A1");
        Question B1 = new Question("<","B1");
        Question C1 = new Question("x++","C1");
        Question D1 = new Question("x","D1");
        Question E1 = new Question("x","E1");
        
        //Level 2
        Question A2 = new Question("order.length", "A2");
        Question B2 = new Question("int x = 0", "B2");
        
        //Level 3
        Question A3 = new Question("order[x]","A3");
        Question B3 = new Question("itemsToSend[x]","B3");
        Question C3 = new Question("x<order.length","C3");
        
        //Level 4
        Question A4 = new Question("itemsToSend[x]=order[x]","A4");
        Question B4 = new Question("int x=0;x<order.length;x++","B4");
        
        //Level 5
        Question A5 = new Question("itemsToSend[x]=order[x]","int x=0;x<order.length;x++", "A5");

        //Add the questions to the list
        availableQuestions.Add(A1);
        availableQuestions.Add(B1);
        availableQuestions.Add(C1);
        availableQuestions.Add(D1);
        availableQuestions.Add(E1);
        availableQuestions.Add(A2);
        availableQuestions.Add(B2);
        availableQuestions.Add(A3);
        availableQuestions.Add(B3);
        availableQuestions.Add(C3);
        availableQuestions.Add(A4);
        availableQuestions.Add(B4);
        availableQuestions.Add(A5);
    }

    private void createQuestionList(){

        int indexStart = 0;
        int indexEnd = 4;

        int count = 0;

        while(count < amountOfCustomers){
            Question selectedQuestion = (Question)availableQuestions[chooseQuestionIndex(indexStart, indexEnd)];
            
            if(checkForDups(selectedQuestion) == false){
                questionsForRound[count] = selectedQuestion;
                count++;    
            } else{
                continue;
            }
        }
    }

    private bool checkForDups(Question target){
        for(int x = 0; x < questionsForRound.Length;x++){
            if(target == questionsForRound[x]){
                return true;
            } else{
                continue;
            }
        }

        return false;
    }

    //Selects a question from a specific index of the available questions list;
    private int chooseQuestionIndex(int indexStart, int indexEnd){
        //0-4 Level 1
        //5-6 Level 2
        //7-9 Level 3
        //10-11 Level 4
        //12 Level 5
       
        System.Random randGen = new System.Random();
        int currQuestion = randGen.Next(indexStart, indexEnd);

        return currQuestion;
    }

    private void printQuestions(){
        foreach(Question question in questionsForRound){
            Debug.Log(question.getQuestionID());
        }
    }

    public Question[] getCodingQuestions(){
        return questionsForRound;
    }
}
