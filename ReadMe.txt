Introduction:

This document contains instructions on how to configure and install the 
downloaded ASPX application. It assumes that:

1. You have some basic knowledge of server and database technologies.
2. You have the IIS 5.0 web server.
3. You have database server as well.
4. You have .NET Framework SDK.

You should download the application. It's already compiled.
You should find the following components contained in the zip archive:

1. ASPX files as template files one per each page.
2. Binary stuff with code of application in the 'bin' subfolder.
3. A database file or a SQL script file that can be used to recreate 
   the database in the 'database' subfolder.
4. A folder containing images if applicable.

Installation:

The installation process is pretty straightforward and requires minimal 
adjustment of the application files. Proceed as follows:

1. Unzip the files into a folder within your web server hierarchy from 
   where the application will be served. Ensure that the folder name does 
   not have spaces in it. During the process of unzipping, make sure that 
   the files are unzipped to their respective folders. Don't simply open 
   the zip archive and drag all the files to the same folders. For the 
   application to work correctly, some files such as the image files need 
   to be in specific folders.

2. You need  to  create  the  Web Application  in the same folder,  in  which 
   you unzip files.  To do that:
     a) Open Internet Information Server managment console
     b) Find you folder in  the  list,  mouse  right click and select "Properties"
     c) Click on "Create Application" in  the " Directory"  Tab and enter 
        the name of  the new application.
   (Important: You should create  the Web Application for each example's folder. 
   You can not create  the application and unzip example into the subfolder)
 
3. Load Visual Studio Project.  To do that double click on the file 
   with .csproj extension. After the loading completion, press Ctrl+Shift+B,
   for the project compilation
   --or--
   Run MakeAll.bat, which placed in the same directory for the project compilation.
   

4. The next task is to alter the database connection string to reflect the 
   current location/name of the database. Follow the relevant instructions 
   below depending on the type of connection that you want to use:

   ODBC Connection

   To Configure an ODBC connection:

   (a) Use the ODBC option in Control Panel to setup a system DSN for the 
       application database. The database file is located in the main folder 
       of the application. In the interest of security, you can and are 
       encouraged to move the database file to a more secure location outside 
       the web server hierarchy. Your application will work fine as long as the
       DSN you configure points to the correct location of the database file. 
       Ensure that the DSN is a system DSN so that it will be available to all 
       users.

   (b) Open the file 'Config.web' which is in the main folder of your 
       application path.

   (c) Look for the connection string statement which begins with the word  
       '<add key="sDBConnectionString" ...'. Its basic format is:

       <add key="sDBConnectionString" value="Provider=MSDASQL;Persist Security Info=False;User ID=some_login;Data Source=some_data_source;Pwd=some_password" />

   (d) Using the guidelines below, change the statement to the following:

       <add key="sDBConnectionString" value="Provider=MSDASQL;Persist Security Info=False;User ID=Admin;Data Source=Bookstore" />
       where:

       Provider: It refers to the database provider to be used for the 
                 connection. For an MS Access database connection, this 
                 should be 'MSDASQL'. If left off, this option defaults 
                 to MSDASQL which is Microsoft's OLE DB Provider for ODBC,  
                 but you should explicitly specify it for the sake of clarity.

       Persist Security Info: Set this value to false to disallow saving of the
                 security information or true if you want the security 
                 information to be saved.

       User ID and Password: This is used to specify user authentication values. 
                 A user name of "Admin" and a blank password are the defaults.

       Data Source: This is the name of the ODBC DSN you created in Control Panel.

  Jet Database Connection

  Microsoft.Jet.OLEDB.4.0 is the OLE DB provider for Access. To connect to 
  an Access database using this provider, another attribute required to make 
  a connection is the Data Source attribute which is used to specify the full 
  path and the file name of the Access .mdb file. A minimal OLE DB Provider 
  for Jet connection string should look the following:

  strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\path\filename.mdb"

  For the security purposes, you might want to place your database file not 
  into the same folder where the web pages are located. For instance, you 
  could place your database into the folder c:\Projects\Databases\AccessDB.mdb 
  which is not in the web server hierarchy. The corresponding Jet connection 
  string for the above database should be:

  strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= c:\Projects\Databases\AccessDB.mdb"

  Other commonly used parameters are User ID and Password which are used to 
  specify thw user authentication values. A user name of "Admin" and a blank 
  password are the defaults, resulting in a connection string similarly to 
  that shown below:

  strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= c:\Projects\Databases\AccessDB.mdb; User ID=admin; Password="

