﻿using System;

namespace BloggerDomain
{
    public class Friend : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Guid FriendId { get; set; }
    }
}
