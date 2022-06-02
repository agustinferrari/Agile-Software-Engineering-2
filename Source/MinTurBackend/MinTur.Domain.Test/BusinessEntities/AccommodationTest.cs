using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MinTur.Domain.Test.BusinessEntities
{
    [TestClass]
    public class AccommodationTest
    {
        private readonly DateTime currentTime = new DateTime(2020, 9, 27);

        [TestMethod]
        public void ValidAccommodationWithAdultsAndRetiredGuestsPassesValidation()
        {
            Exception unexpectedException = null;
            try
            {
                Accommodation accommodation = new Accommodation()
                {
                    CheckIn = new DateTime(2020, 9, 27),
                    CheckOut = new DateTime(2020, 9, 30)
                };
                accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Adult.ToString(), Amount = 4 });
                accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Kid.ToString(), Amount = 3 });
                accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Retired.ToString(), Amount = 2 });

                accommodation.ValidOrFail(currentTime);
            }
            catch (Exception e)
            {
                unexpectedException = e;
            }

            Assert.IsNull(unexpectedException);
        }

        [TestMethod]
        public void ValidAccommodationWithRetiredGuestsPassesValidation()
        {
            Exception unexpectedException = null;
            try
            {
                Accommodation accommodation = new Accommodation()
                {
                    CheckIn = new DateTime(2020, 9, 27),
                    CheckOut = new DateTime(2020, 9, 30)
                };
                accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Kid.ToString(), Amount = 3 });
                accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Retired.ToString(), Amount = 2 });

                accommodation.ValidOrFail(currentTime);
            }
            catch (Exception e)
            {
                unexpectedException = e;
            }

            Assert.IsNull(unexpectedException);

        }

        [TestMethod]
        public void ValidAccommodationWithAdultsGuestsPassesValidation()
        {

            Exception unexpectedException = null;
            try
            {
                Accommodation accommodation = new Accommodation()
                {
                    CheckIn = new DateTime(2020, 9, 27),
                    CheckOut = new DateTime(2020, 9, 30)
                };
                accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Adult.ToString(), Amount = 4 });
                accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Kid.ToString(), Amount = 3 });

                accommodation.ValidOrFail(currentTime);
            }
            catch (Exception e)
            {
                unexpectedException = e;
            }

            Assert.IsNull(unexpectedException);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void InvalidSameDayCheckInAndCheckOutAccommodationFails()
        {
            Accommodation accommodation = new Accommodation()
            {
                CheckIn = new DateTime(2020, 9, 28),
                CheckOut = new DateTime(2020, 9, 28)
            };
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Adult.ToString(), Amount = 3 });
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Kid.ToString(), Amount = 1 });
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Baby.ToString(), Amount = 3 });

            accommodation.ValidOrFail(currentTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void InvalidPastCheckInDateAccommodationFails()
        {
            Accommodation accommodation = new Accommodation()
            {
                CheckIn = new DateTime(2020, 9, 26),
                CheckOut = new DateTime(2020, 9, 30)
            };
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Adult.ToString(), Amount = 3 });
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Kid.ToString(), Amount = 1 });
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Baby.ToString(), Amount = 3 });

            accommodation.ValidOrFail(currentTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void CheckOutBeforeCheckInAccommodationFails()
        {
            Accommodation accommodation = new Accommodation()
            {
                CheckIn = new DateTime(2020, 9, 27),
                CheckOut = new DateTime(2020, 8, 1)
            };
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Adult.ToString(), Amount = 3 });
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Kid.ToString(), Amount = 1 });
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Baby.ToString(), Amount = 3 });

            accommodation.ValidOrFail(currentTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void NoAdultAndRetiredGuestsAccommodationFails()
        {
            Accommodation accommodation = new Accommodation()
            {
                CheckIn = new DateTime(2020, 9, 27),
                CheckOut = new DateTime(2020, 9, 30)
            };
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Kid.ToString(), Amount = -1 });
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Baby.ToString(), Amount = 3 });

            accommodation.ValidOrFail(currentTime);
        }


    }
}
