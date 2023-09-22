using CustomSupportLogger.Models;
using NUnit.Framework;


namespace CustomLogger
{
    [TestFixture]
    public class TheTests
    {
        private Phase4Context _context;
        private UserAndLog _userAndLog;

        [SetUp]
        public void SetUp()
        {
            _context = new Phase4Context();
            _userAndLog = new UserAndLog(_context);
        }
        [Test]
        public void CustLogInfoTest()
        {
            int count = _userAndLog.CountUserInfos();
            Assert.AreEqual(3, count);
        }
        [Test]
        public void SaveCustLogInfoTest()
        {
            bool addUserResult = _userAndLog.AddUser(4, "newpassword");
            Assert.IsTrue(addUserResult);
            bool isValidUser = _userAndLog.ValidateUser(4, "newpassword");
            Assert.IsTrue(isValidUser);
        }

        [Test]
        public void ValidateUserTest_ValidUser()
        {
            bool isValidUser = _userAndLog.ValidateUser(1, "password123");
            Assert.IsTrue(isValidUser);
        }
        [Test]
        public void ValidateUserTest_InvalidUser()
        {
            bool isValidUser = _userAndLog.ValidateUser(2, "wrongpassword");
            Assert.IsFalse(isValidUser);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
