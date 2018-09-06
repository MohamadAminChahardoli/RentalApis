using RentalHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentalHouse.Classes;
namespace RentalHouse.Controllers
{
    public class OwnerController : ApiController
    {

        private DbRentalHouseEntities DbContext;

        public OwnerController()
        {
            DbContext = new DbRentalHouseEntities();
        }

        [HttpPost]
        public bool InsertNewHouse([FromBody] House house)
        {
            T_Houses newHouse = new T_Houses();

            try
            {
                newHouse.HouseTitle = house.HouseTitle;
                newHouse.HouseType = house.HouseType;
                newHouse.HouseZone = house.HouseZone;
                newHouse.HouseAddress = house.HouseAddress;
                newHouse.HouseDescription = house.HouseDescription;
                newHouse.HouseFirstPicture = ImageGenerator.ByteToImage(Convert.FromBase64String(house.HouseFirstPicture));
                newHouse.HouseSecondPicture = ImageGenerator.ByteToImage(Convert.FromBase64String(house.HouseSecondPicture));
                newHouse.HouseThirdPicture = ImageGenerator.ByteToImage(Convert.FromBase64String(house.HouseThirdPicture));
                newHouse.HouseForthPicture = ImageGenerator.ByteToImage(Convert.FromBase64String(house.HouseForthPicture));
                newHouse.HouseMortgage = house.HouseMortgage;
                newHouse.HouseRentPrice = house.HouseRentPrice;
                newHouse.HousePhoneNumber = house.HousePhoneNumber;
                newHouse.HouseBenefits = house.HouseBenefits;
                newHouse.HouseLatitiud = house.HouseLatitiud;
                newHouse.HouseLongitiud = house.HouseLongitiud;
                newHouse.HouseGender = house.HouseGender;
                newHouse.HouseSingleBed = house.HouseSingleBed;
                newHouse.HouseDoubleBed = house.HouseDoubleBed;
                newHouse.HouseTripleBed = house.HouseTripleBed;
                newHouse.HouseBedOfFour = house.HouseBedOfFour;
                newHouse.HouseBedOfSix = house.HouseBedOfSix;
                newHouse.HouseBedOfEight = house.HouseBedOfEight;
                newHouse.HouseBedOfTen = house.HouseBedOfTen;

                DbContext.T_Houses.Add(newHouse);
                DbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        [HttpPost]
        public bool DeleteHouse(int houseId)
        {
            try
            {
                T_Houses house = DbContext.T_Houses.FirstOrDefault(h => h.HouseId == houseId);
                DbContext.T_Houses.Remove(house);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public bool EditHouse(int houseId, House editedHouse)
        {
            T_Houses house = DbContext.T_Houses.FirstOrDefault(h => h.HouseId == houseId);

            house.HouseTitle = editedHouse.HouseTitle;
            house.HouseType = editedHouse.HouseType;
            house.HouseZone = editedHouse.HouseZone;
            house.HouseAddress = editedHouse.HouseAddress;
            house.HouseDescription = editedHouse.HouseDescription;
            house.HouseFirstPicture = editedHouse.HouseFirstPicture;
            house.HouseSecondPicture = editedHouse.HouseSecondPicture;
            house.HouseThirdPicture = editedHouse.HouseThirdPicture;
            house.HouseForthPicture = editedHouse.HouseForthPicture;
            house.HouseMortgage = editedHouse.HouseMortgage;
            house.HouseRentPrice = editedHouse.HouseRentPrice;
            house.HousePhoneNumber = editedHouse.HousePhoneNumber;
            house.HouseBenefits = editedHouse.HouseBenefits;
            house.HouseLatitiud = editedHouse.HouseLatitiud;
            house.HouseLongitiud = editedHouse.HouseLongitiud;
            house.HouseGender = editedHouse.HouseGender;
            house.HouseSingleBed = editedHouse.HouseSingleBed;
            house.HouseDoubleBed = editedHouse.HouseDoubleBed;
            house.HouseTripleBed = editedHouse.HouseTripleBed;
            house.HouseBedOfFour = editedHouse.HouseBedOfFour;
            house.HouseBedOfSix = editedHouse.HouseBedOfSix;
            house.HouseBedOfEight = editedHouse.HouseBedOfEight;
            house.HouseBedOfTen = editedHouse.HouseBedOfTen;

            DbContext.SaveChanges();
            return true;

        }

        [HttpGet]
        public dynamic GetAllOwnerProperties(int ownerId)
        {
            return DbContext.T_Houses.Select(house => new
            {
                house.HouseId,
                house.HouseTitle,
                house.HouseZone,
                house.HouseFirstPicture
            });
        }

        [HttpGet]
        public string GetTheOwnerContactInformation(int ownerId)
        {
            T_Users owner = DbContext.T_Users.FirstOrDefault(o => o.UserId == ownerId);
            return owner.UserMobileNumber;
        }


    }
}
