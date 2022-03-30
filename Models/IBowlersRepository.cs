﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13MySQLDB.Models
{
    public interface IBowlersRepository
    {

        IQueryable<Bowler> Bowlers { get; }

        IQueryable<Team> Teams { get; }

        public void Delete(Bowler bowler);

        //add or edit appointment
        public void DoAppointment(Bowler bowler);
    }
}
