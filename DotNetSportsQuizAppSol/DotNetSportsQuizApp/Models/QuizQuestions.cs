
using System.ComponentModel.DataAnnotations;
namespace DotNetSportsQuizApp.Models
{
    public class QuizQuestions
    {
        public int QuizQuestionsId { get; set; }  // Auto-assigned Primary Key
        public string? QuestionAsked { get; set; }  // The quiz question text
        public string? Option1 { get; set; }  // Answer option 1
        public string? Option2 { get; set; }  // Answer option 2
        public string? Option3 { get; set; }  // Answer option 3
        public string? Option4 { get; set; }  // Answer option 4
        public string? RightAnswer { get; set; }  // Correct answer (1,2,3,4)

        // Foreign Key: One question belongs to one quiz
        public int SportsQuizId { get; set; }  // Foreign key to Quiz
        public SportsQuiz SportsQuiz { get; set; }  // Navigation property for the Quiz
    }

}
