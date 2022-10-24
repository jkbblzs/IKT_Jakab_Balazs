using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Payment_wcf
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            UriTemplate = "getCustomer/{id}")
            ]
        Customer getCustomer(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedResponse,
           UriTemplate = "getCustomers")
           ]
        List<Customer> getCustomers();

        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedResponse,
           UriTemplate = "postCustomer/{id}/{name}/{city}")
           ]

        Customer postCustomer(string id, string name, string city);

        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedResponse,
           UriTemplate = "postCustomerPostman")
           ]
        Customer postCustomerPostman(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedResponse,
          UriTemplate = "deleteCustomer/{id}")
          ]

        string deleteCustomer(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.WrappedResponse,
         UriTemplate = "putCustomer/{id}/{name}/{city}")
         ]

        Customer putCustomer(string id, string name, string city);
    }

   
}
