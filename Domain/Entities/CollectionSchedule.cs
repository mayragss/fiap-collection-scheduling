using Domain.Enums;

namespace Domain.Entities
{
    public class CollectionSchedule : BaseEntity
    {
        public DateTime CollectionDate { get; set; }
        public int AddressId { get; set; }
        public required Address Address { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public WasteType WasteType { get; set; } = WasteType.NotIdentified;
        public CollectionScheduleStatus CollectionScheduleStatus { get; set; } = CollectionScheduleStatus.Pending;
        public string Notes { get; set; }

        public bool IsRecurring { get; set; }

        public string RecurringInterval { get; set; } // Ex. "daily", "weekly", "monthly"

        public DateTime? ConfirmationDate { get; set; }

        public DateTime? CollectionWindowStart { get; set; }

        public DateTime? CollectionWindowEnd { get; set; }
    }
}
