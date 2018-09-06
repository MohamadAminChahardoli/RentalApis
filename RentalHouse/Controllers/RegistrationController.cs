using RentalHouse.Models;
using System.Linq;
using System.Web.Http;

namespace RentalHouse.Controllers
{
    public class RegistrationController : ApiController
    {
        private DbRentalHouseEntities DbContext;

        public RegistrationController()
        {
            DbContext = new DbRentalHouseEntities();
        }

        [HttpPost]
        public bool RegisterUser([FromBody] T_Users newUser)
        {
            T_Users user = DbContext.T_Users.FirstOrDefault(u => u.UserMobileNumber == newUser.UserMobileNumber);
           
            if(user == null)
            {
                DbContext.T_Users.Add(newUser);
                DbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        public int LoginUser(string username, string password)
        {
            T_Users user = DbContext.T_Users.FirstOrDefault(u => u.UserMobileNumber == username &&
            u.UserPassword == password);

            if(user != null)
            {
                if(user.IsActive)
                {
                    return 1; // 1: user is active
                }
                else
                {
                    return 0; // 0: user is not active
                }
            }
            else
            {
                return -1; // -1: user is null (not found)
            }
        }

        public void ConfrimUserAccount()
        {

        }


    }
}
