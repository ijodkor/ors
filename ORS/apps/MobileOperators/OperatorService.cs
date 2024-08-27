using ORS.apps.MobileOperators.Models;
using ORS.Database;

namespace ORS.apps.MobileOperators;

public class OperatorService(DatabaseContext _db) {

    public async Task<List<MobileOperator>> All() {
        return [];
    }
}