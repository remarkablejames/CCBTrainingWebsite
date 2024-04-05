using TrainingWebsite.Domain.Shared;

namespace TrainingWebsite.Domain;

public class Training: BaseEntityModel
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public string NameEn { get; set; }
    public string DescriptionEn { get; set; }
    public string NameFr { get; set; }
    public string DescriptionFr { get; set; }
    public int CategoryID { get; set; }
    public int AudienceID { get; set; }
    public int ClassificationID { get; set; }
    public string Location { get; set; }
    // public string Trainer { get; set; }
    // public int Capacity { get; set; }
    // public int AvailableSeats { get; set; }
    // public bool IsCanceled { get; set; }
    // public bool IsFull { get; set; }
    // public bool IsStarted { get; set; }
    // public bool IsFinished { get; set; }
    // public bool IsClosed { get; set; }
    // public bool IsOpen { get; set; }
    // public bool IsUpcoming { get; set; }
    // public bool IsPast { get; set; }
    // public bool IsAvailable { get; set; }
    // public bool IsUnavailable { get; set; }
    // public bool IsCancelled { get; set; }
    // public bool IsNotCancelled { get; set; }
    // public bool IsFullAndCancelled { get; set; }
    // public bool IsNotFullAndCancelled { get; set; }
    // public bool IsFullAndNotCancelled { get; set; }
    // public bool IsNotFullAndNotCancelled { get; set; }
    // public bool IsStartedAndCancelled { get; set; }
    // public bool IsNotStartedAndCancelled { get; set; }
    // public bool IsStartedAndNotCancelled { get; set; }
    // public bool IsNotStartedAndNotCancelled { get; set; }
    // public bool IsFinishedAndCancelled { get; set; }
    // public bool IsNotFinishedAndCancelled { get; set; }
    // public bool IsFinishedAndNotCancelled { get; set; }
    // public bool IsNotFinishedAndNotCancelled { get; set; }
    // public bool IsClosedAndCancelled { get; set; }
    // public bool IsNotClosedAndCancelled { get; set; }
    // public bool IsClosedAndNotCancelled { get; set; }
    // public bool IsNotClosedAndNotCancelled { get; set; }
    // public bool IsOpenAndCancelled { get; set; }
    // public bool IsNotOpenAndCancelled { get; set; }
    // public bool IsOpenAndNotCancelled { get; set; }
    // public bool IsNotOpenAndNotCancelled { get; set; }
    // public bool IsUpcomingAndCancelled { get; set; }

}