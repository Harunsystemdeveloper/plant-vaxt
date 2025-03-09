﻿using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
    }
}
