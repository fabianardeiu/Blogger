﻿using System;

namespace BloggerCore.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
    }
}
