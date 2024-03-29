<a name='assembly'></a>
# xyLOGIX.Api.Data.Providers

## Contents

- [ApiDataProviderBase\`1](#T-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1')
  - [#ctor(repository)](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-#ctor-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository{`0}- 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.#ctor(xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository{`0})')
  - [#ctor()](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-#ctor 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.#ctor')
  - [MaxPageSize](#P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-MaxPageSize 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.MaxPageSize')
  - [PageSize](#P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-PageSize 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.PageSize')
  - [Repository](#P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Repository 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.Repository')
  - [UseRepository](#P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-UseRepository 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.UseRepository')
  - [#cctor()](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-#cctor 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.#cctor')
  - [Delete(recordToDelete)](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Delete-`0- 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.Delete(`0)')
  - [DeleteAll(predicate)](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-DeleteAll-System-Predicate{`0}- 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.DeleteAll(System.Predicate{`0})')
  - [Find(predicate)](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Find-System-Predicate{`0}- 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.Find(System.Predicate{`0})')
  - [Get(searchParams)](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Get-System-Object- 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.Get(System.Object)')
  - [GetAll()](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-GetAll 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.GetAll')
  - [InitializeRepository()](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-InitializeRepository 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.InitializeRepository')
  - [OnRepositoryIterationError(sender,e)](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-OnRepositoryIterationError-System-Object,xyLOGIX-Api-Data-Repositories-Events-IterationErrorEventArgs- 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.OnRepositoryIterationError(System.Object,xyLOGIX.Api.Data.Repositories.Events.IterationErrorEventArgs)')
  - [Update(recordToUpdate)](#M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Update-`0- 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase`1.Update(`0)')
- [Resources](#T-xyLOGIX-Api-Data-Providers-Properties-Resources 'xyLOGIX.Api.Data.Providers.Properties.Resources')
  - [Culture](#P-xyLOGIX-Api-Data-Providers-Properties-Resources-Culture 'xyLOGIX.Api.Data.Providers.Properties.Resources.Culture')
  - [ResourceManager](#P-xyLOGIX-Api-Data-Providers-Properties-Resources-ResourceManager 'xyLOGIX.Api.Data.Providers.Properties.Resources.ResourceManager')

<a name='T-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1'></a>
## ApiDataProviderBase\`1 `type`

##### Namespace

xyLOGIX.Api.Data.Providers

##### Summary

Defines the base implementation of an adapter around a API data set
repository object. This is analogous to the concept of a unit of work in terms
of databases. But given that APIs provide natively-paginated, with finite or
infinitely-many pages, and are rate-limited, this necessitates some fancy OOP
footwork.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type name of the POCO class that comes from the API
library and which represents a single record in the dataset of the target API. |

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-#ctor-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository{`0}-'></a>
### #ctor(repository) `constructor`

##### Summary

Constructs a new instance of
[ApiDatasetProviderBase](#T-PortfolioMonitor-Investments-ApiDatasetProviderBase 'PortfolioMonitor.Investments.ApiDatasetProviderBase') and
returns a reference to it.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| repository | [xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository{\`0}](#T-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository{`0} 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository{`0}') | (Required.) Reference to an instance of an object
that implements the
[IApiRepository](#T-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository')
interface. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') | Thrown if the required
parameter, `repository`, is passed a `null`
value. |

##### Remarks

This overload of the constructor is to be utilized when you want to
inject an existing `API Repository` object into this provider.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-#ctor'></a>
### #ctor() `constructor`

##### Summary

Constructs a new instance of
[ApiDataProviderBase](#T-xyLOGIX-Api-Data-Providers-ApiDataProviderBase 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase') and returns a
reference to it.

##### Parameters

This constructor has no parameters.

##### Remarks

Child classes generally should override this constructor to fill the
[Repository](#P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase-Repository 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase.Repository')
property with a freshly-constructed `API Repository` object on behalf of
the client.

<a name='P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-MaxPageSize'></a>
### MaxPageSize `property`

##### Summary

Gets or sets the maximum number of elements per page that the API
will allow to be fetched.

##### Remarks

This quantity is specified by nearly every REST API out there. This
property is set by a required constructor parameter.

<a name='P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-PageSize'></a>
### PageSize `property`

##### Summary

Gets or sets the page size, i.e., how many elements to request at a
time from the target REST API.

##### Remarks

The Find, Delete, DeleteAll, and Update methods, by default, iterate
through the target REST API data set a single element at a time.



Because we have to be careful about not hitting rate limits during these
operations, this property allows clients of this class to customize the number
of elements taken at a time to be different from 1 by setting this property.

<a name='P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Repository'></a>
### Repository `property`

##### Summary

Gets a reference to the object that implements the
[IApiRepository](#T-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository')
interface that provides this object's functionality.

<a name='P-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-UseRepository'></a>
### UseRepository `property`

##### Summary

Gets or sets a value saying whether to use a Repository with this
object.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-#cctor'></a>
### #cctor() `method`

##### Summary

Initializes static data or performs actions that need to be performed once only
for the [ApiDataProviderBase](#T-xyLOGIX-Api-Data-Providers-ApiDataProviderBase 'xyLOGIX.Api.Data.Providers.ApiDataProviderBase') class.

##### Parameters

This method has no parameters.

##### Remarks

This constructor is called automatically prior to the first instance being
created or before any static members are referenced.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Delete-`0-'></a>
### Delete(recordToDelete) `method`

##### Summary

If offered by the endpoint, uses any DELETE request exposed to remove
something from the target REST API dataset.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| recordToDelete | [\`0](#T-`0 '`0') | (Required.) Reference to an instance of the model
type, `T` , that specifies which object should be deleted
from the API dataset. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Bubbled up from whichever method call is
made on the library that accesses the target REST API in the event the
operation was not successful. |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | Thrown if the target API does
not support the concept of element deletion. |

##### Remarks

Not all REST APIs expose a means of deleting items from their
dataset. In this case, implementations of this method must throw
[NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException')



Implementers are free to deny access to this functionality (even if the target
REST API supports it) by throwing [NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException')
.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-DeleteAll-System-Predicate{`0}-'></a>
### DeleteAll(predicate) `method`

##### Summary

If supported by the target REST API, removes all elements from the
dataset that satisfy the criteria expressed by the supplied
`predicate`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [System.Predicate{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{`0}') | (Required.) Predicate expression that returns either
`true` or `false` when supplied with an instance of the element model
type, `T`, as a parameter.



By element model we mean an instance of whatever POCO is supplied by the
library providing access to the target REST API that represents a single
element of the dataset.



If the predicate returns `true` for a given instance of the element model
object, then this object strives to remove that element from the dataset using
the appropriate method call on the target REST API client library. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Bubbled up from whichever method call is
made on the library that accesses the target REST API in the event the
operation was not successful. |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | Thrown if the target API does
not support the concept of element deletion. |

##### Remarks

Not all REST APIs expose a means of deleting items from their
dataset. In this case, implementations of this method must throw
[NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException').



Implementers are free to deny access to this functionality (even if the target
REST API supports it) by throwing [NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException')
.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Find-System-Predicate{`0}-'></a>
### Find(predicate) `method`

##### Summary

Iterates through the dataset of the target REST API,
[PageSize](#P-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository-PageSize 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.PageSize')
elements at a time (default is 1), and tries to find an element matching the
criteria provided.

##### Returns

This method iterates through the dataset of the target REST API,
testing each element against the provided `predicate` . The
first element for which the `predicate` evaluates to
`true` is then returned, or `null` if an error occurred or the
matching element was otherwise not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [System.Predicate{\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Predicate 'System.Predicate{`0}') | (Required.) Lambda expression specifying how to tell
if an element is to be retrieved. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Bubbled up from whichever method call is
made on the library that accesses the target REST API in the event the
operation was not successful. |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | Might be if the target API
does not support the concept of pagination. |

##### Remarks

Clients of this repository should use this method instead of invoking
the GetAll operation and then filtering with the LINQ Where method, in order to
retrieve just those API elements that need to be retrieved until the desired
one is found.



GetAll will suck down the entire dataset, and this may not be desirable because
of rate limits etc.



Implementations should throw [NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') in
the event that the API does not support pagination -- or delegate the call to
this object's GetAll followed by [Where](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Enumerable.Where 'System.Linq.Enumerable.Where')
followed by [FirstOrDefault](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Enumerable.FirstOrDefault 'System.Linq.Enumerable.FirstOrDefault').



Alternatively, implementers may delegate this method to
[Get](#M-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository-Get 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.Get').



This repository provides these two seemingly redundant ways of searching for
objects since not all REST API controllers expose the same functionality set or
have the same rate-limit concerns.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Get-System-Object-'></a>
### Get(searchParams) `method`

##### Summary

Strives to invoke the appropriate GET method exposed by the target
REST API to simply retrieve the object matching the specified
`searchParams` without pagination or iteration.

##### Returns

Reference to an instance of an object of type
`T` that contains the data from the found element or
`null` if not found.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| searchParams | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | (Required.) A
[ExpandoObject](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Dynamic.ExpandoObject 'System.Dynamic.ExpandoObject') whose parameters contain search
values (or `null` s, if allowed by various REST APIs) to be fed to the
target REST API method that retrieves the desired element of the dataset
exposed by the API. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Bubbled up from whichever method call is
made on the library that accesses the target REST API in the event the
operation was not successful. |
| [ArgumentNullException](#T-ArgumentNullException 'ArgumentNullException') | Thrown if the required parameter,
`searchParams` , is set to a `null` reference. |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | Might be if the target API
does not support the concept of pagination. |

##### Remarks

If a target REST API supports it, clients of this repository may want
to avail themselves of this method when they know that their request needs to
result in a single API call and a single element to be returned from the
dataset.



At first glance, it would appear that this method is a duplicate of
[Find](#M-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository-Find 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.Find').



Implementers should make this method call the REST API method that directly
retrieves the object satisfying the provided criteria; if such a method is not
available, then implementers should delegate to the
[Find](#M-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository-Find 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.Find')
method.



This repository provides these two seemingly redundant ways of searching for
objects since not all REST API controllers expose the same functionality set or
have the same rate-limit concerns.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-GetAll'></a>
### GetAll() `method`

##### Summary

Obtains the gamut of elements in the target REST API dataset, using
the largest page size as more of a 'chunk size', using as many calls to the
target REST API as are necessary. Extreme caution should be used with both
implementing and calling this method, both due to rate-limiting, communications
bandwidth, and memory storage concerns.

##### Returns

Collection of instances of the element model object,
`T` , that can be used to further narrow the results.
Implementers should write the code for this method to make as aggressive an
attempt as possible to access the gamut of the available objects exposed by the
target REST API endpoint.

##### Parameters

This method has no parameters.

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Bubbled up from whichever method call is
made on the library that accesses the target REST API in the event the
operation was not successful. |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | Thrown if the target API does
not support getting the entire available collection of data elements in the
server's database, even with paging. |

##### Remarks

Implementers must throw [NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException')
in the event that the target REST API does not support retrieving its entire
available value set of elements.



This method is all-or-nothing.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-InitializeRepository'></a>
### InitializeRepository() `method`

##### Summary

Executes the processing that must be performed by all of the various
overloads of this class' constructor.

##### Parameters

This method has no parameters.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-OnRepositoryIterationError-System-Object,xyLOGIX-Api-Data-Repositories-Events-IterationErrorEventArgs-'></a>
### OnRepositoryIterationError(sender,e) `method`

##### Summary

Handles the
[](#E-xyLOGIX-Api-Data-Repositories-Interfaces-IApiRepository-IterationError 'xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.IterationError')
event raised by the repository that is wrapped by this object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | Reference to an instance of the object that raised the
event. |
| e | [xyLOGIX.Api.Data.Repositories.Events.IterationErrorEventArgs](#T-xyLOGIX-Api-Data-Repositories-Events-IterationErrorEventArgs 'xyLOGIX.Api.Data.Repositories.Events.IterationErrorEventArgs') | A [EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') that contains the event
data. |

##### Remarks

This method is typically invoked from an exception handler.

<a name='M-xyLOGIX-Api-Data-Providers-ApiDataProviderBase`1-Update-`0-'></a>
### Update(recordToUpdate) `method`

##### Summary

Calls a PUT method on the target REST API (if supported) to change
the data element specified by the criteria in
`recordToUpdate`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| recordToUpdate | [\`0](#T-`0 '`0') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Bubbled up from whichever method call is
made on the library that accesses the target REST API in the event the
operation was not successful. |
| [System.NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException') | Thrown if the target API does
not support a single element of its dataset, or if this repository chooses to
not allow access to that functionality. |

##### Remarks

If the target REST API does not support the concept of updating
specific data elements, then implementers must throw
[NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException').



It should be noted that there is no Save method in this repository pattern.
This is due to the fact that, when making this kind of call on a REST API,
changes are (conventionally) applied immediately.



Implementers are free to deny access to this functionality (even if the target
REST API supports it) by throwing [NotSupportedException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NotSupportedException 'System.NotSupportedException')
.

<a name='T-xyLOGIX-Api-Data-Providers-Properties-Resources'></a>
## Resources `type`

##### Namespace

xyLOGIX.Api.Data.Providers.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-xyLOGIX-Api-Data-Providers-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all resource lookups using this strongly typed resource class.

<a name='P-xyLOGIX-Api-Data-Providers-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.
