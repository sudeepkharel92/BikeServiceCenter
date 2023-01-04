using DesktopModel.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopModel.Services
{
    public class Auth : IAuth
    {
        string path = "D:/Demo/Json";
        public async Task<UserDetails> AuthenticateUsers(LoginModel loginModel)
        {
            var returnResponse = new UserDetails();
            var UserAuth = File.ReadAllText(Path.Combine(path, "Userauth.json"));
            var userBasicDetail = JsonConvert.DeserializeObject<List<UserAuthDetails>>(UserAuth);
            foreach (var item in userBasicDetail)
            {
                if (item.Email == loginModel.UserName && item.Password == loginModel.Password)
                {
                    returnResponse.Name = item.Name;
                    returnResponse.Email = item.Email;
                    returnResponse.RoleId = item.RoleId;
                    break;
                }
            }
            return returnResponse;
        }

        public async Task<string> Register(RegistrationModel registrationModel)
        {
            UserAuthDetails UserAuthDetails = new();
            var UserAuth = File.ReadAllText(Path.Combine(path, "Userauth.json"));
            var userBasicDetail = JsonConvert.DeserializeObject<List<UserAuthDetails>>(UserAuth);
            var count = 0;
            foreach (var item in userBasicDetail) 
            { 
                if(item.Email== registrationModel.Email)
                {
                    return "EmailId Already Register!!";
                }
                if(registrationModel.RoleId =="1")
                {
                    if (item.RoleId == 1)
                    {
                        count++;
                    }
                } 
            }
            if(count>0)
            {
                return "Only Insert 1 Admin Role!!";
            }
            UserAuthDetails.Name = registrationModel.Name;
            UserAuthDetails.Email = registrationModel.Email;
            UserAuthDetails.Password = registrationModel.Password;
            UserAuthDetails.RoleId = Int32.Parse(registrationModel.RoleId);
            userBasicDetail.Add(UserAuthDetails);
            var json = JsonConvert.SerializeObject(userBasicDetail, Formatting.Indented);
            File.WriteAllText(Path.Combine(path, "Userauth.json"), string.Empty);
            File.WriteAllText(Path.Combine(path, "Userauth.json"), json);
            return "Insert Sucessfully!!";
        }
    }
}
