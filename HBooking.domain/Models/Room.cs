﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBooking.domain
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RooNumber { get; set; }
        public int surface { get; set;}
        public bool NeedsRepair { get; set; }

    }
}
