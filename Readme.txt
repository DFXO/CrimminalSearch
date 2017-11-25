1. Step to create and initialise the database

	1) Open the CriminalDatabase.sql file from AbhishekBande-CSharpAssignment\CriminalDatabase.sql.
	2) Execute the scripts from the file in to SQL server 2008/2012. 

2. Step to prepare the source code to build properly
	1) Open the solution file from AbhishekBande-CSharpAssignment\Source\NationalCriminal.Search.Service.sln in Visual studio 2012.
	2) Configuration Settings->
		1. Open web.config file from Abhishek_Bande-CSharpAssignment\Source\NationalCriminal.Search.Service\web.config
		    Set values for the below mentioned keys
	            MaxMailAttachmentCount -> This is the used to set the maximum limit of mail which can be sent per mail.
	            SmtpServerName - > Smtp server mail for sending email.
		    Port -> port number of mailing server provider
		    AdminMailId -> Mail id from which Mail for searched criminals should send.
		    AdminMailPassword - >Mail Password
		    PdfFileStoragePath - > Path to keep the generated pdf files.
		    MaxResultCount - > If in search criteria user has not the max results then this count will be used as by default.

		2. Open the app.config from Abhishek_Bande-CSharpAssignment\Source\NationalCriminal.Search.Service.DataAccess\app.config
		   Add the database connection string which you can get after step 1.  

	2) Go to Debug menu ,Select option start without debugnning.
	3) Login page will get displayed.
	4) You can register yourself by clicking on register link.
	5) After successful registration you will be auto redirected to search engine where you need to specify your search criteria.
	6) Once done with specifying criteria click on confirm button to freeze your search criteria.

3. Assumptions made and missing requirements that are not covered in the requirements
	Assumptions:
	1) All the search parameters are optional.
	2) If user has not set the max result count then we are configuring the default count for filtering results.
	3) Maximum pdf per mail is configurabe as said in spep 2.1

4. Feedback to improve the assignment
 	NA