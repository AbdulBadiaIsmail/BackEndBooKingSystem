using Booking_System.DTO;
using Booking_System.Migrations;
using Booking_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;

namespace Booking_System.Represent
{
    public class Booking_Services : BooKing_Contexts
    {
        BookingContext DB;
        public Booking_Services(BookingContext context)
        {
            this.DB = context;
        }
                 #region Post
        public int Add(DTOAddBookincs bookincs)
        {
            if (bookincs.Datestart >= bookincs.Dateend)
            {
                Booking b = new Booking();
                List<Room> rooms = updateAvail((List<DTORoomusingBookin>)bookincs.Room);
                
                   
                        b.Rooms = rooms;
                        b.Data_start = bookincs.Datestart;
                        b.Date_End = bookincs.Dateend;
                        b.Guet_id = bookincs.Gust_id;
                        if (countreBooking(bookincs.Gust_id) > 1)
                        {
                            b.Totalprice = Discount(rooms);
                            DB.Add(b);
                            DB.SaveChanges();
                        }
                        else
                        {
                            b.Totalprice = NoDiscount(rooms);
                            DB.Add(b);
                            DB.SaveChanges();
                        }


                return 1;
                



            }
            else
            {
                return 0;
            }
        }

        #endregion
                #region  Update
        public int Update(int id, DTOUpdateBooking booking)
        {
            var D = DB.Bookings.Find(id);
            List<Room> NewRoom;
            if (booking.Room_id.Count == booking.Room_id.Count)
            {
                D.Data_start = booking.Datestart;
                D.Date_End = booking.DateEnd;
                D.Guet_id = booking.Gust_id;
                DB.Update(D);
                DB.SaveChanges();
                return 1;
            }
            else if (D.Rooms.Count < booking.Room_id.Count)
            {

                NewRoom = increasedcountRoom(booking.Room_id);
                D.Data_start = booking.Datestart;
                D.Date_End = booking.DateEnd;
                D.Guet_id = booking.Gust_id;
                D.Rooms = NewRoom;
                int Count = D.Guest.Counter;
                if (Count > 1)
                {
                    D.Totalprice = Discount(NewRoom);
                    DB.Update(D);
                    DB.SaveChanges();
                    return 1;
                }
                else
                {
                    D.Totalprice = NoDiscount(NewRoom);
                    DB.Update(D);
                    DB.SaveChanges();
                    return 1;
                }
            }
            else if (D.Rooms.Count > booking.Room_id.Count)
            {
                updateAvel(D.Rooms);
                NewRoom = increasedcountRoom(booking.Room_id);
                D.Data_start = booking.Datestart;
                D.Date_End = booking.DateEnd;
                D.Guet_id = booking.Gust_id;
                D.Rooms = NewRoom;
                int Count = D.Guest.Counter;
                if (Count > 1)
                {
                    D.Totalprice = Discount(NewRoom);
                    DB.Update(D);
                    DB.SaveChanges();
                    return 1;
                }
                else
                {
                    D.Totalprice = NoDiscount(NewRoom);
                    DB.Update(D);
                    DB.SaveChanges();
                    return 1;
                }

            }
            else
            {
                return 0;
            }

        }
        #endregion
                #region getBooking
        public List<SelectBooking> GetAll()
                {
                    var B = DB.Bookings.Select(x => new SelectBooking
                    {
                        Booking_Id = x.Id,
                        Phone = x.Guest.PhoneNumber,
                        Fname = x.Guest.F_name,
                        LName = x.Guest.L_name,
                        TotalPrice = x.Totalprice.Value,
                        BooKingCount = x.Guest.Counter,
                       
                    }).ToList();
                    return B;
                }
                #endregion
                #region selectbookingbyNameGust
                public IEnumerable<SelectBooking> GetBookingbyName(string name)
                {
                    var gustBooking = DB.Bookings.Where(x => x.Guest.F_name == name)
                        .Select(x => new SelectBooking
                        {
                            Booking_Id = x.Id,
                            Fname = x.Guest.F_name,
                            LName = x.Guest.L_name,
                            Phone = x.Guest.PhoneNumber,
                            BooKingCount = x.Guest.Counter,
                            TotalPrice = (Double)x.Totalprice


                        });
                    return gustBooking;
                }
                #endregion
                #region DeleteBooking
                public void Delete(int id)
                {
                    var b = DB.Bookings.Find(id);
                    updateAvel(b.Rooms);
                    Clearcounter(b.Guet_id);
                    DB.Bookings.Remove(b);

                    DB.SaveChanges();
                }
        #endregion
                #region Select BooKing
        private List<Room> GetRooms(DTOUpdateBooking Room)
        {
            List<Room> rsult = new List<Room>();
            foreach (var item in Room.Room_id)
            {
                var id = DB.Rooms.Find(item.Room_ID);
                rsult.Add(id);
            }
            return rsult;
        }


