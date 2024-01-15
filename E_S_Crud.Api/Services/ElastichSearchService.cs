using Nest;

namespace E_S_Crud.Api.Services
{
   public class ElastichSearchService<T> : IElasticSearchService<T> where T : class
   {

      private readonly ElasticClient _elasticClient;

      public ElastichSearchService(ElasticClient elasticClient)
      {
         _elasticClient = elasticClient;
      }

      public async Task<string> CreateDocumentAsync(T product)
      {
         var response = await _elasticClient.IndexDocumentAsync(product);
         return response.IsValid ? "Product Created" : "Failed Create Product";
      }

      public async Task<string> DeleteDocumentAsync(int id)
      {
         var response = await _elasticClient.DeleteAsync(new DocumentPath<T>(id));
         return response.IsValid ? "Product Deleted" : "Failed Delete Product";
      }

      public async Task<IEnumerable<T>> GetAllDocuments()
      {
         var getresponse = await _elasticClient.SearchAsync<T>(x => x.MatchAll().Size(1000));
         return getresponse.Documents;
      }

      public async Task<T> GetDocumentAsync(int id)
      {
         var response = await _elasticClient.GetAsync(new DocumentPath<T>(id));
         return response.Source;
      }

      public async Task<string> UpdateDocumentasync(T product)
      {
         var response = await _elasticClient.UpdateAsync(new DocumentPath<T>(product),
        x => x.Doc(product).RetryOnConflict(3));
         return response.IsValid ? "Product Updated" : "Failed Update Product";
      }

   }
}
