using System;
using System.Configuration;
using System.Linq;
using shopveyor.core.order;
using shopveyor.core.products;
using Xunit;

namespace shopveyor.test
{
    public class BillTests : IClassFixture<UserFixture>
    {
        private readonly UserFixture _userFixture;
        private readonly decimal _discount;

        public BillTests(UserFixture userFixture)
        {
            _userFixture = userFixture;
            _discount = Convert.ToDecimal(ConfigurationManager.AppSettings["finaldiscount"]);
        }

        [Fact]
        public void Can_Create_Valid_Bill()
        {
            var bill = new Bill(_userFixture.NewCustomer);

            Assert.Equal(0, bill.OrderItems.Count());

            bill.AddToBill(new Product(25));
            bill.AddToBill(new Product(50));
            bill.AddToBill(new Product(75));
            bill.AddToBill(new Product(100));

            Assert.Equal(4, bill.OrderItems.Count());
            Assert.Equal(_userFixture.NewCustomer, bill.User);
        }

        [Fact]
        public void Customer_Under_2_Years_Bill_With_Non_Grocery_Products()
        {
            //This user doesn't receive any percentage discounts
            var bill = new Bill(_userFixture.NewCustomer);

            //No items in the bill
            Assert.Equal(0, bill.Total());

            //1 item worth $50
            bill.AddToBill(new Product(50));
            var expectedTotal = 50;
            Assert.Equal(expectedTotal, bill.Total());

            //2 items worth $990
            bill.AddToBill(new Product(940));
            expectedTotal = 990 - 45;
            Assert.Equal(expectedTotal, bill.Total());

            //3 Items worth $1040
            bill.AddToBill(new Product(50));
            expectedTotal = 1040 - 50;
            Assert.Equal(expectedTotal, bill.Total());

            //4 items worth 1100
            bill.AddToBill(new Product(60));
            expectedTotal = 1100 - (5 * 11);
            Assert.Equal(expectedTotal, bill.Total());
        }

        [Fact]
        public void Customer_Under_2_Years_Bill_With_Grocery_Products()
        {
            //This user doesn't receive any percentage discounts
            var bill = new Bill(_userFixture.NewCustomer);

            //No items in the bill
            Assert.Equal(0, bill.Total());

            //1 item worth $50
            bill.AddToBill(new Product(50, true));
            var expectedTotal = 50;
            Assert.Equal(expectedTotal, bill.Total());

            //2 items worth $990
            bill.AddToBill(new Product(940, true));
            expectedTotal = 990 - 45;
            Assert.Equal(expectedTotal, bill.Total());

            //3 Items worth $1040
            bill.AddToBill(new Product(50, true));
            expectedTotal = 1040 - 50;
            Assert.Equal(expectedTotal, bill.Total());

            //4 items worth 1100
            bill.AddToBill(new Product(60, true));
            expectedTotal = 1100 - (5 * 11);
            Assert.Equal(expectedTotal, bill.Total());
        }

        [Fact]
        public void Customer_Over_2_Years_Bill_With_Non_Grocery_Products()
        {
            //This user doesn't receive any percentage discounts
            var bill = new Bill(_userFixture.OldCustomer);
            var percentageDiscount = _userFixture.OldCustomer.Discount;

            //No items in the bill
            Assert.Equal(0, bill.Total());

            //1 item worth $50
            bill.AddToBill(new Product(50));
            var expectedTotal = (50 - (50 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //2 items worth $990
            bill.AddToBill(new Product(940.0M));
            expectedTotal = CalculateDiscount(990 - (990 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //3 Items worth $1040
            bill.AddToBill(new Product(50));
            expectedTotal = CalculateDiscount(1040 - (1040 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //4 items worth 1100
            bill.AddToBill(new Product(60));
            expectedTotal = CalculateDiscount(1100 - (1100 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());
        }

        [Fact]
        public void Customer_Over_2_Years_Bill_With_Non_Grocery_And_Grocery_Products()
        {
            //This user doesn't receive any percentage discounts
            var bill = new Bill(_userFixture.OldCustomer);
            var percentageDiscount = _userFixture.OldCustomer.Discount;

            //No items in the bill
            Assert.Equal(0, bill.Total());

            //1 item worth $50
            bill.AddToBill(new Product(50, true));
            var expectedTotal = 50.0M;
            Assert.Equal(expectedTotal, bill.Total());

            //2 items worth $990
            bill.AddToBill(new Product(940));
            expectedTotal = CalculateDiscount(990 - (940 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //3 Items worth $1040
            bill.AddToBill(new Product(50, true));
            expectedTotal = CalculateDiscount(1040 - (940 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //4 items worth 1100
            bill.AddToBill(new Product(60));
            expectedTotal = CalculateDiscount(1100 - (940 * percentageDiscount) - (60 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());
        }

        [Fact]
        public void Employee_Bill_With_Non_Grocery_And_Grocery_Products()
        {
            //This user doesn't receive any percentage discounts
            var bill = new Bill(_userFixture.Employee);
            var percentageDiscount = _userFixture.Employee.Discount;

            //No items in the bill
            Assert.Equal(0, bill.Total());

            //1 item worth $50
            bill.AddToBill(new Product(50, true));
            var expectedTotal = 50.0M;
            Assert.Equal(expectedTotal, bill.Total());

            //2 items worth $990
            bill.AddToBill(new Product(940));
            expectedTotal = CalculateDiscount(990 - (940 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //3 Items worth $1040
            bill.AddToBill(new Product(50, true));
            expectedTotal = CalculateDiscount(1040 - (940 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //4 items worth 1100
            bill.AddToBill(new Product(60));
            expectedTotal = CalculateDiscount(1100 - (940 * percentageDiscount) - (60 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());
        }

        [Fact]
        public void Affiliate_Bill_With_Non_Grocery_And_Grocery_Products()
        {
            //This user doesn't receive any percentage discounts
            var bill = new Bill(_userFixture.Affiliate);
            var percentageDiscount = _userFixture.Affiliate.Discount;

            //No items in the bill
            Assert.Equal(0, bill.Total());

            //1 item worth $50
            bill.AddToBill(new Product(50, true));
            var expectedTotal = 50.0M;
            Assert.Equal(expectedTotal, bill.Total());

            //2 items worth $990
            bill.AddToBill(new Product(940));
            expectedTotal = CalculateDiscount(990 - (940 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //3 Items worth $1040
            bill.AddToBill(new Product(50, true));
            expectedTotal = CalculateDiscount(1040 - (940 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());

            //4 items worth 1100
            bill.AddToBill(new Product(60));
            expectedTotal = CalculateDiscount(1100 - (940 * percentageDiscount) - (60 * percentageDiscount));
            Assert.Equal(expectedTotal, bill.Total());
        }

        private decimal CalculateDiscount(decimal total)
        {
            total -= ((int) total/100)*_discount;

            return total; 
        }
    }
}
