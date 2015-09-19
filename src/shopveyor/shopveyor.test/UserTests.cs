using System;
using shopveyor.core.users;
using Xunit;

namespace shopveyor.test
{
    public class UserTests
    {
        [Fact]
        public void Employee_Has_Right_Discount_And_Join_Date()
        {
            var dateJoined = DateTime.UtcNow;

            var employee = new Employee(dateJoined);

            Assert.Equal(0.3M, employee.Discount);
            Assert.Equal(dateJoined, employee.DateJoined);
        }

        [Fact]
        public void Affiliate_Has_Right_Discount_And_Join_Date()
        {
            var dateJoined = DateTime.UtcNow;

            var affiliate = new Affiliate(dateJoined);

            Assert.Equal(0.1M, affiliate.Discount);
            Assert.Equal(dateJoined, affiliate.DateJoined);
        }

        [Fact]
        public void Customer_Has_Right_Discount_And_Join_Date_Under_2_Years()
        {
            var dateJoined = DateTime.UtcNow;

            //Customer should have a 0 discount rate
            var customer = new Customer(dateJoined);

            Assert.Equal(0.0M, customer.Discount);
            Assert.Equal(dateJoined, customer.DateJoined);

            dateJoined = dateJoined.Subtract(TimeSpan.FromDays(365));
            var customer2 = new Customer(dateJoined);

            Assert.Equal(0.0M, customer2.Discount);
            Assert.Equal(dateJoined, customer2.DateJoined);
        }

        [Fact]
        public void Customer_Has_Right_Discount_And_Join_Date_Over_2_Years()
        {
            //Join customer 2 years in to the future
            var dateJoined = DateTime.UtcNow.Subtract(TimeSpan.FromDays(365*2 + 1));

            var customer = new Customer(dateJoined);

            Assert.Equal(0.05M, customer.Discount);
            Assert.Equal(dateJoined, customer.DateJoined);

            dateJoined = dateJoined.Subtract(TimeSpan.FromDays(365));
            var customer2 = new Customer(dateJoined);

            Assert.Equal(0.05M, customer2.Discount);
            Assert.Equal(dateJoined, customer2.DateJoined);
        }

        [Fact]
        public void Cannot_Add_User_With_Future_Join_Date()
        {
            var dateJoined = DateTime.UtcNow.AddDays(1);

            Assert.Throws<ArgumentException>(() => new Customer(dateJoined));
            Assert.Throws<ArgumentException>(() => new Affiliate(dateJoined));
            Assert.Throws<ArgumentException>(() => new Employee(dateJoined));
        }
    }
}
