using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI questionText;
  [SerializeField] QuestionSO question;
  [SerializeField] GameObject[] answerButtons;
  int correctAnswerIndex;
  [SerializeField] Sprite defaultAnswerSprite;
  [SerializeField] Sprite correctAnswerSprite;

  void Start()
  {
    DisplayQuestion();
  }

  public void OnAnswerSelected(int index)
  {
    Image buttonImage;

    if (index == question.GetCorrectAnswerIndex())
    {
      questionText.text = "Correct!";
      buttonImage = answerButtons[index].GetComponent<Image>();
      buttonImage.sprite = correctAnswerSprite;
    }
    else
    {
      correctAnswerIndex = question.GetCorrectAnswerIndex();
      string correctAnswer = question.GetAnswer(correctAnswerIndex);
      questionText.text = "Incorrect! The answer was:\n" + correctAnswer;

      buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
      buttonImage.sprite = correctAnswerSprite;
    }

    SetButtonState(false);
  }

  void GetNextQuestion()
  {
    SetButtonState(true);
    SetDefaultButtonSprites();
    DisplayQuestion();
  }

  void DisplayQuestion()
  {
    questionText.text = question.GetQuestion();

    for (int i = 0; i < answerButtons.Length; i++)
    {
      TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
      buttonText.text = question.GetAnswer(i);
    }
  }

  void SetButtonState(bool buttonState)
  {
    for (int i = 0; i < answerButtons.Length; i++)
    {
      Button button = answerButtons[i].GetComponent<Button>();
      button.interactable = buttonState;
    }
  }

  void SetDefaultButtonSprites()
  {
    Image buttonImage;
    for (int i = 0; i < answerButtons.Length; i++)
    {
      buttonImage = answerButtons[i].GetComponent<Image>();
      buttonImage.sprite = defaultAnswerSprite;
    }
  }
}
