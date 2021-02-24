using System.Linq;
namespace Orphanage.Models
{
    public interface INGORepository
    {
        IQueryable<Donation> Donations { get; }
        IQueryable<User> Users { get; }
        IQueryable<HomeEvent> HomeEvents { get; }
        void SaveDonation(Donation donation);
    }
}