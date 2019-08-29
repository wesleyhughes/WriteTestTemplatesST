using API;
using System;
using TbhPageObjects;
using Xunit;

namespace NewRepo
{
    public class  : BaseTest
    {
        ApiHelpers apiHelpers = new ApiHelpers();
        [Fact]
        public void RunAll()
        {
            apiHelpers.RunTestAndPostResult(new Action[]{
                },
                new int[]{},
                4 , 1, this.GetType().Name);
        }
    }
}
