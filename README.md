AlertMe
===================

A small application made in C# with the purpose of sending a email notification if someone tries to access one of your computers outside of predefined hours.

----------


Up and running
-------------

* ##### Clone the repo
* ##### Open the solution then build and run once
You should have now a bin/Debug folder that contains a **config.json** file which looks like this:

```javascript
{
	  "smtpHost": "mail.example.com",
	  "smtpPort": 587,
	  "smtpSSL": true,
	  "smtpUser": "username",
	  "smtpPass": "password",
	  "targetEmail": "test@example.com",
	  "hourRange": [
	    "09:00:00",
	    "18:00:00"
	  ],
	  "from": "username@example.com",
	  "subject": "[AlertMe] Detected new login outside allowed hour range",
	  "message": "Details about incident ... "
}
```
Fill in your details. 
---  I recommend to create a separate gmail account for this add 2 factor auth and phone verification to it and generate a app password that you will use here.

Use with EventViewer and Task Scheduler
-------------
I made a short video which you can follow.
In that case i was testing it against login/logout.
But the initial purpose was to capture the startup of the computer and other related events.

[![Demo Use with Task Scheduler and Event Viewer](https://j.gifs.com/MQ8MRR.gif)](https://youtu.be/wkZ06iXsd8o)


What can be added in the future:
-------------
* More details about the Machine ( processes, check the usb inputs )
* Logs
* Force Shutdown - either by running shutdown -t 00 or using [WMI]
* Maybe a gist based config. So i can change hours remotely
* Cam Capture  / Mic Recording ( if available ) 
*(https://stackoverflow.com/a/102583/4009545)
* Keylogger
* Disable KeyBoard & Mouse / Any other inputs. 
* Reset Browsers


Why?
-------------
Well ... I am a bit paranoid when it comes to my accounts and i decided to make something that i can use on my Work PC and get notified if there's other activity on the computer when i'm not at work / holiday. 