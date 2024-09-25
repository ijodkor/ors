using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Entities;
using ORS.Database;

namespace ORS.Apps.Regions;

public class RegionService(DatabaseContext _context) {
    private readonly DatabaseContext db = _context;

    public async Task<List<RegionEntity>> All() {
        var models = await db.Regions.ToListAsync();

        List<RegionEntity> regions = [];
        foreach (var model in models) {
            regions.Add(new RegionEntity(model));
        }

        return regions;
    }

    public async Task<List<Province>> Provinces() {
        var models = await db.Regions
            .Where(region => region.ParentId == null)
            .ToListAsync();

        List<Province> provinces = [];
        foreach (var model in models) {
            provinces.Add(new Province(model));
        }

        return provinces;
    }

    public async Task<Province?> GetProvinceById(int provinceId) {
        var model = await db.Regions.FindAsync(provinceId);
        if (model == null) {
            return model;
        }
        
        return new Province(model);
    }

    public async Task<List<District>> Districts(int provinceId) {
        var models = await db.Regions
            .Where(region => region.ParentId == provinceId)
            .ToListAsync();

        List<District> districts = [];
        foreach (var model in models) {
            districts.Add(new District(model));
        }

        return districts;
    }

    public async Task<District?> GetDistrictById(int districtId) {
        var model = await db.Regions
            .Where(region => region.Id == districtId && region.ParentId == null)
            .FirstOrDefaultAsync();

        return model == null ? null : new District(model);
    }
}
