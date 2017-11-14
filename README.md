# Pyrus.ApiClient

[![NuGet version](https://badge.fury.io/nu/Pyrus.ApiClient.svg)](https://badge.fury.io/nu/Pyrus.ApiClient)

The Pyrus API provides a .NET implementation of core API methods. To get started, you must do the following:

## Getting Started

* Install the Pyrus.API library using the nuget package manager

````
Install-Package Pyrus.ApiClient
````

* Specify proxy settings if necessary

```csharp
PyrusClient.Settings.ProxyIp = "127.0.0.1";
PyrusClient.Settings.ProxyPort = "8080";
PyrusClient.Settings.ProxyUserName = "UserName";
PyrusClient.Settings.ProxyPassword = "P@ssw0rd";
```

* Create an API client

```csharp
var pyrusClient = new PyrusClient();
```

* Perform authorization 

```csharp
var authResponse = await pyrusClient.Auth(
  "pyrus@login.com", 
  "security_key_from_profile");
```

Now you're ready to use other API methods.

## Forms

* Get all form templates
  
```csharp
var formsResponse = await pyrusClient.GetForms();
var forms = formsResponse.Forms;
```

* Get tasks list by form template
  
```csharp
var formId = 14653;
var formRegisterRequest = new FormRegisterRequest
{
  IncludeArchived = true,
  Filters = new FormFilter[]
  {
    new EqualsFilter(5, new FilterValue(253)),
    new GreaterThanFilter(
       2, 
       new FilterValue(DateTime.Today.AddDays(-5)))
  }
};

var formRegisterResponse = await pyrusClient.GetRegistry(formId, formRegisterRequest);

var tasks = formRegisterResponse.Tasks;
```

## Tasks

* Get task with all comments

```csharp
var taskId = 15353;
var taskResponse = await pyrusClient.GetTask(taskId);
var task = taskResponse.Task;
```

* Add task comment

```csharp
var taskId = 15353;
var taskComment = new TaskCommentRequest
{
  ApprovalChoice = ApprovalChoice.Approved,
  FieldUpdates = new FormField[]
  {
    new FormFieldTable
    {
      Id = 1,
      Value = new []
      {
        new TableRow
        {
          RowId = 15,
          Cells = new FormField[]
          {
            new FormFieldText
            {
              Name = "Comment",
              Value = "That's right"
            }
          }
        }
      }
    } 
  }
};

var taskResponse = await pyrusClient.CommentTask(taskId, taskComment);
```

* Create a task
  
```csharp
var taskRequest = new TaskRequest
{
  Text = "Help me",
  Participants = new []
  {
    new Person {Email = "Amanda.Smith@gmail.com"}, 
    new Person {Id = 1646}
  },
  DueDate = DateTime.Today.AddDays(2)
};

var taskResponse = await pyrusClient.CreateTask(taskRequest);
```

## Files

* Upload a file

```csharp
var fileName = @"C:\path\to\file";
var fileResponse = await pyrusClient.UploadFile(fileName);
var fileId = fileResponse.Guid;
```

## Catalogs

* Get catalog with all items

```csharp
var catalogId = 1525;
var catalogResponse = await pyrusClient.GetCatalog(catalogId);
var items = catalogResponse.Items;
```

## Contacts

* Get all available contacts

```csharp
var contactsResponse = await pyrusClient.GetContacts();
```
