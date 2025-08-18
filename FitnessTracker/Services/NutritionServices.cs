using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services;

public class NutritionService
{
    private readonly FitnessContext _context;

    public NutritionService(FitnessContext context)
    {
        _context = context;
    }

    public async Task<List<NutritionModel>> GetAllNutritionAsync()
        => await _context.Nutritions.ToListAsync();

    public async Task AddNutritionAsync(NutritionModel nutrition)
    {
        _context.Nutritions.Add(nutrition);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNutritionAsync(NutritionModel nutrition)
    {
        var existing = await _context.Nutritions.FindAsync(nutrition.Id);
        if (existing != null)
        {
            existing.Food = nutrition.Food;
            existing.Calories = nutrition.Calories;
            existing.Date = nutrition.Date;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteNutritionAsync(int id)
    {
        var nutrition = await _context.Nutritions.FindAsync(id);
        if (nutrition != null)
        {
            _context.Nutritions.Remove(nutrition);
            await _context.SaveChangesAsync();
        }
    }
}