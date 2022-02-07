## CSV Processor

CSV Processor is a library that allows the processing CSV files.

### Features

- Convert file to a DataTable
- Convert file to a List of .NET object
- Custom Processor with DataTable as input
- Define Column position with a custom .NET Attribute [csv(position: "0")]

### Getting Started

#### Installing from NuGet

Supported platforms: .NET Core 3.1

```batch
dotnet add package CsvProcessor
```

Browse the <a href="https://www.nuget.org/packages/CsvProcessor/">CsvProcessor on NuGet</a>.

#### Setup

Types are in the CsvProcessor namespace

```csharp
using CsvProcessor;
```

The root `Processor` is created using `CsvProcessor.Processor`.

```csharp
string path = "[CSV File Directory]";
Processor<FileTypes> processor = new Processor<FileTypes>(path, FileTypes.Countries);
```

_Note that `FileType` could be any enumerables that you have set in your project._

#### Usage

There are 3 ways to use treat a CSV file with the CsvProcessor
- Converting the file to a IEnumerable of .NET Object.
- Converting the file to a DataTable.
- Defining a custom processor.

A List of .NET Object can also be converted to a CSV

##### Converting the file to a List of .NET Object

Step 1: Defining the DataModel _(Example will be using an ISO standard CSV)_

```csharp
public class Country
{
    [Csv("0")]
    public string Name { get; set; }
    
    [Csv("1")]
    public string AlphaCode2 { get; set; }
    
    [Csv("2")]
    public string AlphaCode3 { get; set; }
    
    [Csv("3")]
    public int NumericalCode { get; set; }
    
    [Csv("4")]
    public double Latitude { get; set; }
    
    [Csv("5")]
    public double Longitude { get; set; }
}
```

_Note that we make use of the `CsvAttribute`, which takes only one parameter: `Position`, to define the column position of the different properties in the CSV File.

Step 2: Converting the CSV File to a `IEnumerable<Country>` which can later be converted to a `List<Country>` afterward if there's ever a need.

```csharp
string path = "[CSV File Directory]";
Processor<FileTypes> processor = new Processor<FileTypes>(path, FileTypes.Countries);
IEnumerable<Country> countries = processor.Execute<Country>();

//Optional to List
List<Country> countries = processor.Execute<Country>().ToList();
```

##### Converting the file to a DataTable

```csharp
string path = "[CSV File Directory]";
Processor<FileTypes> processor = new Processor<FileTypes>(path, FileTypes.Countries);
DataTable dt = processor.GetContentAsDataTable();
```

##### Defining a custom processor

Step 1: Defining the custom processor by inheriting the interface `IProcessor` which will automatically convert the file into a DataTable and will append `Column` with the column `Index`. For example, the first column in the file will be named `Column0`.

```csharp
public class CountryProcessor : IProcessor
{
  void IProcessor.Process(DataTable dt)
  {
    // Processor Logic after DataTable conversion
    foreach (DataRow row in datatable.Rows)
    {
      Country country = new Country()
      {
          Name = row["Column0"].ToString(),
          AlphaCode2 = row["Column1"].ToString(),
          AlphaCode3 = row["Column2"].ToString(),
          NumericalCode = Convert.ToInt32(row["Column3"].ToString()),
          Latitude = Convert.ToDouble(row["Column4"].ToString()),
          Longitude = Convert.ToDouble(row["Column5"].ToString())
      };
    }
  }
}
```

Step 2: Processing the file

```csharp
string path = "[CSV File Directory]";

FileTypeInit.FileTypes.Add(FileTypes.Countries, new CountryProcessor());

Processor<FileTypes> processor = new Processor<FileTypes>(path, FileTypes.Countries);
processor.Execute();
```

### Licensing

CSV Processor is open source under the MIT license and is free for commercial use.

### Thanks

Thanks to Shayl Sawmynaden for pitching the idea.
