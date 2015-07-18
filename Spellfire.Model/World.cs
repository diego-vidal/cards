using System.ComponentModel.DataAnnotations;

namespace Spellfire.Model
{
    public class World
    {
        private string _imagePath = "";

        [Key]
        public WorldKey WorldKey { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }
        [Required, StringLength(8)]
        public string ShortName { get; set; }
        [Required, StringLength(32)]
        public string ImagePath
        {
            get
            {
                switch (_imagePath)
                {
                    case "blank.gif":
                    case "dr.gif":
                    case "ns.gif":
                        return _imagePath;
                    case "add2.gif":
                        return "add2.png";
                    case "add.gif":
                        return "add.png";
                    default:
                        return _imagePath.Substring(0, 2) + ".png";
                }
            }
            set
            {
                _imagePath = value;
            }
        }
    }
}
