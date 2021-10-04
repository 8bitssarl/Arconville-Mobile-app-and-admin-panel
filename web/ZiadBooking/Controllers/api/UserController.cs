using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZiadBooking.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using Twilio;
using Twilio.Rest.Verify.V2.Service;
using Microsoft.Extensions.Configuration;
using Twilio.Rest.IpMessaging.V1;
using Twilio.Rest.Api.V2010.Account;


namespace ZiadBooking.Controllers.api
{
    public class UserController : ZiadBookingApiController
    {
        private IConfiguration configuration;
        
        public UserController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        [HttpGet]
        public ApiResponseModel Get()
        {
            try
            {
                string userId = Request.Query["user_id"];
                if (userId == null)
                {
                    userId = "0";
                }
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                //string userId = Request.Query["user_id"];
                //string query = $"select *from User where user_id={userId}";
                //System.Data.IDbCommand comm = db.Connection.CreateCommand();
                //comm.CommandText = query;
                Models.User usr = Models.User.GetById(userId, db.Connection);
                db.Close();
                if (usr != null)
                {
                    
                }
                return CreateApiResponseModel(200, "",usr);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                
              
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                //string userId = Request.Query["user_id"];
                //string query = $"select *from User where user_id={userId}";
                //System.Data.IDbCommand comm = db.Connection.CreateCommand();
                //comm.CommandText = query;
                var usr = Models.User.GetAllUsers(db.Connection);
                db.Close();
                if (usr != null)
                {

                }
                return Ok(usr);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ApiResponseModel Put()
        {
            try
            {
                string name = Request.Form["name"];
                string email = Request.Form["email"];
                string password = Request.Form["password"];
                string image_url = Request.Form["image_url"];
                string facebook_profile_id = Request.Form["facebook_profile_id"];
                string age = Request.Form["age"];

                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                Models.User user = Models.User.GetByEmail(email, db.Connection);
                if (user != null)
                {
                    db.Close();
                    if (string.IsNullOrEmpty(facebook_profile_id))
                    {
                        return CreateApiResponseModel(401, "Email already registered", null);
                    }
                    else
                    {
                        return CreateApiResponseModel(200, "", user);
                    }
                }
                user = new Models.User();
                user.Name = name;
                user.Email = email;
                user.Password = password;
                user.ProfilePicUrl = image_url;
                user.Age = age;
                user.RegisterDt = Helper.GetDatabaseDateTime(DateTime.Now);
                user.Insert(db.Connection);

                user = Models.User.GetByEmail(email, db.Connection);
                db.Close();

                return CreateApiResponseModel(200, "", user);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpPost]
        public ApiResponseModel Post()
        {
            try
            {
                string id = Request.Form["id"];
                string name = Request.Form["name"];
                string email = Request.Form["email"];
                string password = Request.Form["password"];
                string image_url = Request.Form["image_url"];
                string is_family = Request.Form["is_family"];
                string age = Request.Form["age"];

                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                Models.User user = Models.User.GetById(id, db.Connection);
                if (user == null)
                {
                    db.Close();
                    return CreateApiResponseModel(404, "User not found", null);
                }
                if (password == "")
                {
                    password = user.Password;
                }
                user.Name = name;
                user.Email = email;
                user.Password = password;
                user.ProfilePicUrl = image_url;
                user.CanAddMember = is_family;
                user.Age = age;
                user.UpdateProfileDetails(db.Connection);

                user = Models.User.GetByEmail(email, db.Connection);
                db.Close();

                return CreateApiResponseModel(200, "", user);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpPost]
        [Route("login")]
        public ApiResponseModel Login()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                Models.User user = Models.User.GetByCredentials(username, password, db.Connection);
                db.Close();
                if (user == null)
                {
                    return CreateApiResponseModel(404, "Invalid username/password", null);
                }
                return CreateApiResponseModel(200, "", user);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpPost]
        [Route("verifyphone")]
        public ApiResponseModel VerifyPhone()
        {
            string userId = Request.Form["user_id"];
            string phone = Request.Form["phone"];
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                User usr = new User();
                usr.Id = userId;
                usr.PhoneNumber = phone;
                usr.UpdatePhoneDetails(db.Connection);
                db.Close();
                return CreateApiResponseModel(200, "", new
                {
                    code = "12345"
                });
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }
        [HttpGet]
        [Route("sendcode")]
        public ApiResponseModel SendCode()
        {
            string phone_no = Request.Query["phone_no"];
            //string code = Request.Form["code"];
            try
            {
                Random rnd = new Random();
                String r = rnd.Next(0, 100000).ToString("D6");
                if (string.IsNullOrEmpty(phone_no))
                    throw new Exception("Please enter a valid phone number");
                    if(!phone_no.Contains("+"))
                    throw new Exception("Please enter your country code with + sign");
              
             

                

                var verification = VerificationResource.Create(
                    to: phone_no,
                    channel: "sms",
                    pathServiceSid: "VA2add2b274338c996c389bdb6260fee1f"
                );
                DatabaseHelper db = new DatabaseHelper();
                db.Open();

                string phoneNumber = "";

                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = "SELECT * FROM user WHERE phone_number='" + phone_no + "'";
                IDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["phone_number"] != null )
                    {
                        
                        if (reader["phone_verified"] == null)
                        {
                            reader.Close();
                            comm.CommandText = @"update user set phone_verified=0 where phone_number='"+phone_no+"'";
                            comm.ExecuteNonQuery();
                        }
                        if ( Convert.ToInt32(reader["phone_verified"]) == 0)
                        {
                            reader.Close();
                            comm.CommandText = @"update user set phone_verified=0 where phone_number='" + phone_no + "'";
                            comm.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        reader.Close();
                        comm.CommandText = "insert into user(phone_number)  values(1)";
                        comm.ExecuteNonQuery();
                    }


                }
                else
                {
                    reader.Close();
                    comm.CommandText = "insert into user(phone_number) values('"+phone_no+"')";
                    comm.ExecuteNonQuery();
                }
                reader.Close();

                //User usr = new User();
                //usr.Id = userId;
                ////usr.PhoneVerified = "1";
                //usr.PhoneNumber = phoneNumber;
                //usr.UpdatePhoneDetails(db.Connection);
                db.Close();
                return CreateApiResponseModel(200, "", verification.Sid);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }
        [HttpPost]
        [Route("verifycode")]
        public ApiResponseModel VerifyCode()
        {
            string phone_no = Request.Form["phone_no"];
            string pathSid = Request.Form["path_sid"];
            string code = Request.Form["code"];
            try
            {
                var verification = VerificationResource.Update(
                    pathServiceSid:  configuration.GetValue<string>("TWILIO_PATH_SERVICE_SID"),
                    pathSid: pathSid,
                    status:VerificationResource.StatusEnum.Approved
                    );
                if (verification.Status != "approved")
                {
                    return CreateApiResponseModel(500, "Code is incorrect.", null);
                }
              DatabaseHelper db = new DatabaseHelper();
                db.Open();

                string phoneNumber = "";
             User usr = new User();
                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = "SELECT * FROM user WHERE phone_number='"+phone_no+"'";
                
                IDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["phone_number"] != null)
                    {

                        
                       var Id  =reader["id"].ToString();
                        reader.Close();
                        usr = Models.User.GetById(Id, db.Connection);
                        
                        
                        if (usr.PhoneNumber != null)
                        {
                            reader.Close();
                            comm.CommandText = @"update user set phone_verified=1 where phone_number='" + phone_no + "'";
                            comm.ExecuteNonQuery();
                        }
                      

                    }
                }
                else
                {
                    reader.Close();
                    db.Close();
                    return CreateApiResponseModel(500,  "Phone Number is not correct",null);
                }
                reader.Close();

                
                db.Close();
                return CreateApiResponseModel(200, "", usr);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpGet]
        [Route("home")]
        public ApiResponseModel Home()
        {
            try
            {
                string userId = Request.Query["user_id"];
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                List<dynamic> upcoming = Models.Reservation.GetUpcomingReservations(userId, db.Connection);
                List<dynamic> previous = Models.Reservation.GetPreviousReservations(userId, db.Connection);
                db.Close();
                var x = new
                {
                    upcoming = upcoming,
                    previous = previous,
                };
                return CreateApiResponseModel(200, "", x);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [Route("family")]
        public ApiResponseModel Family()
        {
            try
            {
                string userId = Request.Query["user_id"];
                DatabaseHelper db = new DatabaseHelper();
                db.Open();

                string phoneNumber = "";
                string query = "SELECT * FROM user WHERE id=@id";
                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@id", userId);
                IDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    phoneNumber = reader["phone_number"].ToString();
                }
                reader.Close();

                List<dynamic> pending = new List<dynamic>();
                List<dynamic> family = new List<dynamic>();
                //query = "SELECT fr.*,u.name,u.profile_pic_url FROM familyrequest fr,user u WHERE u.id=fr.user_id AND fr.phone_number=@phone_number ORDER BY fr.request_ts DESC";
                //comm = (MySqlCommand)db.Connection.CreateCommand();
                //comm.CommandText = query;
                //comm.Parameters.AddWithValue("@phone_number", phoneNumber);
                //reader = comm.ExecuteReader();
                //while (reader.Read())
                //{
                //    var r = new
                //    {
                //        parent_id = reader["user_id"].ToString(),
                //        phone_numer = reader["phone_number"].ToString(),
                //        request_ts = reader["request_ts"].ToString(),
                //        name = reader["name"].ToString(),
                //        profile_pic_url = reader["profile_pic_url"].ToString(),
                //    };
                //    pending.Add(r);
                //}
                //reader.Close();
                query = "SELECT u.name,u.profile_pic_url,u.phone_number,'0' AS is_pending,f.relation FROM family f,user u WHERE u.id=f.child_id AND f.user_id=@user_id ORDER BY u.name";
                comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@user_id", userId);
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    var r = new
                    {
                        name = reader["name"].ToString(),
                        phone_number = reader["phone_number"].ToString(),
                        profile_pic_url = reader["profile_pic_url"].ToString(),
                        is_pending = reader["is_pending"].ToString(),
                        relation = reader["relation"].ToString(),
                    };
                    family.Add(r);
                }
                reader.Close();
                query = "SELECT f.name,'' AS profile_pic_url,f.phone_number,'1' AS is_pending,f.relation FROM familyrequest f WHERE f.user_id=@user_id ORDER BY f.name";
                comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@user_id", userId);
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    var r = new
                    {
                        name = reader["name"].ToString(),
                        phone_number = reader["phone_number"].ToString(),
                        profile_pic_url = reader["profile_pic_url"].ToString(),
                        is_pending = reader["is_pending"].ToString(),
                        relation = reader["relation"].ToString(),
                    };
                    family.Add(r);
                }
                reader.Close();
                db.Close();
                var x = new
                {
                    pending = pending,
                    family = family,
                };
                return CreateApiResponseModel(200, "", x);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpPost]
        [Route("addtofamily")]
        public ApiResponseModel AddToFamily()
        {
            string Id = Request.Query["user_id"];
            string userId = Request.Form["user_id"];
            string childId = Request.Form["child_id"];
            //this user is adding userId2 as a family
            string phone = Request.Form["phone"]; //this user is being added as a family by userId1
            string name = Request.Form["name"]; //name of the user that is being added as a family by userId1
            string relation = Request.Form["relation"]; //relation of the user that is being added as a family
            if (relation == null)
            {
                relation = "";
            }
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                //check if there is already a pending request for this phone number by this userid
                string query = "SELECT * FROM `familyrequest` WHERE phone_number=@phone";
                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@phone", phone);
                IDataReader reader = comm.ExecuteReader();
                bool hasARequest = false;
                if (reader.Read())
                {
                    hasARequest = true;
                }
                reader.Close();
                if (hasARequest)
                {
                    db.Close();
                    return CreateApiResponseModel(403, "Request already pending", null);
                }
                //check if user with phone exists
                //query = "SELECT * FROM `user` WHERE phone_number=@phone";
                //comm = (MySqlCommand)db.Connection.CreateCommand();
                //comm.CommandText = query;
                //comm.Parameters.AddWithValue("@phone", phone);
                //reader = comm.ExecuteReader();
                bool canInsertRequest = true;
                bool isAlreadFamily = false;
                
                //if (reader.Read())
                //{
                //    //childId = reader["id"].ToString();
                //}
                reader.Close();
                //check if user is already a family
                if (childId.CompareTo("0") != 0)
                {
                    query = "SELECT * FROM family WHERE user_id=@user_id AND child_id=@child_id";
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@user_id", userId);
                    comm.Parameters.AddWithValue("@child_id", childId);
                    reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        isAlreadFamily = true;
                    }
                    reader.Close();
                }
                if (isAlreadFamily)
                {
                    db.Close();
                    return CreateApiResponseModel(403, "Already a family member", null);
                }
                if (canInsertRequest)
                {
                    //insert into family request and send sms to this user
                    query = "INSERT INTO familyrequest(user_id,phone_number,name,relation,request_ts)";
                    query += " VALUES(@user_id,@phone_number,@name,@relation,@request_ts);";
                   query  += $" Insert into Family (user_id,child_id,relation) values(@user_id,{childId},@relation)";
                   query  += $"  Insert into Family (user_id,child_id,relation) values({childId},@user_id,@relation) ";
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@user_id", userId);
                    comm.Parameters.AddWithValue("@phone_number", phone);
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@relation", relation);
                    comm.Parameters.AddWithValue("@request_ts", Models.Helper.UnixTimestampFromDateTime(DateTime.Now));
                    comm.ExecuteScalar();
                }
                db.Close();
                return CreateApiResponseModel(200, "", null);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        private string GetReverseRelation(string relation)
        {
            string rRelation = "";
            if (relation == "parent")
            {
                rRelation = "child";
            }
            else if (relation == "friend")
            {
                rRelation = "friend";
            }
            else if (relation == "sibling")
            {
                rRelation = "sibling";
            }
            
            return rRelation;
        }

        [HttpPost]
        [Route("actiontofamily")]
        public ApiResponseModel ActionToFamily()
        {
            string userId = Request.Form["user_id"];
            string userId2 = Request.Form["user_id2"];
            string action = Request.Form["action"];
            string phoneNumber = "";
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                //check if there is already a pending request for this phone number by this userid
                string query = "SELECT * FROM `user` WHERE id=@userId";
                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@userId", userId);
                IDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    phoneNumber = reader["phone_number"].ToString();
                }
                reader.Close();

                query = "SELECT * FROM familyrequest WHERE user_id=@user_id AND phone_number=@phone_number";
                comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@user_id", userId2);
                comm.Parameters.AddWithValue("@phone_number", phoneNumber);
                reader = comm.ExecuteReader();
                string requestId = "0";
                string relation = "";
                if (reader.Read())
                {
                    requestId = reader["id"].ToString();
                    relation = reader["relation"].ToString();
                }
                reader.Close();
                if (requestId.CompareTo("0") == 0)
                {
                    db.Close();
                    return CreateApiResponseModel(403, "Invalid request", null);
                }

                if (action == "accept")
                {
                    //now insert both as family of each other
                    query = "INSERT INTO family(user_id,child_id,relation) VALUES(@user_id,@child_id,@relation)";
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@user_id", userId);
                    comm.Parameters.AddWithValue("@child_id", userId2);
                    comm.Parameters.AddWithValue("@relation", relation);
                    comm.ExecuteNonQuery();

                    relation = GetReverseRelation(relation);

                    //switch to reverse relation
                    query = "INSERT INTO family(user_id,child_id,relation) VALUES(@user_id,@child_id,@relation)";
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@user_id", userId2);
                    comm.Parameters.AddWithValue("@child_id", userId);
                    comm.Parameters.AddWithValue("@relation", relation);
                    comm.ExecuteNonQuery();

                    query = "DELETE FROM familyrequest WHERE id=@id";
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@id", requestId);
                    comm.ExecuteNonQuery();
                }
                else if (action == "reject")
                {
                    query = "DELETE FROM familyrequest WHERE id=@id";
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@id", requestId);
                    comm.ExecuteNonQuery();
                }
                db.Close();
                return CreateApiResponseModel(200, "", null);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpPost]
        [Route("profileimage")]
        public ApiResponseModel ProfileImage()
        {
            var folderName = Path.Combine("wwwroot", "ProfileImages");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (Request.Form.Files==null || Request.Form.Files.Count == 0)
            {
                return CreateApiResponseModel(404, "No file uploaded", null);
            }
            IFormFile file=Request.Form.Files[0];
            try
            {
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    var dbPath = Path.Combine("ProfileImages", fileName).Replace('\\', '/');
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var robj = new
                    {
                        url = dbPath
                    };
                    return CreateApiResponseModel(200, "",robj);
                }
                else
                {
                    return CreateApiResponseModel(500, "File length is 0", null);
                }
            }
            catch(Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpGet]
        [Route("Suspention")]
        public ApiResponseModel Suspention()
        {
            try
            {
                string id = Request.Query["id"];
                bool isActive =Convert.ToBoolean( Request.Query["isActive"]);
                bool isSuspended = Convert.ToBoolean( Request.Query["isSuspended"]);


                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                string query = $"update User set isActive={isActive}, isSuspended={isSuspended} where Id={id}";
                System.Data.IDbCommand comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                comm.ExecuteNonQuery();
                db.Close();

                return CreateApiResponseModel(200, "User Suspended Successfully", null);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpPost]
        [Route("ReservationTiming")]
        public ApiResponseModel ReservationTiming()
        {
            var model = new ReservationTiming();
            var chk = Request.Form["chk[]"];
            var sService = Request.Form["sService"];
            var rDate = Request.Form["rDate"];
            var user_id = Request.Form["user_id"];

           model.chk= Array.ConvertAll(chk.ToArray(), int.Parse);
            model.rDate = rDate;
            model.sService = Convert.ToInt32( sService);
            model.user_id = Convert.ToInt32(user_id);
            int count = 0;
            try
            {
                string reserveTs = Helper.UnixTimestampFromDateTime(Convert.ToDateTime(rDate)).ToString();
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                foreach (var item in model.chk)
                {
                    string query = $"INSERT INTO `selected_reservationtiming` (`fk_reservationtimeId`, `fk_reservationId`,`fk_userId`,`created_dt`,`reserve_ts`) " +
$" SELECT '{item}', '{model.sService}','{model.user_id}','{DateTime.Now}','{reserveTs}' FROM DUAL " +
$" WHERE NOT EXISTS (SELECT * FROM `selected_reservationtiming` " +
$"      WHERE `fk_reservationtimeId` IN({item}) and `fk_reservationId` IN({model.sService}) and `reserve_ts` IN ('{reserveTs}'));";

                    
                    //query=    "SELECT us.*,bs.name AS service_name FROM usersubscription us,bookingservice bs WHERE bs.id=us.service_id AND us.user_id=" + userId;
                    //query += " UNION SELECT us.*,bs.title AS service_name FROM usersubscription us,package bs WHERE bs.id=us.package_id AND us.user_id=" + userId + " ORDER BY start_ts DESC";
                    IDbCommand comm = db.Connection.CreateCommand();
                    comm.CommandText = query;
                  int result =  comm.ExecuteNonQuery();
                    count =count+ result;
                    comm.Dispose();
                    
                }
                string query1 = $"INSERT INTO `reservation`( `user_id`, `service_id`, `num_hours`,  `reserve_ts`) " +
                    $" VALUES ({user_id},{sService},{chk.Count},'{reserveTs}')";
                IDbCommand comm1 = db.Connection.CreateCommand();
                comm1.CommandText = query1;
                comm1.ExecuteNonQuery();
                    
                comm1.Dispose();
                db.Close();

                return CreateApiResponseModel(200,"Save Successfully", null);
                
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }
      
    }
}
