using pmesp.Domain.Entities.Bandits;

namespace pmesp.Domain.Entities.SocialMedias;

public class SocialMedia
{
    public string Id { get; private set; }
    public string? Link { get; private set; }
    public string? Platform { get; private set; }
    public string? Owner { get; private set; }
    public DateTime InsertDate { get; private set; }
    public string BanditId { get; set; }
    public Bandit Bandit { get; set; }

    public SocialMedia(string id, string link, string platform, string owner, DateTime insertDate)
    {
        Id = id;
    }

    public void validateDomain(string link, string platform, string owner, DateTime insertDate)
    {
        Link = link;
        Platform = platform;
        Owner = owner;
        InsertDate = insertDate;
    }
}
