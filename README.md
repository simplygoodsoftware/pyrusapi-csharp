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
var formRegisterResponse = await RequestBuilder
	.GetRegistry(formId)
	.IncludingArchived()
	.FilteredBy
	.Field(5).EqualsTo(253)
	.Field(2).GreaterThen(DateTime.Today.AddDays(-5))
	.Process(pyrusClient);

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
var taskResponse = await RequestBuilder
	.CommentFormTask(taskId)
	.Approve()
	.FieldUpdates.Add(
		FormField.Create<FormFieldTable>(1)
		.AddRow(15, new List<FormField>
			{
				FormField.Create<FormFieldText>("Comment").WithValue("Thhats's right")
			}))
	.Process(pyrusClient);
```

* Create a task
  
```csharp
var taskResponse = await RequestBuilder
	.CreateSimpleTask("Help me")
	.AddParticipant("Amanda.Smith@gmail.com")
	.AddParticipant(1646)
	.WithDueDate(DateTime.Today.AddDays(2))
	.Process(pyrusClient);
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

## Lists

* Get all lists

```csharp
var listsResponse = await pyrusClient.GetLists();
```

* Get all tasks in list

```csharp
var listId = 1322
var taskListResponse = await pyrusClient.GetTaskList(listId, maxTasksCount: 25, includeArchived:true);
```