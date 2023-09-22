using CustomSupportLogger.Models;

namespace CustomLogger
{
    public class UserAndLog
    {
        private readonly Phase4Context _context;

        public UserAndLog(Phase4Context context)
        {
            _context = context;
        }

        public int CountUserInfos()
        {
            try
            {
                int count = _context.UserInfos.Count();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error counting UserInfos: {ex.Message}");
                throw;
            }
        }
        public bool ValidateUser(int userId, string password)
        {
            try
            {
                bool isValidUser = _context.UserInfos.Any(u => u.UserId == userId && u.Password == password);
                return isValidUser;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating user: {ex.Message}");
                throw;
            }
        }
        public bool AddUser(int userId, string password)
        {
            try
            {
                bool userExists = _context.UserInfos.Any(u => u.UserId == userId);

                if (!userExists)
                {
                    var newUser = new UserInfo
                    {
                        UserId = userId,
                        Password = password
                    };

                    _context.UserInfos.Add(newUser);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }
    }
}
