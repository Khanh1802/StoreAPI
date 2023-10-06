﻿using Microsoft.EntityFrameworkCore;

namespace API.RequestHelpers
{
    public class PageList<T> : List<T>
    {
        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData()
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = (int)(Math.Ceiling((double)count / pageSize))
            };
            AddRange(items);
        }
        public MetaData MetaData { get; set; }
        public static async Task<PageList<T>> ToPageListAsync(IQueryable<T> query,
            int pageNumber, int pageSize)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((pageNumber -1) * pageSize).Take(pageSize).ToListAsync();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
