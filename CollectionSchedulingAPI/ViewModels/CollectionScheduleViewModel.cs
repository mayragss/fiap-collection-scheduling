using Domain.Enums;
using Presentation.Dtos;

namespace CollectionSchedulingAPI.ViewModels;

public class CollectionScheduleViewModel
{
    public CollectionScheduleViewModel() { }
    public string Cep { get; set; }
    public string Street { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public int? Number { get; set; }
    public int Complement { get; set; }
    public DateTime CollectionDate { get; set; }
    public required int UserId { get; set; }
    public WasteType WasteType { get; set; } = WasteType.NotIdentified;
    public CollectionScheduleStatus CollectionScheduleStatus { get; set; } = CollectionScheduleStatus.Pending;
    public string Notes { get; set; }
     

    public bool IsRecurring { get; set; }

    public string RecurringInterval { get; set; } // Ex. "daily", "weekly", "monthly"

    public DateTime? ConfirmationDate { get; set; }

    public DateTime? CollectionWindowStart { get; set; }

    public DateTime? CollectionWindowEnd { get; set; }
}
