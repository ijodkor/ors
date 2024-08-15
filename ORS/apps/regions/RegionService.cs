using Microsoft.EntityFrameworkCore;
using ORS.Apps.Regions.Entities;
using ORS.Database;

namespace ORS.Apps.Regions;

public class RegionService(DatabaseContext _context) {
    private readonly DatabaseContext db = _context;

    public async Task<List<Province>> Provinces() {
        var regions = await db.Regions.ToListAsync();

        await Task.Run(() => { });

        List<Province> provinces = [];
        foreach (var region in regions) {
            provinces.Add(new Province(region.Id, region.Name));
        }

        return provinces;
    }

    public async Task<List<District>> Districts() {
        var regions = await db.Regions.ToListAsync();

        List<District> districts = [];
        foreach (var region in regions) {
            districts.Add(new District(region.Id, region.Name, region.Id));
        }

        return districts;
    }
}