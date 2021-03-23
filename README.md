# SQL

#### Layout:

- [DatabaseAdapter](#DatabaseAdapter)

  - [Constructors](#Construtors)

  - [Methods](#Methods)

  - [Exceptions](#Exceptions)

  - <a href="#Syntax Examples">Syntax Examples</a>

    

## DatabaseAdapter

DatabaseAdapter class makes communication from the application to the database as easy as possible. For example, data can be retrieved, inserted, deleted and updated with or without transactions.

If you want to use a method of DatabaseAdapter class you will have to create an instance of the class first. This is for passing the connection string to the class.

<a href="https://www.connectionstrings.com/" target="_blank">List of every connection string</a>



### Construtors

| Call syntax                                    | Return type                 | Description                                                  |
| ---------------------------------------------- | --------------------------- | ------------------------------------------------------------ |
| `new DatabaseAdapter(string connectionString)` | Intance of DatabaseApdapter | This constructor ensures that connection string is known for this new instance. Returns a new intance of DatabaseAdapter |



### Methods

| Methode name                                                 | Return type | Description                                                  |
| ------------------------------------------------------------ | ----------- | ------------------------------------------------------------ |
| `GetDataTable(string sqlQuery)`                              | `DataTable` | With this method you can select data from a database with a select query. Returns a datatable with the requested data. |
| `GetDataTable(string sqlQuery)`                              | `DataSet`   | With this method you can select data from a database with a select query. Returns a dataset with the requested data. |
| `ChangeData(string sqlQuery)`                                | `int`       | With this method you can add / update / remove data from a database with a SQL query. Return a count of affected rows in the database. |
| `ChangeAndGetValue(string sqlQuery)`                         | `object`    | With this method you can select / add / update / delete data from a database with a SQL query. **Returns only one value**. So this method can be used to call the `Count (*)` function or create an insert / update / delete with output clause in the query or for a select that only returns one value. |
| `Transaction(IEnumerable<string> sqlQuerys, string transactionName)` | `int`       | This execute queries the database via a transaction so that all queries are always executed or rolled back to current state. Return a count of affected rows in the database. |



### Exceptions

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

  ```c#
  System.Data.DataException: 'The Transaction could not be established'
  ```

  ```c#
  System.Data.DataException: 'The Transaction could not be established and a rollback has failed!'
  ```






### Syntax Examples

- ##### `DatabaseAdapter(string connectionString)`

  This constructor ensures that connection string is known for this new instance. Returns a new intance of DatabaseAdapter

  ```c#
  using SQL;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  ...
  ```

  

- ##### `GetDataTable(string sqlQuery)`

  With this method you can select data from a database with a select query. Returns a datatable with the requested data.

  ```c#
  using SQL;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  DataTable dt = database.GetDataTable("[YOUR SELECT QUERY]");
  ...
  ```

  

- ##### `GetDataSet(string sqlQuery)`

  With this method you can select data from a database with a select query. Returns a dataset with the requested data.

  ```c#
  using SQL;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  DataSet ds = database.GetDataSet("[YOUR SELECT QUERY]");
  ...
  ```

  

- ##### `ChangeData(string sqlQuery)`

  With this method you can add / update / remove data from a database with a SQL query. Return a count of affected rows in the database.  

  ```c#
  using SQL;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  int affectedRows = database.ChangeData("[YOUR SQL QUERY]");
  
  Console.WriteLine($"There are {affectedRows} affected rows");
  ...
  // OUTPUT: There are 5 affected rows
  
  
  ```




- ##### `ChangeAndGetValue(string sqlQuery)`

  With this method you can select / add / update / delete data from a database with a SQL query. **Returns only one value**. So this method can be used to call the `Count (*)` function or create an insert / update / delete with output clause in the query or for a select that only returns one value.

  ```c#
  using SQL;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  object result = database.ChangeAndGetValue("[YOUR SQL QUERY]");
  
  Console.WriteLine($"The query resulted in {object}");
  ...
      
  //EXAMPLE OUTPUT: The query resulted in 205
  ```

  

- ##### `Transaction(IEnumerable<string> sqlQuerys, string transactionName)`

  This execute queries the database via a transaction so that all queries are always executed or rolled back to current state. Return a count of affected rows in the database.

  ```c#
  using SQL;
  ...
  DatabaseAdapter database = new("[YOUR CONNECTION STRING]");
  int affectedRows = database.Transaction("[YOUR LIST OF SQL QUERYS], [A NEW TRANACTION NAME]");
  
  Console.WriteLine($"There are {affectedRows} affected rows");
  ...
  // OUTPUT: There are 31 affected rows
  ```

  



##### 



###### 

