using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using RestAlpaka.Model;

namespace Neoflix.Services
{
    public class BookingsService
    {
        private readonly IDriver _driver;

        public BookingsService(IDriver driver)
        {
            _driver = driver;
        }

        // Create a new booking
        public async Task<Bookings> CreateAsync(Bookings booking)
        {
            var query = "CREATE (b:Booking {Booking_id: $bookingId, Customer_id: $customerId, Alpaka_id: $alpakaId, Booking_date: $bookingDate, Start_date: $startDate, End_date: $endDate}) RETURN b";
            var parameters = new
            {
                bookingId = booking.Booking_id,
                customerId = booking.Customer_id,
                alpakaId = booking.Alpaka_id,
                bookingDate = booking.Booking_date,
                startDate = booking.Start_date,
                endDate = booking.End_date
            };

            using (var session = _driver.AsyncSession())
            {
                var result = await session.RunAsync(query, parameters);
                var record = await result.SingleAsync();

                var createdBooking = new Bookings
                {
                    Booking_id = record["Booking_id"].As<int>(),
                    Customer_id = record["Customer_id"].As<int>(),
                    Alpaka_id = record["Alpaka_id"].As<int>(),
                    Booking_date = record["Booking_date"].As<DateTime>(),
                    Start_date = record["Start_date"].As<DateTime>(),
                    End_date = record["End_date"].As<DateTime>()
                };

                return createdBooking;
            }
        }

        // Get a single booking by booking_id
        public async Task<Bookings> GetAsync(int bookingId)
        {
            var query = "MATCH (b:Booking {Booking_id: $bookingId}) RETURN b";
            var parameters = new { bookingId };

            using (var session = _driver.AsyncSession())
            {
                var result = await session.RunAsync(query, parameters);
                var record = await result.SingleAsync();

                var booking = new Bookings
                {
                    Booking_id = record["Booking_id"].As<int>(),
                    Customer_id = record["Customer_id"].As<int>(),
                    Alpaka_id = record["Alpaka_id"].As<int>(),
                    Booking_date = record["Booking_date"].As<DateTime>(),
                    Start_date = record["Start_date"].As<DateTime>(),
                    End_date = record["End_date"].As<DateTime>()
                };

                return booking;
            }
        }

        // Update a booking
        public async Task UpdateAsync(int bookingId, Bookings updatedBooking)
        {
            var query = "MATCH (b:Booking {Booking_id: $bookingId}) SET b.Customer_id = $customerId, b.Alpaka_id = $alpakaId, b.Booking_date = $bookingDate, b.Start_date = $startDate, b.End_date = $endDate";
            var parameters = new
            {
                bookingId,
                customerId = updatedBooking.Customer_id,
                alpakaId = updatedBooking.Alpaka_id,
                bookingDate = updatedBooking.Booking_date,
                startDate = updatedBooking.Start_date,
                endDate = updatedBooking.End_date
            };

            using (var session = _driver.AsyncSession())
            {
                await session.RunAsync(query, parameters);
            }
        }

        // Delete a booking
        public async Task<bool> DeleteAsync(int bookingId)
        {
            var query = "MATCH (b:Booking {Booking_id: $bookingId}) DETACH DELETE b";
            var parameters = new { bookingId };

            using (var session = _driver.AsyncSession())
            {
                await session.RunAsync(query, parameters);
                return true; // Assuming the delete operation was successful
            }
        }

        // Get all bookings
        public async Task<IEnumerable<Bookings>> GetAllAsync()
        {
            var query = "MATCH (b:Booking) RETURN b";

            using (var session = _driver.AsyncSession())
            {
                var result = await session.RunAsync(query);
                var bookings = await result.ToListAsync(record => record["b"].As<Bookings>());
                return bookings;
            }
        }
    }
}

