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
    correctAnswerIndex = question.GetCorrectAnswerIndex();
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
      string correctAnswer = question.GetAnswer(correctAnswerIndex);
      questionText.text = "Incorrect! The answer was:\n" + correctAnswer;

      buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
      buttonImage.sprite = correctAnswerSprite;
    }
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
}
