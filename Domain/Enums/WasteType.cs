using System.ComponentModel;

namespace Domain.Enums
{
    public enum WasteType
    {
        [Description("Orgânico")]
        Organic = 0,
        [Description("Reciclável")]
        Recyclable = 1,
        [Description("Perigoso")]
        Hazardous = 2,
        [Description("Eletrônico")]
        Electronic = 3,
        [Description("Construção")]
        Construction = 4,
        [Description("Medicinal")]
        Medical = 5,
        [Description("Industrial")]
        Industrial = 6,
        [Description("Não Identificado")]
        NotIdentified = 7
    }
}
