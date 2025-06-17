namespace Hospital_Project;

public class User:Human//a@gmail.com
{
    public User(string? name, string? surname, string? email, string? phone) : base(name, surname)
    {
        if(email!=null && email.Substring(email.Length-10,10)=="@gmail.com")
            Email = email;
        else
        {
            throw new Exception("Invalid email address");
        }
        Phone = phone;
    }

    public string? Email { get; set; }
    public string? Phone { get; set; }
}