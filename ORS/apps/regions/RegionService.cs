using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Entities;
using ORS.Database;

namespace ORS.Apps.Regions;

public class RegionService(DatabaseContext _context) {
    private readonly DatabaseContext db = _context;

    public async Task<List<Province>> Provinces() {
        var regions = await db.Regions
            .Where(region => region.ParentId == null)
            .ToListAsync();

        List<Province> provinces = [];
        foreach (var region in regions) {
            provinces.Add(new Province(region));
        }

        return provinces;
    }

    public async Task<List<District>> Districts(int provinceId) {
        var regions = await db.Regions
            .Where(region => region.ParentId == provinceId)
            .ToListAsync();

        List<District> districts = [];
        foreach (var region in regions) {
            districts.Add(new District(region));
        }

        return districts;
    }
}