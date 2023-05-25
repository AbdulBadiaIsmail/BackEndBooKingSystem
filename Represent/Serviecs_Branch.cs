using Booking_System.DTO;
using Booking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace Booking_System.Represent
{
    public class Serviecs_Branch :Branch_context

    {
        BookingContext Db;
        private DTO_Branch TO_Branch;
        public Serviecs_Branch(BookingContext context)
        {
                this.Db = context;
        
        }
        public void  Add(DTO_Branch entity)
        {

                  Branch branch = new Branch();
               branch.B_Phone = entity.B_Phone;        
               branch.B_Name = entity.B_Name;  
              branch.Hotal_code = entity.H_Code;
              branch.B_Loaction =entity.B_Location;   
              if (entity !=null)
               {
                Db.Add(branch); 
                Db.SaveChanges();
               }

                  
        }

        public void Delete(int Entity)
        {
            var b = Db.Branches.Find(Entity);
            Db.Remove(b);
            Db.SaveChanges();

        }

        public List<DTO_Branch> GetAll()
        {
            var branches = Db.Branches.Include(x => x.Hotal).
                Select(x=>new DTO_Branch
                {
                    B_Phone = x.B_Phone,    
                    B_Name = x.B_Name,  
                    B_id = x.B_Id,
                    B_Location  = x.B_Loaction,
                    H_Name = x.Hotal.Name,
                    H_Code =x.Hotal_code,
                }).ToList();


            return branches;
        }

        public DTO_Branch GetByID(int id)
        { 
            TO_Branch = new DTO_Branch();
            var branch = Db.Branches.Find(id);
               TO_Branch.B_Phone = branch.B_Phone;
            TO_Branch.B_id = branch.B_Id;
            TO_Branch.B_Location = branch.B_Loaction;
            TO_Branch.H_Name = branch.Hotal.Name;   
              
             return TO_Branch;
        }

        public void Update(int id, DTO_Branch entity)
        {
            var b = Db.Branches.Find(id);
            b.B_Phone = entity.B_Phone; 
            b.B_Name=entity.B_Name;
            b.Hotal_code = entity.H_Code;
            b.B_Loaction = entity.B_Location;
            b.B_Id = entity.B_id;
            Db.Update (b);
            Db.SaveChanges();

        }


        
    }
}
