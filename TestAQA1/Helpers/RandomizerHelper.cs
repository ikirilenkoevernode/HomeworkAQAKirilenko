using Microsoft.Data.Sqlite;
using System;
using Tests1.DTO.DapperTestsDTO;
namespace helpers.classes
{
    public static class RandomizerHelper
    {
        public static T GetRandomItem<T>(IList<T> items)
        {
            if (items == null || items.Count == 0)
                throw new ArgumentException("Список пустой или null");
            var rnd = new Random();
            int index = rnd.Next(items.Count);
            return items[index];
        }
    }
}