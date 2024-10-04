using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application.Constants
{
    public static class ResponseMessages
    {
        public static string OperationSuccessful = "Operation Successful";
        public static string OperationFailed = "Operation Failed";
        public static string RecordExists = "Record already exist.";
        public static string NoRecordFound = "No Record found.";
        public static string BookNotAvailable = "Book is currently not available for reservation.";
        public static string ValidationFailed = "Validation failed";
        public static string BookReservedByAnotherCustomer = "Book reserved for another customer";
        public static string BookWasNotCollected = "Book was not collected.";
        public static string BookWasNotReserved = "Book is currently available for pickup.";


        public static string EmailAlreadyExist = "Email already exist.";
        public static string IncorrectUserDetails  = "Incorrect user details provided.";
        public static string AccountLockedOut  = "Your account has been temporarly locked out. Try again later.";


        public static string ErrorOccured  = "An Error Occured, please try again";
    }
}
