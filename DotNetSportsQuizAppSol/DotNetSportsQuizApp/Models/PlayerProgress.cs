using System.ComponentModel.DataAnnotations;

namespace DotNetSportsQuizApp.Models
{
    public class PlayerProgress
    {
        public int PlayerProgressId { get; set; }  // Auto-assigned Primary Key

        public string? PlayerName { get; set; }  // Name of the user
        public int? CurrentScore { get; set; }  // Current score of the user
        public int? TotalQuestions { get; set; }  // Total number of questions answered
        public int? CorrectAnswers { get; set; }  // Total number of correct answers

        // Foreign Key: Progress tracked for a specific quiz
        public int SportsQuizId { get; set; }  // Foreign key to Quiz
        public SportsQuiz SportsQuiz { get; set; }  // Navigation property for the Quiz
    }

}
