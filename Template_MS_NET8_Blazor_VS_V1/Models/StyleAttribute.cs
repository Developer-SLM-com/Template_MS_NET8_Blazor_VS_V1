using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Template_MS_NET8_Blazor_VS_V1.Models
{
    public class StyleAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StyleAttributeId { get; set; }
        public string? Theme { get; set; }
        public string? Section { get; set; }
        public string? SubSection { get; set; }
        public string? Filter { get; set; } = "";
        public bool HighLight { get; set; } = false;
        public string? Key { get; set; }
        public string? Value { get; set; }
    }

    public class StyleAttributes
    {
        public Collection<StyleAttribute> StyleAttributesCollection { get; set; } = new Collection<StyleAttribute>();

        public StyleAttributes()                                 // constructor
        {
            MockData(StyleAttributesCollection);
        }

        public void MockData(Collection<StyleAttribute> sa)
        {
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "Container", Key = "border", Value = "solid 2px red" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "TableHeader", Key = "border", Value = "solid 2px green" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "TableRowDiv", Key = "border", Value = "solid 2px darkred" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "Branding", Key = "border", Value = "solid 2px Green" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "TopMenu", Key = "border", Value = "solid 2px darkblue" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "MenuControl", Key = "border", Value = "solid 2px orange" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "LeftBar", Key = "border", Value = "solid 2px yellow" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "Body", Key = "border", Value = "solid 2px pink" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "RightBar", Key = "border", Value = "solid 2px blue" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "BottomLeft", Key = "border", Value = "solid 2px green" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "BottomRight", Key = "border", Value = "solid 2px blue" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "StatusBar", Key = "border", Value = "solid 2px pink" });
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "Footer", Key = "border", Value = "solid 2px orange" });
        }

        public string? GetSettings(string theme, string section
            , string subsection, string filter = "", bool highlight = false)
        {
            string? result = "";
            foreach (var item in StyleAttributesCollection.
                        Where(i => (i.Filter == filter || i.Filter == "")
                        && (i.Theme == theme)
                        && (i.Section == section)
                        && (i.SubSection == subsection)
                        && (i.HighLight == false)))
            {
                result += item.Key + ":" + item.Value + "; ";
                if (highlight == true) // add highlight settings
                {
                    foreach (var highlightitem in StyleAttributesCollection.
                        Where(i => (i.Filter == filter || i.Filter == "")
                        && (i.Theme == theme)
                        && (i.Section == section)
                        && (i.SubSection == subsection)
                        && (i.HighLight == true)))
                    {
                        result += highlightitem.Key + ":" + highlightitem.Value + "; ";
                    }
                }
            }
            Console.WriteLine("GetSettings.result: " + result);
            return result;
        }

    }
}
