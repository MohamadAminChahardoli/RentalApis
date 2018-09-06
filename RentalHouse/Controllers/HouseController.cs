using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentalHouse.Models;
using System.Linq.Expressions;

namespace RentalHouse.Controllers
{
    public class HouseController : ApiController
    {

        private DbRentalHouseEntities DbContext;


        public HouseController()
        {
            DbContext = new DbRentalHouseEntities();
        }

        [HttpGet]
        public dynamic GetAllHouses(int skipNumber, int takeNumber)
        {
            return
            DbContext.T_Houses.Select(house => new
            {
                house.HouseId,
                house.HouseTitle,
                house.HouseRegisteredDate,
                house.HouseMortgage,
                house.HouseRentPrice,
                house.HouseFirstPicture,
                house.HouseZone
            }).AsEnumerable().Select(c=>new
            {
                HouseId=c.HouseId,
                HouseTitle=c.HouseTitle,
                HouseRegisteredDate=RelativeTimeCalculator.Calculate(c.HouseRegisteredDate),
                HouseMortgage=c.HouseMortgage,
                HouseRentPrice=c.HouseRentPrice,
                HouseFirstPicture=c.HouseFirstPicture,
                HouseZone=c.HouseZone

            }).OrderByDescending(x => x.HouseId).Skip(skipNumber).Take(takeNumber).ToList();


        }

        [HttpGet]
        public dynamic GetHouseDetails(int houseId)
        {
           return DbContext.T_Houses.Where(h => h.HouseId == houseId).AsEnumerable()
                .Select(c => new
                {
                   c.HouseType,
                   c.HouseAddress,
                   c.HouseDescription,
                   c.HouseBenefits,
                   c.HouseSecondPicture,
                   c.HouseThirdPicture,
                   c.HouseForthPicture,
                   c.HousePhoneNumber,
                   c.HouseVisitedCount,
                   c.HouseLatitiud,
                   c.HouseLongitiud,
                   c.HouseGender,
                   c.HouseSingleBed,
                   c.HouseDoubleBed,
                   c.HouseTripleBed,
                   c.HouseBedOfFour,
                   c.HouseBedOfSix,
                   c.HouseBedOfEight,
                   c.HouseBedOfTen,
                   c.HouseOwnerId
                }).FirstOrDefault();                
        }

        [HttpGet]
        public dynamic GetHousesWithFilter(Filter filter, int skipNumber, int takeNumber)
        {
            dynamic filteredHouses =
                DbContext.T_Houses.Select(house => house).Where(h => 
                h.HouseZone == filter.Zone &&
                h.HouseMortgage >= filter.FromMortgage &&
                h.HouseMortgage <= filter.ToMortgage &&
                h.HouseRentPrice >= filter.FormRent &&
                h.HouseRentPrice <= filter.ToRent &&
                h.HouseType == filter.Type &&
                h.HouseGender == filter.Gender)
                .OrderByDescending(x => x.HouseId).Skip(skipNumber).Take(takeNumber).ToList();

            return filteredHouses;
        }

        [HttpGet]
        public void Search(string searchExperssion)
        {

        }


    }
}
