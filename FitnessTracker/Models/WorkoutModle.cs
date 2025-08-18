namespace FitnessTracker.Models;

public class WorkoutModel
{
    public int Id { get; set; }
    public string Exercise { get; set; } = string.Empty;
    public int Reps { get; set; }
    public int Sets { get; set; }
    public double? Weight { get; set; } 
    public DateTime Date { get; set; } = DateTime.Now;

    // For linking to user in the future
    public int UserId { get; set; }
}