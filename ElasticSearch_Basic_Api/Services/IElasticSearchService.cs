namespace ElasticSearch_Basic_Api.Services
{
   public interface IElasticSearchService<T>
   {
      Task<string> CreateDocumentAsync(T product);
      Task<T> GetDocumentAsync(int id);
      Task<IEnumerable<T>> GetAllDocuments();
      Task<string> UpdateDocumentasync(T product);
      Task<string> DeleteDocumentAsync(int id);

   }
}
