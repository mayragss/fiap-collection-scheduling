
using System.ComponentModel;

namespace Domain.Enums
{
    public enum CollectionScheduleStatus
    {
        [Description("Pendente")]
        Pending = 0,
        [Description("Agendado")]
        Scheduled = 1,
        [Description("Coletado")]
        Collected = 3,
        [Description("Erro na coleta")]
        ErrorOnCollection = 4,
    }
}
