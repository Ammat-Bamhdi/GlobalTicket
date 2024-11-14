namespace GlobalTicket.Application.Features.Events.Queries.GetEventList;

public class EventListViewModel
{
    public Guid EventId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Data { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}