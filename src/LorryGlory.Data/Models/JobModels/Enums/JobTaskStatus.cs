namespace LorryGlory.Data.Models.JobModels.Enums
{
    public enum JobTaskStatus
    {
        // Initial state
        New = 0,

        // Pre-execution states (100-200)
        Assigned = 100,

        // Active states (200-500)
        InProgress = 200,
        PickedUp = 300,
        InTransit = 400,
        AtDestination = 500,

        // Completion states (600-699)
        Delivered = 600,
        Success = 666,

        // Terminal states (700+)
        Cancelled = 700,
        Failed = 800,
        Delayed = 900
    }
}
