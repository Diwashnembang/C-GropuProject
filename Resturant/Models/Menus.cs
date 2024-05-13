namespace Resturant.Models
{
    public class Menus
    {
        public int MenusId { get; set; }
        public string MenuType { get; set; }
       public virtual ICollection<MenuItems> MenuItems { get; set; } = new List<MenuItems>();
      

    }
}
 