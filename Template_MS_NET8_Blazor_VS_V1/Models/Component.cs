using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Template_MS_NET8_Blazor_VS_V1.Models
{
    public class Component
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComponentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsVisible { get; set; }
    }

    public class Components
    {
        public Collection<Component> ComponentsCollection { get; set; } = new Collection<Component>();

        public Components()                                 // constructor
        {
            MockData(ComponentsCollection);
        }

        public void MockData(Collection<Component> c)
        {
            c.Add(new Component { Name = "BottomLeft", Description = "BottomLeft", IsVisible = true });
            c.Add(new Component { Name = "BottomRight", Description = "BottomRight", IsVisible = true });
            c.Add(new Component { Name = "Branding", Description = "Branding", IsVisible = true });
            c.Add(new Component { Name = "Footer", Description = "Footer", IsVisible = true });
            c.Add(new Component { Name = "LeftBar", Description = "LeftBar", IsVisible = true });
            c.Add(new Component { Name = "MenuControl", Description = "MenuControl", IsVisible = true });
            c.Add(new Component { Name = "RightBar", Description = "RightBar", IsVisible = true });
            c.Add(new Component { Name = "StatusBar", Description = "StatusBar", IsVisible = true });
            c.Add(new Component { Name = "TopMenu", Description = "TopMenu", IsVisible = true });
        }

        public string componentStyle(string ComponentName)
        {
            int index = ComponentsCollection.Select((c, i) => new { c, i }).First(x => x.c.Name == ComponentName).i;
            Component c = ComponentsCollection[index];
            return c.IsVisible ? "display:flex" : "display:none";
        }

        public string borderStyle(string ComponentName1,string ComponentName2)
        {
            int index1 = ComponentsCollection.Select((c, i) => new { c, i }).First(x => x.c.Name == ComponentName1).i;
            int index2 = ComponentsCollection.Select((c, i) => new { c, i }).First(x => x.c.Name == ComponentName2).i;
            return ComponentsCollection[index1].IsVisible == true 
                || ComponentsCollection[index1].IsVisible == true 
                ? "border: 4px solid darkred" : "border: none";
        }
    }

}
