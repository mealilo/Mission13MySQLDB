using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13MySQLDB.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {

        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository(BowlersDbContext temp)
        {
            _context = temp;
        }



        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;

        public void Delete(Bowler bowler)
        {
            _context.Remove(bowler);
            _context.SaveChanges();
        }

        public void DoAppointment(Bowler bowler)
        {
            if (bowler.BowlerID == 0)
            {
                _context.Bowlers.Add(bowler);
            }
            else
            {
                _context.Update(bowler);
            }

            _context.SaveChanges();
        }
    }
}
