using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Dto;
using ORS.Apps.Regions.Entities;
using ORS.core.Exceptions;
using ORS.Database;

namespace ORS.Apps.Regions;

public class QuarterService(DatabaseContext context) {
    public async Task<List<QuarterEntity>> All(EntityListDto dto) {
        var models = await context.Quarters
            .OrderBy(model => model.Order)
            .Skip((dto.Page - 1) * dto.Limit)
            .Take(dto.Limit)
            .ToListAsync();

        List<QuarterEntity> quarters = [];
        foreach (var model in models) {
            quarters.Add(new QuarterEntity(model));
        }

        return quarters;
    }

    public async Task<object> GetMeta(EntityListDto dto) {
        int count = await context.Quarters
            .CountAsync();
        
        int pages = count / dto.Limit;
        int previous = dto.Page > 1 ? dto.Page - 1 : 1;
        int last = pages > 1 ? pages : 1;

        return new {
            previous,
            current = dto.Page,
            last,
            limit = dto.Limit,
            pages,
            total = count
        };
    }

    public async Task<List<Neighborhood>> Neighborhoods(LangDto dto) {
        var models = await context.Quarters
            .OrderBy(model => model.Order)
            .Take(200)
            .ToListAsync();

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