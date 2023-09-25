# CreateAndAccessDatabase
Noroff Fullstack course: BackEnd Assignment 2

## AUTHORS:
* Ali Hassan Raza (ahraza.devOps@gmail.com)
* Pau Go Si (paugosi@hotmail.com)

### CreateAndAccessDatabase Folder:
Contains two folders Appendix A and Appendix B.

## APPENDIX A Folder:
Appendix A contains 9 SQL queries which solves the requirements from Assignment 2 Appendix-A. The aim of this part of the assignment was to get hands-on experience 
writing SQL queries that deals with some basic topics within SQL such as creating a database, creating a table in a database, 
inserting values in the table of the database, updating the table in the database and deleting the table in the database plus  
learn about relationships between entities by using primary keys and foreign keys. The tool we used was Microsoft SQL Server Management Studio.

## APPENDIX B Folder:
Appendix B deals with manipulating SQL Server data in Visual Studio using a library 
called SQL Client. For this part of the assignment, we are given a database to work with. It is called Chinook.
Chinook models the iTunes database of customers purchasing songs. The task was to create a C# console 
application, install the SQL Client library, and create a repository to interact with the database.

Appendix B folder contatins a Models folder, a Repositories folder and a program.cs file. The Models folder reprersents classes for each data structure we use.
The repository folder contains interface and a customerRepository class which contains all the written methods to solve the assignment 2 Appendix B requirements.
The program.cs file contains display methods, and it can be run to test and display all the 9 exersizes from Appendix B.

OBS! The Repositories folder also contains a class ConnectionStringHelper, which contains a method GetConnectionString() to configure connection to the database. <br><br>
Please provide your database parameters in the method GetConnectionString() to establish connection to your database.
