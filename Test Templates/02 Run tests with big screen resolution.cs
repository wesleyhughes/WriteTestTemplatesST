using API;
using System;
using TbhPageObjects;
using Xunit;

namespace Tests
{
    public class RunTestsWithBigScreenResolution : BaseTest
    {
        ApiHelpers apiHelpers = new ApiHelpers();
            
        string testCompany = "SysDev - Simple Full Walkthrough";
        string testCompany2 = "SysDev - One America";
        string testCompany3 = "SysDev - OneAmerica EOI";
        string testCompany4 = "SysDev - One America EOI";
            
        [Fact]
        public void RunAll()
        {
            apiHelpers.RunTestAndPostResult(new Action[]{
                EditBeneficiaryOnBeneficiaryInformationPageSystemUser, 
                Page1BeneficiaryTableAndUpdatingInstructionsFullScreen, 
                Page1BeneficiaryFormAppearsAfterClickingADDBeneficiaryFullScreen, 
                Page1VerificationOfSelectDependentDDLFunctionFullScreen, 
                Page2DesignationOnceForAllProductsTotalRowFullScreen, 
                BeneficiaryInstructionsOnBeneficiaryInformationPageRequireBeneficiaryDesignationEqualsYes, 
                BeneficiaryInstructionsOnBeneficiaryInformationPageRequireBeneficiaryDesignationEqualsNo, 
                TooltipOnBeneficiaryInformationPageRequireBeneficiaryDesignationEqualsNo, 
                ExpandAllLinkIsResponsive2Products, 
                ExpandAllLinkIsResponsive1Product, 
                Page2PrimaryHas10XPaddingFullScreen, 
                Page2HoverTextUpdatedOnTheInformationIconFullScreen, 
                Page1AddAlertBoxPriorToDeletingABeneficiaryFullScreen, 
                },
                new int[]{37218,37235,37240,37254,37288,37291,37292,37327,37942,37945,37951,37958,37968},
                38450 , 8096, this.GetType().Name);
        }
        [Fact]
        //37218 - "Edit Beneficiary" on Beneficiary Information page - System User
        public void EditBeneficiaryOnBeneficiaryInformationPageSystemUser()
        {
            
        }
        [Fact]
        //37235 - Page 1: Beneficiary Table and updating Instructions Full Screen.
        public void Page1BeneficiaryTableAndUpdatingInstructionsFullScreen()
        {
            
        }
        [Fact]
        //37240 - Page 1: Beneficiary Form appears after clicking ADD Beneficiary Full Screen.
        public void Page1BeneficiaryFormAppearsAfterClickingADDBeneficiaryFullScreen()
        {
            
        }
        [Fact]
        //37254 - Page 1: Verification of Select Dependent DDL function Full Screen.
        public void Page1VerificationOfSelectDependentDDLFunctionFullScreen()
        {
            
        }
        [Fact]
        //37288 - Page 2: Designation Once for All Products Total Row Full Screen.
        public void Page2DesignationOnceForAllProductsTotalRowFullScreen()
        {
            
        }
        [Fact]
        //37291 - "Beneficiary Instructions" on Beneficiary Information page - Require Beneficiary Designation = Yes
        public void BeneficiaryInstructionsOnBeneficiaryInformationPageRequireBeneficiaryDesignationEqualsYes()
        {
            
        }
        [Fact]
        //37292 - "Beneficiary Instructions" on Beneficiary Information page - Require Beneficiary Designation = No
        public void BeneficiaryInstructionsOnBeneficiaryInformationPageRequireBeneficiaryDesignationEqualsNo()
        {
            
        }
        [Fact]
        //37327 - "Tooltip" on Beneficiary Information page - Require Beneficiary Designation = No
        public void TooltipOnBeneficiaryInformationPageRequireBeneficiaryDesignationEqualsNo()
        {
            
        }
        [Fact]
        //37942 - "Expand All" link is responsive - 2 products
        public void ExpandAllLinkIsResponsive2Products()
        {
            
        }
        [Fact]
        //37945 - "Expand All" link is responsive - 1 product
        public void ExpandAllLinkIsResponsive1Product()
        {
            
        }
        [Fact]
        //37951 - Page 2: Primary % has 10X Padding-Full Screen
        public void Page2PrimaryHas10XPaddingFullScreen()
        {
            
        }
        [Fact]
        //37958 - Page 2: Hover Text updated on the Information Icon Full Screen
        public void Page2HoverTextUpdatedOnTheInformationIconFullScreen()
        {
            
        }
        [Fact]
        //37968 - Page 1: Add Alert Box Prior to Deleting a Beneficiary Full Screen
        public void Page1AddAlertBoxPriorToDeletingABeneficiaryFullScreen()
        {
            
        }
    }
}
