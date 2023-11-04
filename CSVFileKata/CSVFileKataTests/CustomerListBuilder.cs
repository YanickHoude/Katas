using NUnit.Framework;
using NSubstitute;
using CSVFileKata;
using Castle.Core.Resource;
using System;

namespace CSVFileKataTests
{
	public class CustomerListBuilder
	{
		private int _numberOfCustomers;

		public CustomerListBuilder WithCustomers(int numberOfCustomers)
		{
			this._numberOfCustomers = numberOfCustomers;
            return this;
		}

		public List<Customer> Build()
		{
            var customerList = new List<Customer>();
            var seed = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < _numberOfCustomers; i++)
            {
                var cust = new string(Enumerable.Repeat(chars, 10).Select
                    (s => s[seed.Next(s.Length)]).ToArray());

                customerList.Add(GenerateCustomer(cust, seed.Next().ToString()));
            }

            return customerList;
        }


        private static Customer GenerateCustomer(string name, string contactNumber)
        {
            return new Customer
            {
                Name = name,
                ContactNumber = contactNumber
            };
        }
    }
}

