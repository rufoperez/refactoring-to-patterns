using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = ProductPackage.CreateInternet("100MB");

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
            Assert.False(productPackage.HasCellNumber());
        }

        [Fact]
        public void CreateWithInternetAndVoip()
        {
            var productPackage = ProductPackage.CreateInternetAndVoip("100MB", 91233788);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
            Assert.False(productPackage.HasCellNumber());
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var productPackage = ProductPackage.CreateInternetAndTv("100MB", new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
            Assert.False(productPackage.HasCellNumber());
        }

        [Fact]
        public void CreateWithInternetVoipAndTv()
        {
            var productPackage = ProductPackage.CreateInternetAndVoipAndTv("100MB", 91233788, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
            Assert.False(productPackage.HasCellNumber());
        }

        [Fact]
        public void CreateWithInternetAndCell()
        {
            var productPackage = ProductPackage.CreateInternetAndCellNumber("100MB", 61233788);

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
            Assert.True(productPackage.HasCellNumber());
        }

        [Fact]
        public void CreateWithInternetAndCellAndTv()
        {
            var productPackage = ProductPackage.CreateInternetAndCellNumberAndTv("100MB", 61233788, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
            Assert.True(productPackage.HasCellNumber());
        }
    }
}