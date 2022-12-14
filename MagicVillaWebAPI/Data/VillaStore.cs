using MagicVillaWebAPI.Model.Dto;

namespace MagicVillaWebAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
            {
                new VillaDto{Id= 1, Name="hello"},
                new VillaDto{Id= 2,Name="hello2"}
            };
    }
}
