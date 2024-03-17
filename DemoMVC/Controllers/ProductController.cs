using DemoMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DemoMVC.Controllers
{
    public class ProductController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:44364/api");
        private readonly HttpClient _httpClient;

        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseUrl;
        }
        
        // GET: ProductController
        [HttpGet]
        public ActionResult Index()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            HttpResponseMessage httpResponseMessage = 
                _httpClient.GetAsync(_httpClient.BaseAddress + "/product/Get").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                SwaggerResponse<ProductViewModel> swaggerResponse = 
                    JsonConvert.DeserializeObject<SwaggerResponse<ProductViewModel>>(data);

                productList = swaggerResponse.Result;
            }

            return View(productList);
        }
        // GET: ProductController/Details/5
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            ProductViewModel productList = new ProductViewModel();
            HttpResponseMessage httpResponseMessage =
                _httpClient.GetAsync(_httpClient.BaseAddress + "/product/GetById?id=" + id).Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }

            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(productViewModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = 
                    _httpClient.PostAsync(_httpClient.BaseAddress + "/product/Create", content).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ProductViewModel productList = new ProductViewModel();
            HttpResponseMessage httpResponseMessage = 
                _httpClient.GetAsync(_httpClient.BaseAddress + "/product/GetById?id=" + id).Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }

            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            try
            {
                string data = JsonConvert.SerializeObject(productViewModel);
                StringContent stringContent = 
                    new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage =
                    _httpClient.PutAsync(_httpClient.BaseAddress + $"/product/Update?id={productViewModel.Id}", stringContent).Result;
               
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            ProductViewModel product = new ProductViewModel();
            HttpResponseMessage httpResponseMessage =
                _httpClient.GetAsync(_httpClient.BaseAddress + "/product/GetById?id=" + id).Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductViewModel>(data);
            }
            return View(product);
        }

        //POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                HttpResponseMessage httpResponse =
                    _httpClient.DeleteAsync(_httpClient.BaseAddress + "/product/Delete?id=" + id).Result;
                
                if(httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
