using System;

namespace flowchart.Models
{
    class Chart
    {
        private Question currentQuestion { get; set; }
        private bool Running { get; set; }
        public string TypeOfFood { get; private set; }

        public void Setup()
        {
            //create all my questions
            Question q1 = new Question("Are you Hungry");
            Question emotions = new Question("Are you really Hungry or just emotional?");
            Question feelings = new Question("Lets eat those feelings away!");
            FoodQuestion type = new FoodQuestion("What type of food do you want?");
            Question cost = new Question("How much do you want to spend?");
            Question dontEat = new Question("No need to eat?");
            FinalQuestion cheap = new FinalQuestion();
            FinalQuestion expensive = new FinalQuestion();


            //results for cheap food
            Question panda = new Question("EAT SOME PANDA EXPRESS!!");
            Question dominos = new Question("EAT SOME Dominos!!");
            Question mcd = new Question("EAT SOME McDonalds!!");


            //establish relationships
            q1.AddQuestion("no", dontEat);
            q1.AddQuestion("yes", emotions);
            emotions.AddQuestion("emotional", dontEat);
            emotions.AddQuestion("hungry", type);
            emotions.AddQuestion("yes", feelings);
            type.AddQuestion("Chinese", cost);
            type.AddQuestion("Italian", cost);
            type.AddQuestion("American", cost);
            cost.AddQuestion("Cheap", cheap);
            cost.AddQuestion("Expensive", expensive);


            cheap.AddQuestion("chinese", panda);
            cheap.AddQuestion("italian", dominos);
            cheap.AddQuestion("american", mcd);







            //set starting question
            currentQuestion = q1;
        }

        public void Run()
        {
            //where all user prompt and interaction will occur
            //while loop
            while (Running)
            {
                Console.Clear();
                currentQuestion.PrintPrompt();
                string response = Console.ReadLine().ToLower();
                if (response == "back")
                {
                    currentQuestion = currentQuestion.Back();
                    continue;
                }
                if (response == "quit")
                {
                    Running = false;
                    break;
                }
                if (currentQuestion is FoodQuestion)
                {
                    TypeOfFood = response;
                }
                currentQuestion = currentQuestion.Selection(response);
                if (currentQuestion is FinalQuestion)
                {
                    currentQuestion = currentQuestion.Selection(TypeOfFood);
                    currentQuestion.PrintPrompt();
                    break;
                }
            }



        }





        public Chart()
        {
            Setup();
            Running = true;
        }

    }
}