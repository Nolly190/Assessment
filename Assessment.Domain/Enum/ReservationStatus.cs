using System.ComponentModel;

namespace Assessment.Domain.Enum
{
    public enum ReservationStatus
    {
        [Description("Reserved")]
        Reserved = 1,
        [Description("Free")]
        Free = 2,
        [Description("Collected")]
        Collected = 3,
    }
}
