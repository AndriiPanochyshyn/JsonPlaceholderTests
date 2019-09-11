using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using NUnit.Framework;

namespace API.Tests
{
    [TestFixture]
    internal class Tests
    {
        [Test]
        public async Task Test1()
        {
            await JsonPlaceholderHttpClient.GetAsync<User>("http://jsonplaceholder.typicode.com/users");
        }
    }
}
