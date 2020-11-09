using System;

namespace BloggerCore.Dtos
{
    public class AddFriendDto
    {
        public Guid PersonId { get; set; }
        public Guid FriendId { get; set; }
    }
}
