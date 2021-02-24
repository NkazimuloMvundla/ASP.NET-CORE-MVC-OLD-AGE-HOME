using System.Linq;
namespace Orphanage.Models
{
    public class EFNGORepository : INGORepository
    {
        private NGODbContext context;
        public EFNGORepository(NGODbContext ctx)
        {
            context = ctx;
        }

        public void SaveDonation(Donation donation)
        {
                context.Donations.Add(donation);
                context.SaveChanges();
        }
        public IQueryable<Donation> Donations => context.Donations;
        public IQueryable<User> Users => context.Users;
        public IQueryable<HomeEvent> HomeEvents => context.HomeEvents;
        public IQueryable<Volunteer> Volunteers => context.Volunteers;
    }
}