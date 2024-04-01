# Send2Email
A simple application to send files of specified filetypes in the Pictures folder to a specified email address.
# Configuration
You will need to edit the cfg.json file with the necessary data and place it in
C:\Users\\[USER]\AppData\Local\Send2Email for each user that will be using the application.

//TODO: Create the cfg.json file automatically
//TODO: Create support for HTTP GET request to fetch cfg.json from a trusted server instead of having it available locally on the machine

##### SMTP_Host
* You'll need to connect to an SMTP Server host to send email.
* Default: smtp.google.com

##### SMTP_Port
* You'll need to connect to an SMTP Server port that is accepting traffic.
* The most common port for SMTP is 587, but if you're connecting to an older SMTP server it may be port 25, and if you're connecting to an SMTPS server that uses SSL it might be set to 465.
* Default: 587

##### SMTP_User
* This is the email address that you'll be logging into to send emails from.
* Default: N/A

##### SMTP_Pass
* This is the password for the SMTP_User that you'll be logging into to send emails from.
* This is also the password you'll use when you choose Edit > Config from the file menu to access a GUI editor for the cfg.json file. 
* Note you will need the cfg.json file to at least exist in the AppData folder, as the software will not run without detecting cfg.json.
* Default: N/A

##### Mail_From
* This is what will show in the "From" section of the email. This has only been tested with the same data as SMTP_User.
* Default: Same as SMTP_User

##### Mail_Subject
* This is what will show in the Subject line of the email.
* Default: "Mail Subject Text"

##### Mail_Body
* This is what will show in the Body line of the email.
* Default: "Mail Body Text"

##### Mail_Delivery
* This is the message that will pop up on screen once you have send the email.
* The end of this message will append a blank space and the {destination_email}
* You will not need to add a space or the destination email variable to your string.
* Default: "Mail Delivery Text"

##### File_Extensions
* This is what determines what types of files to send in the email.
* Comma separated list
* You do not need to include a period before the filetype
* Default: "jpg, jpeg, png, gif, bmp, tif, pdf"

The final file should look something like this.
```sh
{
  "SMTP_Host": "smtp.gmail.com",
  "SMTP_Port": 587,
  "SMTP_User": "email@company.com",
  "SMTP_Pass": "smtp_password",
  "Mail_From": "email@company.com",
  "Mail_Subject": "Mail Subject Text",
  "Mail_Body": "Mail Body Text",
  "Mail_Delivery": "Mail Delivery Text",
  "File_Extensions": "jpg, jpeg, png, gif, bmp, tif, pdf"
}
```

# Usage
Onve you've set up the cfg.json file Send2Email is a simple program, to use it you'll simply run it, and enter in an email address. Click send and it will attempt to attach each file in the User's Pictures directory as an attachment to that email, provided they are of the proper filetypes.





