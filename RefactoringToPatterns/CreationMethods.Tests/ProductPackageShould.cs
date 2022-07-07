using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = ProductPackage.CreateInternet();

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoip()
        {
            var productPackage = ProductPackage.CreateInternetAndVoip();

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var productPackage = ProductPackage.CreateInternetAndTv();

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVoipAndTv()
        {
            var productPackage = ProductPackage.CreateInternetAndVoipAndTv();

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }
    }
}