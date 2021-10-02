using System.Linq;

namespace SportsPro.Models
{
    public static class Check
    {
        public static string EmailExists(SportsProContext context, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email)) {
                var customer = context.Customers.FirstOrDefault(
                    c => c.Email.ToLower() == email.ToLower());
                if (customer != null) 
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
    }
}