using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Dtos;

public class CollectionScheduleDto
{
    public CollectionScheduleDto() { }
    public CollectionScheduleDto(
        string cep,
        string street,
        string state,
        string city,
        int number,
        int complement,
        DateTime collectionData,
        int userId,
        WasteType wasteType,
        CollectionScheduleStatus collectionScheduleStatus,
        string notes,
        bool isRecurring,
        string recurringInterval,
        DateTime? confirmationDate,
        DateTime? collectionWindowStart,
        DateTime? collectionWindowEnd
        )
    {
        CollectionDate = collectionData;
        Address = new()
        {
            Cep = cep,
            Street = street,
            State = state,
            City = city,
            Number = number,
            Complement = complement
        };

        UserId = userId;
        WasteType = wasteType;
        CollectionScheduleStatus = collectionScheduleStatus;
        Notes = notes;
        IsRecurring = isRecurring;
        RecurringInterval = recurringInterval;
        ConfirmationDate = confirmationDate;
        CollectionWindowStart = collectionWindowStart;
        CollectionWindowEnd = collectionWindowEnd;
    }
    public DateTime CollectionDate { get; set; }
    public AddressDto Address { get; set; }
    public int UserId { get; set; }
    public WasteType WasteType { get; set; } = WasteType.NotIdentified;
    public CollectionScheduleStatus CollectionScheduleStatus { get; set; } = CollectionScheduleStatus.Pending;
    public string Notes { get; set; }
    

    public bool IsRecurring { get; set; }

    public string RecurringInterval { get; set; } // Ex. "daily", "weekly", "monthly"

    public DateTime? ConfirmationDate { get; set; }

    public DateTime? CollectionWindowStart { get; set; }

    public DateTime? CollectionWindowEnd { get; set; }
}
