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
var formsResponse = await RequestBuilder.GetForms().Process(pyrusClient);
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
var taskResponse = await RequestBuilder.GetTask(taskId).Process(pyrusClient);;
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
var fileResponse = await RequestBuilder.UploadFile(fileName).Process(pyrusClient);
var fileId = fileResponse.Guid;
```

## Catalogs

* Get catalog with all items

```csharp
var catalogId = 1525;
var catalogResponse = await RequestBuilder.GetCatalog(catalogId).Process(pyrusClient);
var items = catalogResponse.Items;
```

* Create catalog

```csharp
var catalogResponse = await RequestBuilder
	.CreateCatalog("NewCatalog")
	.SetHeaders("Header1", "Header2")
	.AddItem("A1", "A2")
	.AddItem("B1", "B2")
	.Process(pyrusClient);
	
var catalogId = catalogResponse.CatalogId;
```

* Sync catalog (All unspecified catalog items and text columns will be deleted)

```csharp
var catalogId = 1236
var updateCatalogResponse = await RequestBuilder
	.SyncCatalog(catalogId)
	.SetHeaders("Header1", "Header3")
	.AddItem("A1", "A3")
	.AddItem("C1", "C2")
	.ApplyChanges()
	.Process(pyrusClient);
```

## Contacts

* Get all available contacts

```csharp
var contactsResponse = await RequestBuilder.GetContacts().Process(pyrusClient);
```

## Lists

* Get all lists

```csharp
var listsResponse = await RequestBuilder.GetLists().Process(pyrusClient);
```

* Get all tasks in list

```csharp
var listId = 1322
var taskListResponse = await RequestBuilder.GetTaskList(listId, maxItemCount: 25, includeArchived:true).Process(pyrusClient);
```

## Roles

* Get all organization roles

```csharp
var rolesResponse = await RequestBuilder.GetRoles().Process(pyrusClient);
```

* Create role

```csharp
var roleResponse = await RequestBuilder.CreateRole("TechSupport")
    .AddMembers(1732, 4368)
    .Process(pyrusClient);
```

* Update role

```csharp
var roleResponse = await RequestBuilder.UpdateRole(6476)
    .AddMember(2434)
    .RemoveMembers(1732, 4368)
    .SetExternalId("CustomIdentifier")
    .Process(pyrusClient);
```

## Profile

* Get profile

```csharp
var profileResponse = await RequestBuilder.GetProfile().Process(pyrusClient);
```


## Inbox

* Get inbox

```csharp
var inboxResponse = await RequestBuilder.GetInbox(10).Process(pyrusClient);
```