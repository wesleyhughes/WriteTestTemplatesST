using API;
using System;
using TbhPageObjects;
using Xunit;

namespace Tests
{
    public class ExecuteTests : BaseTest
    {
        ApiHelpers apiHelpers = new ApiHelpers();
            
        string testCompany = "sysdev - oneamerica eoi";
            
        [Fact]
        public void RunAll()
        {
            apiHelpers.RunTestAndPostResult(new Action[]{
                GoodHWHealthQEqualsYesAllPendQEqualsYes, 
                GoodHWEEPlusSPPendQuestionForSpouseOnlyMultipleProducts, 
                GoodHWEEPendQuestionForEEOnlyForMultipleProducts, 
                GoodHWHealthQEqualsNoAllPendQEqualsNO, 
                GoodHWHealthQEqualsNoAllPendQEqualsNOOverMCA, 
                GoodHWSomeHealthQEqualsYesAllPendQEqualsNO, 
                BadEEHWHealthQEqualsNoAllPendQEqualsNO, 
                BadSPHWHealthQEqualsNoAllPendQEqualsNO, 
                },
                new int[]{40038,40047,40049,41204,41209,41228,41233,41235},
                39967 , 8096, this.GetType().Name);
        }
        [Fact]
        //40038 - Good H/W Health Q=Yes All Pend Q=Yes
        public void GoodHWHealthQEqualsYesAllPendQEqualsYes()
        {
            
        }
        [Fact]
        //40047 - Good H/W EE+SP Pend Question for Spouse Only Multiple Products
        public void GoodHWEEPlusSPPendQuestionForSpouseOnlyMultipleProducts()
        {
            
        }
        [Fact]
        //40049 - Good H/W EE Pend Question for EE Only for Multiple Products
        public void GoodHWEEPendQuestionForEEOnlyForMultipleProducts()
        {
            
        }
        [Fact]
        //41204 - Good H/W Health Q=No All Pend Q=NO
        public void GoodHWHealthQEqualsNoAllPendQEqualsNO()
        {
            
        }
        [Fact]
        //41209 - Good H/W Health Q=No All Pend Q=NO Over MCA
        public void GoodHWHealthQEqualsNoAllPendQEqualsNOOverMCA()
        {
            
        }
        [Fact]
        //41228 - Good H/W Some Health Q=Yes All Pend Q=NO
        public void GoodHWSomeHealthQEqualsYesAllPendQEqualsNO()
        {
            
        }
        [Fact]
        //41233 - Bad EE H/W Health Q=No All Pend Q=NO
        public void BadEEHWHealthQEqualsNoAllPendQEqualsNO()
        {
            
        }
        [Fact]
        //41235 - Bad SP H/W Health Q=No All Pend Q=NO
        public void BadSPHWHealthQEqualsNoAllPendQEqualsNO()
        {
            
        }
    }
}
