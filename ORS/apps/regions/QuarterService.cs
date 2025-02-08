using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Dto;
using ORS.Apps.Regions.Entities;
using ORS.Apps.Regions.Models;
using ORS.core.Exceptions;
using ORS.Database;

namespace ORS.Apps.Regions;

public class QuarterService(DatabaseContext context) {
    public async Task<List<QuarterEntity>> All() {
        var models = await context.Quarters
            .OrderBy(model => model.Order)
            .ToListAsync();

        List<QuarterEntity> quarters = [];
        foreach (var model in models) {
            quarters.Add(new QuarterEntity(model));
        }

        return quarters;
    }

    public async Task<List<Neighborhood>> Neighborhoods(LangDto dto) {
        var models = await context.Quarters.ToListAsync();

        List<Neighborhood> neighborhoods = [];
        foreach (var model in models) {
            neighborhoods.Add(new Neighborhood(model, dto.Lang));
        }

        return neighborhoods;
    }

    public Neighborhood GetNeighborhoodById(int id, LangDto dto) {
        var model = context.Quarters
            .FirstOrDefault(quarter => quarter.Id == id);

        if (model == null) {
            throw new ModelNotFoundException("No neighbourhood found with given id!");
        }

        return new Neighborhood(model, dto.Lang);
    }
}