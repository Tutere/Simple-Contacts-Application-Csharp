using System;
namespace LanguagesAssessmentCSharp
{
	public class Contact	
	{
		public string Name { get; set;}
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, String phoneNumber, String email)
		{
			this.Name = name;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
		}

		public override string ToString ()
		{
			return this.Name + ", " + this.PhoneNumber + ", " + this.Email;
        }
	}
}

