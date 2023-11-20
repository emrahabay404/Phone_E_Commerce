using DataAccess.Concrete.EntityFramework;
using E_Commerce_Business.Abstract;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace E_Commerce_API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class DenemeController : ControllerBase
   {
      private static readonly ConnectionSettings connSettings =
 new ConnectionSettings(new Uri("http://localhost:9200/"))
                 .DefaultIndex("esearchitems")
                 .DefaultMappingFor<Category>(m => m
                 .PropertyName(p => p.CategoryId, "id")
     );

      private readonly ICategoryService _CategoryService;
      private readonly E_Commerce_DbContext _context;
      private static readonly ElasticClient elasticClient = new ElasticClient(connSettings);
      public DenemeController(ICategoryService categoryService, E_Commerce_DbContext _DbContext)
      {
         _context = _DbContext;
         _CategoryService = categoryService;
         if (!elasticClient.Indices.Exists("esearchitems").Exists)
         {
            elasticClient.Indices.Create("esearchitems",
                 index => index.Map<CategoryDto>(
                      x => x
                     .AutoMap()
              ));

            elasticClient.Bulk(b => b
              .Index("esearchitems")
              .IndexMany(_context.Categories.ToList())
               );
         }
      }



      [HttpGet]
      //public async Task<IActionResult> GetAll()
      public List<Category> Get()
      {
         var response = elasticClient.Search<Category>(i => i
          .Query(q => q.MatchAll())
          .PostFilter(f => f.Range(r => r.Field(fi => fi.CategoryId).GreaterThan(0)))
           );
         List<Category> items = new List<Category>();
         foreach (var item in response.Documents)
            items.Add(item);
         return items;
         //return Ok(new SuccessResult<IEnumerable<CategoryDto>>(items, Messages.CategoriesListed));
      }


   }
}








#region RabbitMq Deneme
//[HttpGet("GetAllCategories")]
//public IActionResult GetAllCategories()
//{
//   //var result = await _categoryService.GetAllAsync();

//   //queue publish için
//   var message = "Başvurunuz başarıyla alınmıştır. Teşekkürler!";
//   var factory = new ConnectionFactory()
//   {
//      HostName = "localhost"
//   };
//   using (IConnection connection = factory.CreateConnection())
//   using (IModel channel = connection.CreateModel())
//   {
//      channel.QueueDeclare(queue: "MyFirstQueue",
//         durable: false,
//         exclusive: false,
//         autoDelete: false,
//         arguments: null);
//      // string message = JsonConvert.SerializeObject("");
//      var mybody = Encoding.UTF8.GetBytes(message);
//      channel.BasicPublish(exchange: "", routingKey: "MyFirstQueue", basicProperties: null, body: mybody);
//   }
//   //queue publish için

//   //queue getData için
//   string strKisiListesi = string.Empty;
//   var jsonData = string.Empty;
//   var cfBaglantiBilgileri = new ConnectionFactory()
//   {
//      HostName = "localhost",
//      Port = 5672,
//      UserName = "guest",
//      Password = "guest"
//   };
//   using (IConnection cfBaglanti = cfBaglantiBilgileri.CreateConnection())
//   using (IModel chnKanal = cfBaglanti.CreateModel())
//   {
//      chnKanal.QueueDeclare
//      (
//          queue: "MyFirstQueue",
//          durable: false,
//          exclusive: false,
//          autoDelete: false,
//          arguments: null
//      );
//      var ebcKuyruklar = new EventingBasicConsumer(chnKanal);
//      ebcKuyruklar.Received += (model, mq) =>
//      {
//         var MesajGovdesi = mq.Body;
//         strKisiListesi = Encoding.UTF8.GetString(MesajGovdesi.ToArray());
//      };
//      chnKanal.BasicConsume
//      (
//          queue: "MyFirstQueue",
//          autoAck: false, // true ise mesaj otomatik olarak kuyruktan silinir
//          consumer: ebcKuyruklar
//      );
//   }
//   return Ok("Gelen mesaj : " + strKisiListesi);
//   //queue getData için


//   //if (result.Success)
//   //{
//   //   return Ok(result);
//   //}
//   //return BadRequest(result);
//}
#endregion