using FamilyAlbum.Models;

namespace FamilyAlbum.Database
{
    public class FriendRepository : IFriendRepository
    {
        private readonly ApplicationContext context;
        public FriendRepository(ApplicationContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));
            this.context = context;
        }
        public async Task SaveFriend(Friend friend)
        {
            var oldFriend = context.Friends.FirstOrDefault(x => x.UserId == friend.UserId && x.Id == friend.Id);
            if (oldFriend == null) 
            {
                context.Friends.Add(friend);
                await context.SaveChangesAsync();
            }
        }
    }
}
