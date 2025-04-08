using OptraxDAL.Models.Grow;

namespace OptraxMVC.Areas.Grow.Models
{
    public class PlantTraitComparer : IEqualityComparer<PlantTrait>
    {
        public bool Equals(PlantTrait? x, PlantTrait? y)
        {
            if (x == null || y == null) return false;

            var xOptions = x.SelectedOptions.Select(o => o.Id).OrderBy(id => id);
            var yOptions = y.SelectedOptions.Select(o => o.Id).OrderBy(id => id);

            return x.DefinitionId == y.DefinitionId &&
                   x.Value == y.Value &&
                   xOptions.SequenceEqual(yOptions);
        }

        public int GetHashCode(PlantTrait obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.DefinitionId.GetHashCode();
                hash = hash * 23 + (obj.Value?.GetHashCode() ?? 0);
                foreach (var id in obj.SelectedOptions.Select(o => o.Id).OrderBy(i => i))
                    hash = hash * 23 + id.GetHashCode();
                return hash;
            }
        }
    }
}
