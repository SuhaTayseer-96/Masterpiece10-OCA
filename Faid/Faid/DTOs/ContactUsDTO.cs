namespace Faid.DTOs
{
    public class ContactUsDTO
    {
        // This will be used for non-logged-in users who fill out their name and email
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Subject { get; set; }
        public string Message { get; set; }

    }

    //public class UserDTO
    //{
    //    // Email and Name are already available here if the user is logged in
    //    public string Email { get; set; }
    //    public string UserName { get; set; }
    //}
}
