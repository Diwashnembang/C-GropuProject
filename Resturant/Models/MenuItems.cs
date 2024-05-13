using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Models
{
    public class MenuItems
    {
        public int MenuItemsId { get; set; }
        public string Name {  get; set; }
        public decimal Price { get; set; }
        public int MenusId {  get; set; }
        public  Menus Menus { get; set; } = null!;
    }
}
