using System;
using System.Collections.Generic;
using xyLOGIX.Api.Data.Providers.Interfaces;
using xyLOGIX.Api.Data.Repositories.Events;
using xyLOGIX.Api.Data.Repositories.Interfaces;
using xyLOGIX.Core.Debug;

namespace xyLOGIX.Api.Data.Providers
{
///  <summary> Defines the base implementation of an adapter around a API data set repository object. This is analogous to the concept of a unit of work in terms of databases. But given that APIs provide natively-paginated, with finite or infinitely-many pages, and are rate-limited, this necessitates some fancy OOP footwork. </summary> <typeparam name="T"> Type name of the POCO class that comes from the API library and which represents a single record in the dataset of the target API. </typeparam>
    public abstract class ApiDataProviderBase<T> : IApiDataProvider<T>
        where T : class
    {
///  <summary> Constructs a new instance of <see cref="T:PortfolioMonitor.Investments.ApiDatasetProviderBase" /> and returns a reference to it. </summary> <param name="repository"> (Required.) Reference to an instance of an object that implements the <see cref="T:xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository" /> interface. </param> <exception cref="T:System.ArgumentNullException"> Thrown if the required parameter, <paramref name="repository" />, is passed a <see langword="null" /> value. </exception> <remarks> This overload of the constructor is to be utilized when you want to inject an existing <c>API Repository</c> object into this provider. </remarks>
        protected ApiDataProviderBase(IApiRepository<T> repository)
        {
            DebugUtils.WriteLine(
                DebugLevel.Info,
                "*** INFO: The ApiDataProviderBase constructor that takes a Repository has been called."
            );

            Repository = repository ??
                         throw new ArgumentNullException(nameof(repository));
        }

///  <summary> Constructs a new instance of <see cref="T:xyLOGIX.Api.Data.Providers.ApiDataProviderBase" /> and returns a reference to it. </summary> <remarks> Child classes generally should override this constructor to fill the <see cref="P:xyLOGIX.Api.Data.Providers.ApiDataProviderBase.Repository" /> property with a freshly-constructed <c>API Repository</c> object on behalf of the client. </remarks>
        protected ApiDataProviderBase() { }

///  <summary> Gets or sets the maximum number of elements per page that the API will allow to be fetched. </summary> <remarks> This quantity is specified by nearly every REST API out there. This property is set by a required constructor parameter. </remarks>
        public int MaxPageSize
            => Repository.MaxPageSize;

///  <summary> Gets or sets the page size, i.e., how many elements to request at a time from the target REST API. </summary> <remarks> The Find, Delete, DeleteAll, and Update methods, by default, iterate through the target REST API data set a single element at a time. <para /> Because we have to be careful about not hitting rate limits during these operations, this property allows clients of this class to customize the number of elements taken at a time to be different from 1 by setting this property. </remarks>
        public int PageSize
            => Repository.PageSize;

///  <summary> Gets a reference to the object that implements the <see cref="T:xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository" /> interface that provides this object's functionality. </summary>
        protected abstract IApiRepository<T> Repository { get; set; }

///  <summary> Gets or sets a value saying whether to use a Repository with this object. </summary>
        public bool UseRepository { get; set; } = true;

///  <summary> If offered by the endpoint, uses any DELETE request exposed to remove something from the target REST API dataset. </summary> <param name="recordToDelete"> (Required.) Reference to an instance of the model type, <typeparamref name="T" /> , that specifies which object should be deleted from the API dataset. </param> <remarks> Not all REST APIs expose a means of deleting items from their dataset. In this case, implementations of this method must throw <see cref="T:System.NotSupportedException" /> <para /> Implementers are free to deny access to this functionality (even if the target REST API supports it) by throwing <see cref="T:System.NotSupportedException" />. </remarks> <exception cref="T:System.Exception"> Bubbled up from whichever method call is made on the library that accesses the target REST API in the event the operation was not successful. </exception> <exception cref="T:System.NotSupportedException"> Thrown if the target API does not support the concept of element deletion. </exception>
        public void Delete(T recordToDelete)
            => Repository.Delete(recordToDelete);

///  <summary> If supported by the target REST API, removes all elements from the dataset that satisfy the criteria expressed by the supplied <paramref name="predicate" />. </summary> <param name="predicate"> (Required.) Predicate expression that returns either <c>true</c> or <c>false</c> when supplied with an instance of the element model type, <typeparamref name="T" />, as a parameter. <para /> By element model we mean an instance of whatever POCO is supplied by the library providing access to the target REST API that represents a single element of the dataset. <para /> If the predicate returns <c>true</c> for a given instance of the element model object, then this object strives to remove that element from the dataset using the appropriate method call on the target REST API client library. </param> <remarks> Not all REST APIs expose a means of deleting items from their dataset. In this case, implementations of this method must throw <see cref="T:System.NotSupportedException" />. <para /> Implementers are free to deny access to this functionality (even if the target REST API supports it) by throwing <see cref="T:System.NotSupportedException" />. </remarks> <exception cref="T:System.Exception"> Bubbled up from whichever method call is made on the library that accesses the target REST API in the event the operation was not successful. </exception> <exception cref="T:System.NotSupportedException"> Thrown if the target API does not support the concept of element deletion. </exception>
        public void DeleteAll(Predicate<T> predicate)
            => Repository.DeleteAll(predicate);

///  <summary> Iterates through the dataset of the target REST API, <see cref="P:xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.PageSize" /> elements at a time (default is 1), and tries to find an element matching the criteria provided. </summary> <param name="predicate"> (Required.) Lambda expression specifying how to tell if an element is to be retrieved. </param> <returns> This method iterates through the dataset of the target REST API, testing each element against the provided <paramref name="predicate" /> . The first element for which the <paramref name="predicate" /> evaluates to <c>true</c> is then returned, or <c>null</c> if an error occurred or the matching element was otherwise not found. </returns> <remarks> Clients of this repository should use this method instead of invoking the GetAll operation and then filtering with the LINQ Where method, in order to retrieve just those API elements that need to be retrieved until the desired one is found. <para /> GetAll will suck down the entire dataset, and this may not be desirable because of rate limits etc. <para /> Implementations should throw <see cref="T:System.NotSupportedException" /> in the event that the API does not support pagination -- or delegate the call to this object's GetAll followed by <see cref="M:System.Linq.Enumerable.Where" /> followed by <see cref="M:System.Linq.Enumerable.FirstOrDefault" />. <para /> Alternatively, implementers may delegate this method to <see cref="M:xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.Get" />. <para /> This repository provides these two seemingly redundant ways of searching for objects since not all REST API controllers expose the same functionality set or have the same rate-limit concerns. </remarks> <exception cref="T:System.Exception"> Bubbled up from whichever method call is made on the library that accesses the target REST API in the event the operation was not successful. </exception> <exception cref="T:System.NotSupportedException"> Might be if the target API does not support the concept of pagination. </exception>
        public T Find(Predicate<T> predicate)
            => Repository.Find(predicate);

///  <summary> Strives to invoke the appropriate GET method exposed by the target REST API to simply retrieve the object matching the specified <paramref name="searchParams" /> without pagination or iteration. </summary> <param name="searchParams"> (Required.) A <see cref="T:System.Dynamic.ExpandoObject" /> whose parameters contain search values (or <c>null</c> s, if allowed by various REST APIs) to be fed to the target REST API method that retrieves the desired element of the dataset exposed by the API. </param> <returns> Reference to an instance of an object of type <typeparamref name="T" /> that contains the data from the found element or <c>null</c> if not found. </returns> <remarks> If a target REST API supports it, clients of this repository may want to avail themselves of this method when they know that their request needs to result in a single API call and a single element to be returned from the dataset. <para /> At first glance, it would appear that this method is a duplicate of <see cref="M:xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.Find" />. <para /> Implementers should make this method call the REST API method that directly retrieves the object satisfying the provided criteria; if such a method is not available, then implementers should delegate to the <see cref="M:xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.Find" /> method. <para /> This repository provides these two seemingly redundant ways of searching for objects since not all REST API controllers expose the same functionality set or have the same rate-limit concerns. </remarks> <exception cref="T:System.Exception"> Bubbled up from whichever method call is made on the library that accesses the target REST API in the event the operation was not successful. </exception> <exception cref="T:ArgumentNullException"> Thrown if the required parameter, <paramref name="searchParams" /> , is set to a <c>null</c> reference. </exception> <exception cref="T:System.NotSupportedException"> Might be if the target API does not support the concept of pagination. </exception>
        public T Get(dynamic searchParams)
            => Repository.Get(searchParams);

///  <summary> Obtains the gamut of elements in the target REST API dataset, using the largest page size as more of a 'chunk size', using as many calls to the target REST API as are necessary. Extreme caution should be used with both implementing and calling this method, both due to rate-limiting, communications bandwidth, and memory storage concerns. </summary> <returns> Collection of instances of the element model object, <typeparamref name="T" /> , that can be used to further narrow the results. Implementers should write the code for this method to make as aggressive an attempt as possible to access the gamut of the available objects exposed by the target REST API endpoint. </returns> <remarks> Implementers must throw <see cref="T:System.NotSupportedException" /> in the event that the target REST API does not support retrieving its entire available value set of elements. <para /> This method is all-or-nothing. </remarks> <exception cref="T:System.Exception"> Bubbled up from whichever method call is made on the library that accesses the target REST API in the event the operation was not successful. </exception> <exception cref="T:System.NotSupportedException"> Thrown if the target API does not support getting the entire available collection of data elements in the server's database, even with paging. </exception>
        public IEnumerable<T> GetAll()
            => Repository.GetAll();

///  <summary> Calls a PUT method on the target REST API (if supported) to change the data element specified by the criteria in <paramref name="recordToUpdate" />. </summary> <param name="recordToUpdate"> </param> <remarks> If the target REST API does not support the concept of updating specific data elements, then implementers must throw <see cref="T:System.NotSupportedException" />. <para /> It should be noted that there is no Save method in this repository pattern. This is due to the fact that, when making this kind of call on a REST API, changes are (conventionally) applied immediately. <para /> Implementers are free to deny access to this functionality (even if the target REST API supports it) by throwing <see cref="T:System.NotSupportedException" />. </remarks> <exception cref="T:System.Exception"> Bubbled up from whichever method call is made on the library that accesses the target REST API in the event the operation was not successful. </exception> <exception cref="T:System.NotSupportedException"> Thrown if the target API does not support a single element of its dataset, or if this repository chooses to not allow access to that functionality. </exception>
        public void Update(T recordToUpdate)
            => Repository.Update(recordToUpdate);

///  <summary> Executes the processing that must be performed by all of the various overloads of this class' constructor. </summary>
        protected void InitializeRepository()
        {
            try
            {
                DebugUtils.WriteLine(
                    DebugLevel.Info,
                    $"*** INFO: Subscribing to the Iteration Error event on the Repository..."
                );

                Repository.IterationError += OnRepositoryIterationError;
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);
            }
        }

///  <summary> Handles the <see cref="E:xyLOGIX.Api.Data.Repositories.Interfaces.IApiRepository.IterationError" /> event raised by the repository that is wrapped by this object. </summary> <param name="sender"> Reference to an instance of the object that raised the event. </param> <param name="e"> A <see cref="T:System.EventArgs" /> that contains the event data. </param> <remarks> This method is typically invoked from an exception handler. </remarks>
        protected virtual void OnRepositoryIterationError(object sender,
                IterationErrorEventArgs e)

            // dump all the exception info to the log
            => DebugUtils.LogException(e.Exception);
    }
}
