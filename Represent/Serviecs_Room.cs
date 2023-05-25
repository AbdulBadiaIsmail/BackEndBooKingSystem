using Booking_System.DTO;
using Booking_System.Models;
using Booking_System.Represent.Equaloperator;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace Booking_System.Represent
{
    public class Serviecs_Room : Room_context

    {
        BookingContext Db;
        private DTO_Room DTO;
      ///*  private readonly IWebHostEnvironment webHost*/;
        public Serviecs_Room(BookingContext context)
        {
                this.Db = context;
             this.DTO = new DTO_Room();   
        }
        public void  Add(DTOAddRoom entity)
        {

               Room room = new Room();               
              room.Image = UploadFile.getPath(entity.image_path);
                room.Room_Dec = entity.Room_Des;
                room.Price = entity.Price;
               room.Room_type = entity.TypeName;
            room.B_id = entity.B_id;
                 room.Availability = 0;
                Db.Add(room);
                Db.SaveChanges();
                  
        }

        public void Delete(int Entity)
        {
            var room = Db.Rooms.Find(Entity);
            Db.Rooms.Remove(room);
            UploadFile.RemoveFile(room.Image);
            Db.SaveChanges();   

        }

        public List<DTOGetRoom> GetAll()
        {
            var rooms = Db.Rooms.Select(x => new DTOGetRoom
            {
                Number_Ro = x.Room_id,
                TypeName = x.Room_type,
                Price = x.Price,
                Room_Des = x.Room_Dec,
                image_Name = x.Image,
                BranchName = x.Branch.B_Name,
                Avalable =x.Availability.Value 


            }).ToList();
            return rooms;
        }

        public DTOGetRoom GetByID(int id)
        {

            var room = Db.Rooms.Select(x => new DTOGetRoom
            {
                Room_Des = x.Room_Dec,
                Number_Ro = x.Room_id,
                image_Name = x.Image,
                BranchName = x.Branch.B_Name,
                Price = x.Price,
                Avalable=x.Availability.Value,
                TypeName = x.Room_type, 

            }).FirstOrDefault(x=>x.Number_Ro ==id);
            return room;

        }

        public void Update(int id, DTO_Room entity)
        {
            var  room = Db.Rooms.Find(id);
            room.Room_id = entity.Number_Ro;
          
            room.Price = entity.Price;
     
            room.Availability = entity.Avalable;
            room.Room_Dec = entity.Room_Des;
            room.Room_type =entity.TypeName;
            room.Image = UploadFile.getPath(entity.image_path);
            Db.Update(room);
            Db.SaveChanges();   
        }

        public List<DTOGetRoom> getRoombyName(int available)
        {
            var room = Db.Rooms.Where(x => x.Availability == available).Select(x=>new
            DTOGetRoom
            {
                    image_Name=x.Image, 
                    Price = x.Price,
                   Room_Des = x.Room_Dec,
                   TypeName = x.Room_type,
                    Number_Ro = x.Room_id,
                    BranchName = x.Branch.B_Name,
                   Avalable =x.Availability.Value
                  
            })
                .ToList();
            return room;


        }

        public List<DTOGetRoom> getRoomAvailable()
        {
            var room = Db.Rooms.Where(x => x.Availability == 0).Select(x => new DTOGetRoom
            {
                Number_Ro = x.Room_id,
                BranchName = x.Branch.B_Name,
                Avalable = x.Availability.Value,
                Price = x.Price,
                Room_Des = x.Room_Dec,
                TypeName = x.Room_type,

            }).ToList();
            return room;
        }
    }
}
