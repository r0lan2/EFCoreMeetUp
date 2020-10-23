using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Data;
using Data.Models;
using DataTests.Helpers;
using EFCore.BulkExtensions;
using Xunit;
using Xunit.Abstractions;

namespace DataTests.Perfomance
{
    public class BigInsert:TestBase
    {

        public BigInsert(ITestOutputHelper output):base(output)
        {
        }

        [Fact]
        public void Adding2MOfBlogsUsingExtensions()
        {
            var blogs = DataSeeder.GetBlogs(2000000);
            var options = this.SetupOptions(seedData: false);
            using var context = new BloggingContext(options);
          
            context.BulkInsert(blogs);
        }

        //[Fact]
        //public void Adding2MOfBlogsUsingEfCore()
        //{
        //    var blogs = DataSeeder.GetBlogs(2000000);
        //    var options = this.SetupOptions(seedData: false);

        //    using var context = new BloggingContext(options);
          
            
        //}


        




    }
}




