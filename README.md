# Send2Email
A simple application to send files of specified filetypes in the Pictures folder to a specified email address. This was purpose built for the Muskingum County Library System to use with our Microfilm machines and as such it does not offer a robust configuration of options. With thtat said, Send2Email is available under the MIT license, feel free to distribute or modify this code to fit your needs.

# Configuration
Send2Email uses a cfg.json file with the necessary data and place it in
C:\Users\\[USER]\AppData\Local\Send2Email for each user that will be using the application. This file is generated if it is not detected and a setup window will open prompting the user to enter the configuration data.

##### SMTP_Host
* You'll need to connect to an SMTP Server host to send email.
* Default: smtp.google.com

##### SMTP_Port
* You'll need to connect to an SMTP Server port that is accepting traffic.
* The most common port for SMTP is 587, but if you're connecting to an older SMTP server it may be port 25, and if you're connecting to an SMTPS server that uses SSL it might be set to 465.
* Default: 587

##### SMTP_User
* This is the email address that you'll be logging into to send emails from.
* Default: "email@company.com"

##### SMTP_Pass
* This is the password for the SMTP_User that you'll be logging into to send emails from.
* The password is encrypted when saved to the config file.
* Default: ""

##### Mail_From
* This is what will show in the "From" section of the email. This has only been tested with the same data as SMTP_User.
* Default: "email@company.com"

##### Mail_Subject
* This is what will show in the Subject line of the email.
* Default: "Mail Subject Text"

##### Mail_Body
* This is what will show in the Body line of the email.
* Default: "Mail Body Text"

##### Config_Pass
* This is also the password you'll use when you choose File > Config from the file menu to access a GUI editor for the cfg.json file
* The password is encrypted when saved to the config file.
* Default: ""

##### File_Extensions
* This is what determines what types of files to send in the email.
* Comma separated list
* You do not need to include a period before the filetype
* Default: "jpg, jpeg, png, gif, bmp, tif, pdf"

##### Key_Public
* This is your public key for encrypting the password when saving the config file.
* Update this to an 8 character string using letters and numbers but not symbols.
* * <strong>You should also update the private_key variable in Program.cs to an 8 character string using letters and numbers but not symbols.</strong>

The final file should look something like this.
```json
{
  "SMTP_Host": "smtp.gmail.com",
  "SMTP_Port": 587,
  "SMTP_User": "email@company.com",
  "SMTP_Pass": "",
  "Mail_From": "email@company.com",
  "Mail_Subject": "Mail Subject Text",
  "Mail_Body": "Mail Body Text",
  "Config_Pass": "",
  "File_Extensions": "jpg, jpeg, png, gif, bmp, tif, pdf",
  "Key_Public": "byte8Key"
}
```

# Usage
Onve you've set up the cfg.json file Send2Email is a simple program, to use it you'll simply run it, and enter in an email address. Click send and it will attempt to attach each file in the User's Pictures directory as an attachment to that email, provided they are of the proper filetypes.

# License
Send2Email is available under the MIT License
```
MIT License

Copyright (c) 2025 The Muskingum County Library System

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```