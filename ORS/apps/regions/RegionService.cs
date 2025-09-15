using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Dto;
using ORS.Apps.Regions.Entities;
using ORS.core.Exceptions;
using ORS.Database;

namespace ORS.Apps.Regions;

public class RegionService(DatabaseContext context) {
    public async Task<List<RegionEntity>> All() {
        var models = await context.Regions
            .Where(region => region.DeletedAt == null)
            .OrderBy(region => region.Order)
            .ToListAsync();

        List<RegionEntity> regions = [];
        foreach (var model in models) {
            regions.Add(new RegionEntity(model));
        }

        return regions;
    }

    public async Task<List<Province>> Provinces(LangDto dto) {
        var models = await context.Regions
            .Where(region => region.ParentId == null)
            .OrderBy(model => model.Order)
            .ThenBy(model => model.Id)
            .ToListAsync();

        List<Province> provinces = [];
        foreach (var model in models) {
            provinces.Add(new Province(model, dto.Lang));
        }

        return provinces;
    }

    public async Task<List<District>> Districts(int provinceId, LangDto dto) {
        var models = await context.Regions
            .Where(region => region.ParentId == provinceId && region.DeletedAt == null)
            .OrderBy(region => region.Id)
            .ToListAsync();

        List<District> districts = [];
        foreach (var model in models) {
            districts.Add(new District(model, dto.Lang));
        }

        return districts;
    }

    public District FindById(int id, LangDto dto) {
        var model = context.Regions
            .FirstOrDefault(region => region.Id == id);

        return model == null
            ? throw new ModelNotFoundException("Region is not found with given id!")
            : new District(model, dto.Lang);
    }

    public District GetByLocation(float lat, float lon, LangDto query) {
        // Multiline
        var model = context.Regions
            .FromSqlRaw(@"
                SELECT *, 6371 * 2 * ASIN(
                    SQRT(
                        POWER(SIN(RADIANS(({0} - latitude) / 2)), 2) +
                        COS(RADIANS(latitude)) * COS(RADIANS({0})) *
                        POWER(SIN(RADIANS(({1} - longitude) / 2)), 2)
                    )
                ) AS distance
                from regions where parent_id is not null
                order by distance
            ", lat, lon)
            .FirstOrDefault();
        return model == null
            ? throw new ModelNotFoundException("District not found with given id!")
            : new District(model, query.Lang);
    }
}
