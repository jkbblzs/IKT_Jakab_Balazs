using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace Payment_wcf
{
    public class Service1 : IService1
    {
        static List<Customer> cust = new List<Customer>();
        public Customer getCustomer(string id)
        {
            int identity = 0;
            for (int i = 0; i < cust.Count; i++)
            {
             
                if (cust[i].Id == int.Parse(id))
                {
                    identity = i;
                }
            }

            return cust[identity];
        }

        public List<Customer> getCustomers()
        {
            return cust;
        }

        public Customer postCustomer(string id, string name, string city)
        {
            Customer c = new Customer();
            c.Id = int.Parse(id);
            c.Name = name;
            c.City = city;

            cust.Add(c);

            return c;
        }

        public Customer postCustomerPostman(Customer customer)
        {
  
            cust.Add(customer);
            return customer;
        }

        public string deleteCustomer(string id)
        {
            int identity = 0;
            for (int i = 0; i < cust.Count; i++)
            {

                if (cust[i].Id == int.Parse(id))
                {
                    identity = i;
                    break;
                }


            }
            cust.RemoveAt(identity);
            return "Felhasználó törölve!";
        }
        public Customer putCustomer(string id, string name, string city)
        {
            int identity = 0;
            for (int i = 0; i < cust.Count; i++)
            {

                if (cust[i].Id == int.Parse(id))
                {
                    identity = i;
                }
            }

            cust[identity].Name = name;
            cust[identity].City = city;

            return cust[identity];
        }
    }
}
