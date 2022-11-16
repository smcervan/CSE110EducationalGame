using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQuestion
{
    private int customerQuestionObjectIndex; //Customer's question index
    private ArrayList createdQuestions = new ArrayList();  //ArrayList of available questions
    private Question customerQuestionObject; //The selected question
    private string questionID; //The question identifier

    //Default Constructor
    public CustomerQuestion(){
        createAddQuestions();
        this.customerQuestionObjectIndex = selectQuestion(0,4); //Randomly selects a question
        this.customerQuestionObject = (Question)createdQuestions[customerQuestionObjectIndex]; //Sets the selected question to a question object
        this.questionID = customerQuestionObject.getID(); //Gets the question Id of the selected question
    }

    //Helper Methods

    //Adds questions to the array to be accessed, creates the question, adds the answer and identifier.
    private void createAddQuestions(){
        Question A1 = new Question("0", "A1");
        Question B1 = new Question("<","B1");
        Question C1 = new Question("x++","C1");
        Question D1 = new Question("x","D1");
        Question E1 = new Question("x","E1");
        createdQuestions.Add(A1);
        createdQuestions.Add(B1);
        createdQuestions.Add(C1);
        createdQuestions.Add(D1);
        createdQuestions.Add(E1);
    }

    private int selectQuestion(int starting, int ending){
        System.Random randomNum = new System.Random();
        int selectedIndex = randomNum.Next(starting, ending); //Gets the first level questions
        
        return selectedIndex;
    }

    //Getters

    public Question getCustomerQuestionObject(){
        return customerQuestionObject;
    }

    public int getQuestionIndex(){
        return customerQuestionObjectIndex;
    }
}
