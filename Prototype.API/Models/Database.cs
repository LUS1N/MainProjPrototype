﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.API.Models
{
    public class Database : DatabaseEntity, IServerChild, IOwnerIdd
    {
        public int ServerId { get; set; }
        public int OwnerId { get; set; }
    }
}
