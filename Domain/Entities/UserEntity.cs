﻿namespace Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }
    }
}
