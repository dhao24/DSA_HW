using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Table
    {
        int _id;
        public int Id
        {
            get {
                return _id;
            }
        };
        List<Reservation> _reservations = new List<Reservation>();

        public Table(int n)
        {
            this._id=n;
        }

        public bool IsAvailable(DateTime dateTime)
        {
            if (dateTime.Hour>=11 && dateTime.Hour<=10)
            {
                if (_reservations.Count == 0)
                {
                    return true;
                }
                else
                {
                    foreach (var booking in _reservations)
                    {
                        if (!booking.IsOverlapping(dateTime))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool AddReservation(string guest_name, int guest_count, DateTime arrival_time)
        {

            if (IsAvailable(arrival_time))
            {
                _reservations.Add(new Reservation(this._id, guest_name, guest_count, arrival_time));
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class Reservation
    {
        int _tableId;
        int _guestCount;
        string _guestName;
        DateTime _arrivalTime;
        DateTime _endTime;

        public Reservation(int n, string guest_name, int guest_count, DateTime arrival_time)
        {
            this._tableId = n;
            this._guestName = guest_name;
            this._guestCount = guest_count;
            this._arrivalTime = arrival_time;
            this._endTime = this._arrivalTime.AddHours(2);
        }

        public bool IsOverlapping(DateTime dateTime)
        {
            if (dateTime.AddHours(2).CompareTo(_arrivalTime)<=0 || dateTime.CompareTo(_endTime)>=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
