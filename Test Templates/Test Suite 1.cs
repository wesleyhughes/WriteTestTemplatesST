using API;
using System;
using TbhPageObjects;
using Xunit;

namespace Tests
{
    public class TestSuite1 : BaseTest
    {
        ApiHelpers apiHelpers = new ApiHelpers();
            
        [Fact]
        public void RunAll()
        {
            apiHelpers.RunTestAndPostResult(new Action[]{
                GoToGoogle, 
                },
                new int[]{1},
                5 , 4, this.GetType().Name);
        }
        [Fact]
        //1 - Go to google
        public void GoToGoogle()
        {
            
        }
    }
}
