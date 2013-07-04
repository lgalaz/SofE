using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SofETest.Services;
using SofETest.Models;

namespace SofETest.Services.Tests
{
    public class ContributorTests
    {
        private static ContributorsService service = null;
        private static string NAME = "Luis Galaz";
        private static string EMAIL = "lgalaz@email.com";
        private static long PHONE = 9999999999;
        private static string NEWNAME = "Fernando Galaz";
        private static string NEWEMAIL = "fgalaz@email.com";
        private static long NEWPHONE = 1234567890;


        public ContributorTests()
        {
            service = new SofETest.Services.ContributorsService(new SofETestEntities());
        }


        [Fact]
        public void Create_NullContributor_ThrowsArgumentNullException()
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() => service.Create(null));

            Assert.Contains("Contributor instance is invalid.", ex.Message);
        }

        [Fact]
        public void Create_InvalidEmail_ThrowsArgumentException()
        {
            var contributor = new Contributor()
            {
                Email = string.Empty,
                Name = NAME,
                Phone = PHONE
            };

            Exception ex = Assert.Throws<ArgumentException>(() => service.Create(contributor));

            Assert.Contains("Invalid email.", ex.Message);
        }

        [Fact]
        public void Create_InvalidName_ThrowsArgumentException()
        {
            var contributor = new Contributor()
            {
                Email = EMAIL,
                Name = string.Empty,
                Phone = PHONE
            };

            Exception ex = Assert.Throws<ArgumentException>(() => service.Create(contributor));

            Assert.Contains("Invalid name.", ex.Message);
        }

        [Fact]
        public void Create_InvalidPhone_ThrowsArgumentException()
        {
            var contributor = new Contributor()
            {
                Email = EMAIL,
                Name = NAME,
                Phone = 0
            };

            Exception ex = Assert.Throws<ArgumentException>(() => service.Create(contributor));

            Assert.Contains("Phone should a 10 digit number. Phone is lower than expected.", ex.Message);

            contributor.Phone = 10000000000;

            ex = Assert.Throws<ArgumentException>(() => service.Create(contributor));

            Assert.Contains("Phone should be a 10 digit number. Phone is grater than expected.", ex.Message);

        }

        [Fact]
        public void Create_ValidContributor_SavesContributor()
        {
            var contributor = new Contributor()
            {
                Email = EMAIL,
                Name = NAME,
                Phone = PHONE
            };

            service.Create(contributor);
            
            Assert.True(contributor.Id > 0);

            contributor = service.Get(contributor.Id);

            Assert.True(contributor.Name == NAME);
            Assert.True(contributor.Phone == PHONE);
            Assert.True(contributor.Email == EMAIL);
        }

        [Fact]
        public void GetAll_ReturnsListOfContributors()
        {
            var contributors = service.GetAll();

            Assert.NotNull(contributors);
        }

        [Fact]
        public void Get_InvalidId_ThrowsArgumentOutOfRangeException()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => service.Get(0));

            Assert.Contains("id must be an integer greater than 0", ex.Message);
        }

        [Fact]
        public void Get_ValidId_ReturnsCustomer()
        {
            var contributor = new Contributor()
            {
                Email = EMAIL,
                Name = NAME,
                Phone = PHONE
            };

            service.Create(contributor);

            contributor = service.Get(contributor.Id);

            Assert.NotNull(contributor);
        }

        [Fact]
        public void Get_UnexistingId_ReturnsNull()
        {
            var contributor = service.Get(2147483647);

            Assert.Null(contributor);
        }


        [Fact]
        public void Update_NullContributor_ThrowsArgumentNullException()
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() => service.Update(null));

            Assert.Contains("Contributor instance is invalid.", ex.Message);
        }

        [Fact]
        public void Update_InvalidEmail_ThrowsArgumentException()
        {
            var contributor = new Contributor()
            {
                Id = 1,
                Email = string.Empty,
                Name = NAME,
                Phone = PHONE
            };

            Exception ex = Assert.Throws<ArgumentException>(() => service.Update(contributor));

            Assert.Contains("Invalid email.", ex.Message);
        }

        [Fact]
        public void Update_InvalidName_ThrowsArgumentException()
        {
            var contributor = new Contributor()
            {
                Id = 1,
                Email = EMAIL,
                Name = string.Empty,
                Phone = PHONE
            };

            Exception ex = Assert.Throws<ArgumentException>(() => service.Update(contributor));

            Assert.Contains("Invalid name.", ex.Message);
        }

        [Fact]
        public void Update_InvalidPhone_ThrowsArgumentException()
        {
            var contributor = new Contributor()
            {
                Id = 1,
                Email = EMAIL,
                Name = NAME,
                Phone = 0
            };

            Exception ex = Assert.Throws<ArgumentException>(() => service.Update(contributor));

            Assert.Contains("Phone should a 10 digit number. Phone is lower than expected.", ex.Message);

            contributor.Phone = 10000000000;

            ex = Assert.Throws<ArgumentException>(() => service.Update(contributor));

            Assert.Contains("Phone should be a 10 digit number. Phone is grater than expected.", ex.Message);

        }

        [Fact]
        public void Update_ValidContributor_UpdatesContributor()
        {
            var contributor = new Contributor()
            {
                Email = EMAIL,
                Name = NAME,
                Phone = PHONE
            };

            service.Create(contributor);

            contributor = service.Get(contributor.Id);

            Assert.True(contributor.Name == NAME);
            Assert.True(contributor.Email == EMAIL);
            Assert.True(contributor.Phone == PHONE);

            contributor.Name = NEWNAME;
            contributor.Email = NEWEMAIL;
            contributor.Phone = NEWPHONE;

            service.Update(contributor);

            contributor = service.Get(contributor.Id);

            Assert.True(contributor.Name == NEWNAME);
            Assert.True(contributor.Email == NEWEMAIL);
            Assert.True(contributor.Phone == NEWPHONE);
        }

        [Fact]
        public void Delete_InvalidId_ThrowsArgumentOutOfRangeException()
        {
            var contributor = new Contributor()
            {
                Id = 0
            };

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => service.Delete(contributor));

            Assert.Contains("id must be an integer greater than 0", ex.Message);
        }

        [Fact]
        public void Delete_UnexistingId_ThrowsArgumentOutOfRangeException()
        {
            var contributor = new Contributor()
            {
                Id = 2147483647
            };

            Exception ex = Assert.Throws<InvalidOperationException>(() => service.Delete(contributor));

            Assert.Contains("Cannot delete entity because it does not exist.", ex.Message);
        }

        [Fact]
        public void Delete_ExistingId_DeletesEntry()
        {
            var contributor = new Contributor()
            {
                Name = NAME, 
                Email = EMAIL, 
                Phone = PHONE
            };

            service.Create(contributor);
            service.Delete(contributor);
        }

    }
}
