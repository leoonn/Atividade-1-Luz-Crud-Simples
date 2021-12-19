using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_1_Luz
{
    public class DataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public DataItem(int id, string name, string category, string description, double price )
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }
    }
}
