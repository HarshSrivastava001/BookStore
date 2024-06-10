# BookStore

Book Store API CRUD
Firstly BookModel.Sql Script Exicute in Your MSSQL Server and this File Located in BookStore Application and then change Your Connection String in App.WebConfig File


1. GET ALL Records : 
Method : GET
URL : https://localhost:44304/api/Book

2. GET Records By Id :
Method : GET
URL : https://localhost:44304/api/Book/<Your Id>

3. ADD Your Records :
Method : POST
URL : https://localhost:44304/api/Book
Request : 
{
  "Title": "Manisha",
  "Author": "Kumari",
  "PublishedDate": "2024-06-10T16:21:18.2470399+05:30",
  "ISBN": "MSI"
}

4. UPDATE Your Records :
Method : PUT
URL : https://localhost:44304/api/Book
Request : 
{
  "Id":"1"
  "Title": "Manisha",
  "Author": "Kumari",
  "PublishedDate": "2024-06-10T16:21:18.2470399+05:30",
  "ISBN": "MSI"
}

5. DELETE Your Records :
Method : Delete
URL : https://localhost:44304/api/Book/<Your Id>


