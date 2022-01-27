using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLgs.EdoCta.API.Model;
using QLgs.EdoCta.API.Model.Enums;
using QLgs.EdoCta.API.Helpers.DataBaseAccess;
using System.Data.SqlClient;

namespace QLgs.EdoCta.API.Data
{
    public class AuthRepository: IAuthRepository
    {
        int EXPIRATION_DATE_VIGENCY = 5;

        public AuthRepository() {}
        public async Task<UserLgs> LoginLgs(string username, string password)
        {
            var cliente = new UserLgs();
            var ado = new SQLAccess();
            var parms = ado.IniListParameter();


            //var codCli = "0000000000" + username;
            var codCli = "0000000000" + password; // Ahora es el CodCli
            codCli = codCli.Substring(codCli.Length - 10, 10);

            // parms.Add(ado.GetParameter("CodCli", codCli));
            // parms.Add(ado.GetParameter("PWD", password));

            parms.Add(ado.GetParameter("User", username));
            parms.Add(ado.GetParameter("PWD", codCli));

            var data = await ado.GetDataReader("LoginEdoCtaWeb", parms);

            if (data.HasRows)
            {
                while (await data.ReadAsync()) //while (data.Read())
                {
                    cliente.CodCli = data["CodCli"].ToString();
                    cliente.UserName = data["NomCli"].ToString();
                }
            }

            data.Close();
            

            if (string.IsNullOrEmpty(cliente.CodCli))
            {
                return null;
            }
            return cliente;

        }
        /*
                private readonly DataContext _context;


                public AuthRepository(DataContext context)
                {
                    this._context = context;
                }

                public Task<bool> ChangePassword(string username, string password, string newPassword)
                {
                    throw new System.NotImplementedException();
                }

                public async Task<User> Login(string username, string password)
                {
                    var user = await this._context.Users.FirstOrDefaultAsync(u => u.UserName == username);

                    if (user == null)
                    {
                        return null;
                    }

                    if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    {
                        return null;
                    }

                    return user;
                }

                public async Task<User> Register(User user, string password)
                {
                    byte[] passwordHash;
                    byte[] passwordSalt;

                    CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    await this._context.Users.AddAsync(user);
                    await this._context.SaveChangesAsync();

                    return user;
                }

                public async Task<bool> UserExists(string username)
                {
                    if (await this._context.Users.AnyAsync(u => u.UserName == username))
                    {
                        return true;
                    }

                    return false;
                }

                public async Task<List<Question>> GetQuestions()
                {
                    return await this._context.Questions.ToListAsync();
                }

                public async Task<User> GetUserById(int userId)
                {
                    var user = await this._context.Users.Include(rc => rc.RegistrationCodes)
                        .Include(qr => qr.QuestionResponses).FirstOrDefaultAsync(u => u.Id == userId);

                    return user;
                }

                public async Task<string> RequestInvitation(string invitedEmail, string sponsorEmail, int roleId, string invitedName) 
                {
                    string rcode = GenerateInvitationCode();

                    this._context.Invitations.Add(new RegistrationCode{
                        Code = rcode,
                        DateCreated = DateTime.Now,
                        RoleId = roleId,
                        DueDate = DateTime.Now.AddDays(EXPIRATION_DATE_VIGENCY),
                        InvitedEmail = invitedEmail,
                        InvitedName = invitedName,
                        SponsorEmail = sponsorEmail,
                        Status = RegistrationCodeStatusType.Requested.ToString()
                    });

                    await this._context.SaveChangesAsync();

                    return rcode;
                }

                public async Task<List<RegistrationCode>> GetInvitations()
                {
                    return await this._context.Invitations.ToListAsync();
                }

                public async Task<RegistrationCode> GetInvitationById(int id)
                {
                    var reg = await this._context.Invitations.FirstOrDefaultAsync(r => r.Id == id);

                    return reg;
                }

                public async Task<bool> UpdateRegisterCodeRecord(string regCode, string status, int userId) 
                {
                    var reg = await this._context.Invitations.FirstOrDefaultAsync(i => i.Code == regCode);
                    var user = await this._context.Users.FirstOrDefaultAsync();


                    if (reg != null)
                    {
                        reg.Status = status;
                        if (user.RegistrationCodes == null) user.RegistrationCodes = new List<RegistrationCode>();
                        user.RegistrationCodes.Add(reg);
                        await this._context.SaveChangesAsync();

                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }

                public async Task<string> CreateInvitation(RegistrationCode regCode)
                {
                    string code = GenerateInvitationCode();
                    regCode.Code = code;
                    regCode.DueDate = regCode.DateCreated.AddDays(EXPIRATION_DATE_VIGENCY);

                    this._context.Invitations.Add(regCode);
                    await this._context.SaveChangesAsync();

                    return code;
                }

                private string GenerateInvitationCode() 
                {
                    string result = string.Empty;
                    DateTime rDate =  DateTime.Now;

                    Random rnd = new Random(DateTime.Now.Second);
                    int fr1 = rnd.Next(10, 99);
                    int fr2 = rnd.Next(10, 99);
                    int fr3 = rnd.Next(10, 99);
                    int fr4 = rnd.Next(10, 99);
                    int fr5 = rnd.Next(10, 99);
                    int fr6 = rnd.Next(10, 99);
                    int fr7 = rnd.Next(10, 99);

                    result = "r" + fr1.ToString() + rDate.Year.ToString()
                        + fr2.ToString() + rDate.Month.ToString("00")
                        + fr3.ToString() + rDate.Day.ToString("00")
                        + fr4.ToString() + rDate.Hour.ToString("00")
                        + fr5.ToString() + rDate.Minute.ToString("00")
                        + fr6.ToString() + rDate.Second.ToString("00")
                        + fr7.ToString();

                    return result;
                }

                private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
                {

                    using (var hmac = new System.Security.Cryptography.HMACSHA512())
                    {
                        passwordSalt = hmac.Key;
                        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    }

                }

                private bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
                {
                    using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
                    {
                        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                        for(int idx = 0; idx < computedHash.Length; idx++)
                        {
                            if (computedHash[idx] != PasswordHash[idx]) return false;
                        }
                    } 

                    return true;      
                }

                public async Task<bool> SaveAll() 
                {
                    return await this._context.SaveChangesAsync() > 0;
                }
                */

    }
}