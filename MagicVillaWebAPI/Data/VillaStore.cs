using MagicVillaWebAPI.Model.Dto;

namespace MagicVillaWebAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
            {
                new VillaDto{Id= 1, Name="hello", Occupancy="hello", Sqft=34},
                new VillaDto{Id= 2,Name="hello2", Occupancy="hello1", Sqft=35}
            };
    }
}
