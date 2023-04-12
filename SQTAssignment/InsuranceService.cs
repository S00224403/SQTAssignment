using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using NUnit.Framework.Internal;
using System.Net.NetworkInformation;

namespace SQTAssignment
{
    public interface IDiscountService
    {
        double GetDiscount();
    }

    public class InsuranceService
    {
        private readonly IDiscountService _discountService;

        public InsuranceService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public double CalcPremium(int age, string location)
        {
            double premium;
            if (location == "rural")
            {
                if (age >= 18 && age <= 30)
                    premium = 5.0;
                else if (age >= 31)
                    premium = 2.50;
                else
                    premium = 0.0;
            }
            else if (location == "urban")
            {
                if (age >= 18 && age <= 35)
                    premium = 6.0;
                else if (age >= 36)
                    premium = 5.0;
                else
                    premium = 0.0;
            }
            else
            {
                premium = 0.0;
            }

            double discount = _discountService.GetDiscount();

            if (age >= 50)
                premium *= discount;

            return premium;
        }
    }
    [TestFixture]
    public class InsuranceTest
    {
        [Test]
        public void CalcPremium_Returns5_WhenAgeIsBetween18And30AndLocationIsRural()
        {
            //arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);
            var insurance = new InsuranceService(mockDiscountService.Object);

            //act
            double premium = insurance.CalcPremium(18, "rural");

            //assert
            Assert.That(premium, Is.EqualTo(5));
        }
        [Test]
        public void CalcPremium_Returns2point5_WhenAgeIsGreaterThan30AndLocationIsRural()
        {
            //arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);
            var insurance = new InsuranceService(mockDiscountService.Object);

            //act
            double premium = insurance.CalcPremium(35, "rural");

            //assert
            Assert.That(premium, Is.EqualTo(2.5));
        }
        [Test]
        public void CalcPremium_Returns0_WhenAgeIsLessThan18AndLocationIsRural()
        {
            //arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);
            var insurance = new InsuranceService(mockDiscountService.Object);

            //act
            double premium = insurance.CalcPremium(16, "rural");

            //assert
            Assert.That(premium, Is.EqualTo(0));
        }
        /// <summary>
        /// Urban Tests
        /// </summary>
        [Test]
        public void CalcPremium_Returns6_WhenAgeIsBetween18And35AndLocationIsUrban()
        {
            //arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);
            var insurance = new InsuranceService(mockDiscountService.Object);

            //act
            double premium = insurance.CalcPremium(32, "urban");

            //assert
            Assert.That(premium, Is.EqualTo(6));
        }
        [Test]
        public void CalcPremium_Returns5_WhenAgeIsGreaterThan35AndLocationIsUrban()
        {
            //arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);
            var insurance = new InsuranceService(mockDiscountService.Object);

            //act
            double premium = insurance.CalcPremium(51, "urban");

            //assert
            Assert.That(premium, Is.EqualTo(2.5));
        }
        [Test]
        public void CalcPremium_Returns0_WhenAgeIsLessThan18AndLocationIsUrban()
        {
            //arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);
            var insurance = new InsuranceService(mockDiscountService.Object);

            //act
            double premium = insurance.CalcPremium(16, "urban");

            //assert
            Assert.That(premium, Is.EqualTo(0));
        }
        [Test]
        public void CalcPremium_Returns0_WhenAgeIsValidAndLocationIsNotValid()
        {
            //arrange
            var mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.5);
            var insurance = new InsuranceService(mockDiscountService.Object);

            //act
            double premium = insurance.CalcPremium(21, "country");

            //assert
            Assert.That(premium, Is.EqualTo(0));
        }
    }
}
