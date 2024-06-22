using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikhalevich20331.ZooshopDomain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // id 
        public string Name { get; set; } // название 
        public string Description { get; set; } // описание 

        public string? Image { get; set; } // имя файла изображения 

        // Навигационные свойства
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
