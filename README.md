# SQL

#### Indeling:

- DatabaseAdapter

## DatabaseAdapter

DatabaseAdapter class makes communication from the application to the database as easy as possible. For example, data can be retrieved, inserted, deleted and updated with or without transactions.

If you want to use a method of DatabaseAdapter class you will have to create an instance of the class first. This is for passing the connection string to the class.

<a href="https://www.connectionstrings.com/" target="_blank">List of every connection string</a>



- ##### `DatabaseAdapter(string connectionString)`

  This constructor ensures that connection string is known for this instance. 

  ```c#
  using SQL;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  ...
  ```

  

- ##### `GetDataTable(string sqlQuery)`

  With a select query, this method returns a table with the requested data. 

  ```c#
  using CommonClasses;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  DataTable dt = database.GetDataTable("[YOUR SELECT QUERY]");
  ...
  ```

  

- ##### `GetDataSet(string sqlQuery)`

  With a select query, this method returns a dataset with the requested data.

  ```c#
  using CommonClasses;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  DataSet ds = database.GetDataSet("[YOUR SELECT QUERY]");
  ...
  ```

  

- ##### `ChangeData(string sqlQuery)`

  With this method you can add / update / remove data from a database with a SQL query. And it displays the number of modified / new / deleted rows in an integer.

  ```c#
  using CommonClasses;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  int affectedRows = database.ChangeData("[YOUR SQL QUERY]");
  
  Console.WriteLine($"There are {affectedRows} affected rows");
  ...
  // OUTPUT: There are 5 affected rows
  
  
  ```




- ##### `ChangeAndGetValue(string sqlQuery)`

  With this method you can select / add / update / delete data from a database with a SQL query. **This returns only one value**. So this method can be used to call the `Count (*)` function or create an insert / update / delete with output clause in the query or for a select that only returns one value.

  ```c#
  using CommonClasses;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  object result = database.ChangeAndGetValue("[YOUR SQL QUERY]");
  
  Console.WriteLine($"The query resulted in {object}");
  ...
      
  //EXAMPLE OUTPUT: The query resulted in 205
  ```

  



- ##### `Exceptions`

  

  - ###### `NullReferenceException`

    The connection string is `Null` or is an empty string. Check the constructor of this instance.

    ```c
    System.NullReferenceException: 'The connection could not be established because connection string was empty'
    ```

    

  - ###### `DataException`

    Something went wrong while executing the SQL query, see the `InnerException` for more information or the error that occurred.

    ```c#
    System.Data.DataException: 'The data could not be received'
    ```

    ```c#
    System.Data.DataException: 'The change could not be established'
    ```

    

- 