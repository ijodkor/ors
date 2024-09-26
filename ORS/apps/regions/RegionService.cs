using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Entities;
using ORS.core.Exceptions;
using ORS.Database;

namespace ORS.Apps.Regions;

public class RegionService(DatabaseContext context) {
    public async Task<List<RegionEntity>> All() {
        var models = await context.Regions.ToListAsync();

        List<RegionEntity> regions = [];
        foreach (var model in models) {
            regions.Add(new RegionEntity(model));
        }

        return regions;
    }

    public async Task<List<Province>> Provinces() {
        var models = await context.Regions
            .Where(region => region.ParentId == null)
            .ToListAsync();

        List<Province> provinces = [];
        foreach (var model in models) {
            provinces.Add(new Province(model));
        }

        return provinces;
    }

    public Province GetProvinceById(int id) {
        var model = context.Regions
            .FirstOrDefault(region => region.Id == id && region.ParentId == null);

        if (model == null) {
            throw new ModelNotFoundException("No province found with given id!");
        }

        return new Province(model);
    }

    public async Task<List<District>> Districts(int provinceId) {
        var models = await context.Regions
            .Where(region => region.ParentId == provinceId)
            .ToListAsync();

        List<District> districts = [];
        foreach (var model in models) {
            districts.Add(new District(model));
        }

        return districts;
    }

    public District GetDistrictById(int districtId) {
        var model = context.Regions
            .FirstOrDefault(region => region.Id == districtId && region.ParentId != null);

        return model == null
            ? throw new ModelNotFoundException("District not found with given id!")
            : new District(model);
    }
}