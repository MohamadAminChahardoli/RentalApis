using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalHouse.Models
{
    public class House
    {
        public string HouseTitle { get; set; }
        public Nullable<byte> HouseType { get; set; }
        public string HouseZone { get; set; }
        public string HouseAddress { get; set; }
        public string HouseDescription { get; set; }
        public string HouseFirstPicture { get; set; }
        public string HouseSecondPicture { get; set; }
        public string HouseThirdPicture { get; set; }
        public string HouseForthPicture { get; set; }
        public Nullable<int> HouseMortgage { get; set; }
        public Nullable<int> HouseRentPrice { get; set; }
        public string HousePhoneNumber { get; set; }
        public string HouseBenefits { get; set; }
        public string HouseLatitiud { get; set; }
        public string HouseLongitiud { get; set; }
        public Nullable<byte> HouseGender { get; set; }
        public Nullable<int> HouseSingleBed { get; set; }
        public Nullable<int> HouseDoubleBed { get; set; }
        public Nullable<int> HouseTripleBed { get; set; }
        public Nullable<int> HouseBedOfFour { get; set; }
        public Nullable<int> HouseBedOfSix { get; set; }
        public Nullable<int> HouseBedOfEight { get; set; }
        public Nullable<int> HouseBedOfTen { get; set; }
    }
}