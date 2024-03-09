using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PublisherComplexWeb.Client.Interfaces
{
    public interface IApiDataHandler
    {
        Task HandleApiDataList<T>(string url, string viewDataKey, string valueProperty, string textProperty, ViewDataDictionary viewData);

        Task<List<T>> ExtractApiDataList<T>(HttpResponseMessage response);
        Task<T> ExtractApiData<T>(HttpResponseMessage response);
    }
}
