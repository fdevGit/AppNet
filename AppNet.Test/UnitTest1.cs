using System;
using AppNet.Domain.Models;
using AppNet.Repository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppNet.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AppNet.EFramework.AppDbContext context = new EFramework.AppDbContext();

            context.Roles.Add(new Domain.Models.Role()
            {
                Name = "Admin",
                CreatedBy = 0,
                CreateOn = DateTime.Now,
                ModifyBy = 0,
                ModifyOn = DateTime.Now,
                Status = true
            });

            context.SaveChanges();
        }

        [TestMethod]
        public void TestMethod2()
        {
            BaseRepository<Role> repository = new Repository.Repository.BaseRepository<Role>();

            repository.Activate(1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //RoleServices
        }
        [TestMethod]
        public void TestMethod4()
        {

        }
        [TestMethod]
        public void TestMethod5()
        {

        }
        [TestMethod]
        public void TestMethod6()
        {

        }
    }
}
