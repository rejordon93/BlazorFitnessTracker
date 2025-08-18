namespace FitnessTracker.Models;

public class NutritionModel
{
    public int Id { get; set; }
    public string Food { get; set; } = string.Empty;
    public int Calories { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public int UserId { get; set; }
}