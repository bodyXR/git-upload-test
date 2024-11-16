using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace quiz
{
    class Answer {
        public string title {get;set;}
        public bool correctAnswer { get; set; }
    }
    class Question
    {
        public string title { get; set; }
        public List<Answer> answers { get; set; }
        public string selectedAnswer { get; set; }
    }
    public partial class Quiz : Page
    {
        int selectedQuestion = 0;

        List<Answer> answers1 = new List<Answer>();
        List<Answer> answers2 = new List<Answer>();
        List<Answer> answers3 = new List<Answer>();
        List<Answer> answers4 = new List<Answer>();
        Question question1 = new Question() {title="Which proggraming language used to develop website interfaces?" };
        Question question2 = new Question() {title= "What is the correct syntax to output \"Hello, World!\" in Python?" };
        Question question3 = new Question() {title= "Which of the following is a looping structure in JavaScript?" };
        Question question4 = new Question() {title= "Which keyword is used to define a variable in JavaScript?" };
        List<Question> questions = new List<Question>();
        public void ChooseAnswer(object sender, RoutedEventArgs e)
        {
            questions[selectedQuestion].selectedAnswer = sender.ToString().Split(' ')[1].Remove(0, 8);
        }
        public void addData() 
        {
            answers1.Add(new Answer() { title = "C#", correctAnswer = false });
            answers1.Add(new Answer() { title = "C++", correctAnswer = false });
            answers1.Add(new Answer() { title = "Html", correctAnswer = true });
            answers1.Add(new Answer() { title = "Pythone", correctAnswer = false });
            question1.answers = answers1;
            questions.Add(question1);

            answers2.Add(new Answer() { title = "console.log(\"Hello,World!\")", correctAnswer = false });
            answers2.Add(new Answer() { title = "print(\"Hello,World!\")", correctAnswer = true });
            answers2.Add(new Answer() { title = "echo\"Hello,World!\"", correctAnswer = false });
            answers2.Add(new Answer() { title = "System.out.println(\"Hello,World!\")", correctAnswer = false });
            question2.answers = answers2;
            questions.Add(question2);

            answers3.Add(new Answer() { title = "while", correctAnswer = true });
            answers3.Add(new Answer() { title = "select", correctAnswer = false });
            answers3.Add(new Answer() { title = "case", correctAnswer = false });
            answers3.Add(new Answer() { title = "switch", correctAnswer = false });
            question3.answers = answers3;
            questions.Add(question3);

            answers4.Add(new Answer() { title = "let", correctAnswer = false });
            answers4.Add(new Answer() { title = "var", correctAnswer = false });
            answers4.Add(new Answer() { title = "const", correctAnswer = false });
            answers4.Add(new Answer() { title = "All", correctAnswer = true });
            question4.answers = answers4;
            questions.Add(question4);
        }

        void assignDataContext(int index)
        {
            DataContext = questions[index];
            questionGuide.Content = $"question {index + 1} of {questions.Count()}";
        }
        public Quiz()
        {
            InitializeComponent();
            addData();
            assignDataContext(selectedQuestion);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuestion + 1 < questions.Count())
            {
                selectedQuestion++;
                assignDataContext(selectedQuestion);
            }
            else
            {
                MessageBox.Show("This is the last question");
            }
            answer1.IsChecked = false;
            answer2.IsChecked = false;
            answer3.IsChecked = false;
            answer4.IsChecked = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedQuestion-1 != -1)
            {
                selectedQuestion--;
                assignDataContext(selectedQuestion);
            }
            else
            {
                MessageBox.Show("This is the first question");
            }
            answer1.IsChecked = false;
            answer2.IsChecked = false;
            answer3.IsChecked = false;
            answer4.IsChecked = false;

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int totalScore = 0;
            for (int i = 0; i < questions.Count(); i++)
            {
                for (int j = 0; j < questions[i].answers.Count(); j++)
                {
                    //Html 
                    if (questions[i].selectedAnswer == questions[i].answers[j].title && questions[i].answers[j].correctAnswer) {
                        totalScore++;
                    }
                }
            }
            Result result = new Result(totalScore, questions.Count());
            NavigationService.Navigate(result);
        }
    }
}
