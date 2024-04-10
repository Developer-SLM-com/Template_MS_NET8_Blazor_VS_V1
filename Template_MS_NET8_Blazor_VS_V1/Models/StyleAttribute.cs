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
            sa.Add(new StyleAttribute { Theme = "default", Section = "MainLayout", SubSection = "Container", Key = "border", Value = "solid 1px red" });
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
            return result;
        }

    }
}
