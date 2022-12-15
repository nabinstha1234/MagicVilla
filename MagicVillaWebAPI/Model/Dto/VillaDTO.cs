using System.ComponentModel.DataAnnotations;

namespace MagicVillaWebAPI.Model.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
