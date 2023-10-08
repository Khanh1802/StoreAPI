using API.Entities;

namespace API.Extesions
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return query.OrderBy(x => x.Name);
            }
            query = orderBy switch
            {
                "price" => query.OrderBy(x => x.Price),
                "priceDesc" => query.OrderByDescending(x => x.Price),
            };
            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return query;
            }
            search = search.ToLower().Trim();
            return query.Where(x => x.Name.ToLower().Contains(search));
        }

        public static IQueryable<Product> Filter(this IQueryable<Product> query, string brands, string types)
        {
            var brandList = new List<string>();
            var typesList = new List<string>();
            if (!string.IsNullOrEmpty(brands))
            {
                brandList.AddRange(brands.ToLower().Split(",").ToList());
            }
            if (!string.IsNullOrEmpty(types))
            {
                typesList.AddRange(types.ToLower().Split(",").ToList());
            }
            query = query.Where(x => brandList.Count == 0 || brandList.Contains(x.Brand.ToLower()));
            query = query.Where(x => typesList.Count == 0 || typesList.Contains(x.Type.ToLower()));
            return query;
        }
    }
}
