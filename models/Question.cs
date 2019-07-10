using System;
using System.Collections.Generic;

namespace flowchart.Models
{
    class Question
    {
        private string Prompt { get; set; }
        private Dictionary<string, Question> Answers { get; set; }
        private Question Previous { get; set; }

        public void AddQuestion(string answer, Question nextQuestion)
        {
            Answers.Add(answer.ToLower(), nextQuestion);
        }

        public Question Selection(string answer)
        {
            //if that answer is in the dictionary of answers
            if (Answers.ContainsKey(answer))
            {
                //return the next question
                Question questionToReturn = Answers[answer];

                questionToReturn.SetPrevious(this);
                return questionToReturn;
            }
            Console.WriteLine("Invalid Selection");
            return this;
        }

        public Question Back()
        {
            if (Previous != null)
            {
                return Previous;
            }
            return this;
        }
        private void SetPrevious(Question question)
        {
            Previous = question;
        }

        public void PrintPrompt()
        {
            Console.WriteLine(Prompt);
            foreach (KeyValuePair<string, Question> entry in Answers)
            {
                Console.Write('(' + entry.Key + ')');
            }
            Console.WriteLine("<Or type 'back' to go back or 'quit' to exit>");
        }




        public Question(string prompt)
        {
            Prompt = prompt;
            Answers = new Dictionary<string, Question>();
        }
    }
}