        public getBookingById getBooKingById(int id)
        {
            var booking = DB.Bookings.Where(x => x.Id == id).Select(x => new getBookingById
            {
                DataStrat = x.Data_start,
                DataEnd = x.Date_End.Value,
                id = x.Id,
                Gust_id = x.Guet_id,
                Room = x.Rooms.Select(x => new DTOGetRoom
                {
                    Avalable = x.Availability.Value,
                    BranchName = x.Branch.B_Name,
                    Price = x.Price,
                    TypeName = x.Room_type,

                }).ToList(),
            }).FirstOrDefault();
            return booking;
        }
        #endregion
              #region  MethodHelper







  
        #region check status Available
        private List<Room> increasedcountRoom(List<DTORoomusingBookin> room)
        {
            List<Room> roomList = new List<Room>();

            foreach (var item in room)
            {
                var Aval = DB.Rooms.Find(item.Room_ID);
                if (Aval.Availability.Value ==0)
                {
                    Aval.Availability = 1;
                    roomList.Add(Aval);
                    DB.UpdateRange(roomList);
                }
                else
                {
                    roomList.Add(Aval);
                }
            }

            return roomList;
        }

        private List<Room> updateAvail(List<DTORoomusingBookin> rooms)
        {
            List<Room> result = new List<Room>();
          
            foreach (var item in rooms)
            {
                Room  room = DB.Rooms.Find(item.Room_ID);
                if (room.Availability.Value == 0)
                {
                    room.Availability = 1;
                    result.Add(room);
                }


            }
            DB.UpdateRange(result);
            return result;

        }
        private void updateAvel(List<Room> room)
        {
            List<Room> roomList = new List<Room>();
            foreach (var item in room)
            {
                var r = DB.Rooms.Find(item.Room_id);
                if (r.Availability.Value == 1)
                {
                    r.Availability = 0;
                    roomList.Add(r);
                }
            }
            DB.UpdateRange(roomList);
        }
        #endregion


        #region check Discount


        private double Discount(List<Room> rooms)
        {
            double Total = 0;
            double fiexedprice = 0;
            double dec = 0.95;
            List<Room> result = new List<Room>();
            foreach (var item in rooms)
            {
                var roomprice = DB.Rooms.Find(item.Room_id);
                result.Add(roomprice);
            }
            foreach (var item in result)
            {
                fiexedprice += (double)item.Price;
            }
            Total = fiexedprice - (fiexedprice * dec);
            return Total;

        }
        private double NoDiscount(List<Room> rooms)
        {
            List<Room> roo = new List<Room>();
            double fixedprice = 0;

            foreach (var item in rooms)
            {
                var room = DB.Rooms.Find(item.Room_id);
                roo.Add(item);
            }
            foreach (var item in roo)
            {
                fixedprice += (double)item.Price;
            }
            return fixedprice;
        }
        #endregion

        #region check gust is Existing
        private void Clearcounter(int id)
        {
            var gust = DB.Guests.Find(id);
            if (gust.Counter == 1)
            {
                gust.Counter = 0;
                DB.Update(gust);

            }
        }
        private int countreBooking(int id)
        {
            var gust = DB.Guests.Find(id);

            if (gust.Counter == 0 || gust.Counter == 1)
            {
                gust.Counter++;
                DB.Update(gust);

            }


            return gust.Counter;

        }
        #endregion
        #endregion

    }
}



