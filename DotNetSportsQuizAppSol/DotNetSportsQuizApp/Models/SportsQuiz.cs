namespace DotNetSportsQuizApp.Models
{
    public class SportsQuiz
    {
        public int SportsQuizId { get; set; }  // Auto-assigned Primary Key
        public string? QuizTitle { get; set; }  // Title of the quiz
        public string? SportType { get; set; }  // Type of sport 
        public string? QuizCreatedBy { get; set; }  // User who created the quiz
        public DateTime CreatedDate { get; set; }  // Date of quiz creation
        public List<QuizQuestions>? QuizQuestions { get; set; } // For one to many relationships
    }
}
