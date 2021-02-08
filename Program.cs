using System.Collections.Generic;
using MailKit.Net.Smtp;
using MimeKit;

namespace TestClient {
	class Program {
		public static void Main (string[] args) {
			//list of mails that you want to send to them, you can get the mails from a database
			List<string> l = new List<string> ();
			l.Add ("..@hotmail.com");
			l.Add ("..@gmail.com");
			l.Add ("..@hotmail.com");
			foreach (string mail in l) {

				var message = new MimeMessage ();
				//enter your mail and the address
				message.From.Add (new MailboxAddress ("Osman", "yourEMAIL@hotmail.com"));
				//the mail.tostring it reads from the list the mails and it sends them
				message.To.Add (new MailboxAddress ("Osman", mail.ToString ()));
				//the subject of the mail
				message.Subject = "How you doin'?";
				//the inside text of the mail
				message.Body = new TextPart ("plain") {
					Text = @"Hey friends,How are you ?"
				};
			
				using (var client = new SmtpClient ()) {
				//if your mail is hotmail or live your smtp server is : smtp.live.com, if it's @gmail it is : smtp.gmail.com
					client.Connect ("smtp.live.com", 587, false);
				//enter your mail and your password
					client.Authenticate ("yourEMAIL@hotmail.com", "password");
					client.Send (message);
					client.Disconnect (true);
				}
			
			}

		}
	}
}